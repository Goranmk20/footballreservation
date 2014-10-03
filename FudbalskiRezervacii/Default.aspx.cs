using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Drawing;

namespace FudbalskiRezervacii
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack)&&(Session["News"]==null)&&(Session["Results"]==null)) { PopulateRssFeed();  populateScores(); }
            else if ((Session["News"] != null) && (Session["Results"] != null)) { gvResult.DataSource = (List<result>)Session["Results"]; gvResult.DataBind(); gvRss.DataSource = (List <News>) Session["News"]; gvRss.DataBind(); }
            if (Session["korisnik"] != null) { 
                Button1.Visible = true; Label1.Text = "Корисникот: " + (String)Session["korisnik"] + " успешно се најави.";
                
            Label1.ForeColor = Color.SaddleBrown;
            Label1.Font.Bold = true;
            Label1.Visible = true;
            }
            HttpCookie cookie = Request.Cookies["korisnik"];
            if (cookie != null)
            {
                String username = cookie["username"];
                String password = cookie["password"];
                String date = cookie["date"];
                Label1.Text = "Корисникот: " + username + " успешно се најави. Дата на последно најавување " + date;
                Label1.ForeColor = Color.SaddleBrown;
                Label1.Font.Bold = true;
                Label1.Visible = true;
                Button1.Visible = true;
                Session["korisnik"] = username;
            }

            
        }

        private void populateScores()
        {
            string RssFeedUrl = "http://footballpool.dataaccess.eu/data/info.wso/AllGames";
            List<result> feeds = new List<result>();
            try
            {
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssFeedUrl);
                var items = (from x in xDoc.Descendants("tGameInfo")
                             select new

                             {

                                 Team1 = x.Descendants("Team1").Elements("sName").First().Value,
                                 Team2 = x.Descendants("Team2").Elements("sName").First().Value,
                                 Stadium = x.Descendants("StadiumInfo").Elements("sStadiumName").First().Value,
                                 City = x.Descendants("StadiumInfo").Elements("sCityName").First().Value,
                                 Date = x.Element("dPlayDate").Value,
                                 image1 = x.Descendants("Team1").Elements("sCountryFlag").First().Value,
                                 image2 = x.Descendants("Team2").Elements("sCountryFlag").First().Value,
                                 Result =x.Element("sScore").Value
                                 /*link = x.Element("link").Value;
                                 pubDate = x.Element("pubDate").Value,
                                 description = x.Element("description").Value
                                  */
                             });
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        if (DateTime.Compare(Convert.ToDateTime(i.Date), DateTime.Now) <= 0)
                        {
                            DateTime date1 = Convert.ToDateTime(i.Date);
                            string pom = date1.ToLongDateString();
                            result f = new result
                            {

                                Team1 = i.Team1,
                                Team2 = i.Team2,
                                Date = pom,
                                Result=i.Result,
                                City = i.City,
                                Stadium = i.Stadium,
                                Image1 = i.image1,
                                Image2 = i.image2
                            };

                            feeds.Add(f);
                        }
                    }
                }
                Session["results"] = feeds;
                gvResult.DataSource = feeds;
                gvResult.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        
        private void PopulateRssFeed()
        {
            string RssFeedUrl = "http://grid.mk/rss/fudbal";
            
            List<News> feeds = new List<News>();
            try
            {
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssFeedUrl);
                var items = (from x in xDoc.Descendants("item")
                             select new

                             {
                                 
                                 Title = x.Element("title").Value,
                                 Link =x.Element("link").Value,
                                 Date = x.Element("pubDate").Value,
                                 Description =x.Element("description").Value
                                 
                                 /*link = x.Element("link").Value;
                                 pubDate = x.Element("pubDate").Value,
                                 description = x.Element("description").Value
                                  */
                             });
                if (items != null)
                {
                    foreach (var i in items)
                    {
                         
                            DateTime date1=Convert.ToDateTime(i.Date);
                            string pom = date1.ToLongDateString() + " " + date1.ToShortTimeString(); 
                            

                            News f = new News
                                {

                                   Title=i.Title,
                                   Link=i.Link,
                                   Date=pom,
                                   Description=i.Description
                                };

                            feeds.Add(f);
                        }
                    
                }
                Session["News"] = feeds;
                gvRss.DataSource = feeds;
                gvRss.DataBind();
            }
            catch (Exception ex)
            {
              
            }
        }

        protected void gvRss_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gvResult_PageIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<result> res = (List<result>)Session["results"];
            gvResult.PageIndex = e.NewPageIndex;
            gvResult.DataSource = res;
            gvResult.DataBind();
        }

        protected void gvRss_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<News> news=(List<News>) Session["News"];
            gvRss.PageIndex=e.NewPageIndex;
            gvRss.DataSource=news;
            gvRss.DataBind();
        }

    }
}
