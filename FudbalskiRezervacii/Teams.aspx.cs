using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FudbalskiRezervacii
{
    public partial class Games : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack)&&(Session["Teams"]==null)) populate();
            else if (Session["Teams"] != null) { gvResult.DataSource = (List<Group>)Session["Teams"]; gvResult.DataBind(); }
        }
      

        private void populate()
        {
            string RssFeedUrl = "http://footballpool.dataaccess.eu/data/info.wso/AllGroupCompetitors";
            List<Group> feeds = new List<Group>();
            try
            {
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssFeedUrl);
                var items = (from x in xDoc.Descendants("tGroupsCompetitors")
                             select new

                             {

                                 Name = x.Descendants("GroupInfo").Elements("sCode").First().Value,
                                 Team1 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(0).Element("sName").Value,
                                 Team2 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(1).Element("sName").Value,
                                 Team3 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(2).Element("sName").Value,
                                 Team4 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(3).Element("sName").Value,
                                 Image1 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(0).Element("sCountryFlag").Value,
                                 Image2 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(1).Element("sCountryFlag").Value,
                                 Image3 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(2).Element("sCountryFlag").Value,
                                 Image4 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(3).Element("sCountryFlag").Value,
                                 id1 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(0).Element("sWikipediaURL").Value,
                                 id2 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(1).Element("sWikipediaURL").Value,
                                 id3 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(2).Element("sWikipediaURL").Value,
                                 id4 = x.Descendants("TeamsInGroup").Elements("tTeamInfo").ElementAt(3).Element("sWikipediaURL").Value,
                                 
                                 /*link = x.Element("link").Value;
                                 pubDate = x.Element("pubDate").Value,
                                 description = x.Element("description").Value
                                  */
                             });
                if (items != null)
                {
                    foreach (var i in items)
                    {

                        List<Team> t = new List<Team>();
                        Team t1=new Team();
                        t1.ime=i.Team1;
                        t1.image=i.Image1;
                        t1.broj=i.id1;
                        t.Add(t1);
                        Team t2 = new Team();
                        t2.ime = i.Team2;
                        t2.image = i.Image2;
                        t2.broj = i.id2;
                        t.Add(t2);
                        Team t3 = new Team();
                        t3.ime = i.Team3;
                        t3.image = i.Image3;
                        t3.broj = i.id3;
                        t.Add(t3);
                        Team t4 = new Team();
                        t4.ime = i.Team4;
                        t4.image = i.Image4;
                        t4.broj = i.id4;
                        t.Add(t4);
                           Group f = new Group
                            {

                               Ime=i.Name,
                               timovi=t

                            };

                            feeds.Add(f);
                        
                    }
                }
                Session["Teams"] = feeds;
                gvResult.DataSource = feeds;
                gvResult.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
}