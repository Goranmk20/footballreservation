using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
namespace FudbalskiRezervacii
{
    public partial class Teams : System.Web.UI.Page
    {
        private SqlConnection connect;
        private List<Feeds> feeds;
        protected void Page_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection();
            connect.ConnectionString=@"Data Source=.\SQLEXPRESS;AttachDbFilename='D:\Fudbalski rezervacii\FudbalskiRezervacii\FudbalskiRezervacii\App_Data\ASPNETDB.MDF';Integrated Security=True;Connect Timeout=30;User Instance=True";
            
            if ((!IsPostBack) && (Session["Games"] == null)&&(Session["Scorers"]==null)) { PopulateRssFeed(); populateScorers(); }
            else if ((Session["Games"] != null) && (Session["Scorers"] != null)) { gvRss.DataSource = (List<Feeds>)Session["Games"]; gvRss.DataBind(); GridView1.DataSource = (List<Player>)Session["Scorers"]; GridView1.DataBind(); }
            if (Session["sostojba"] != null)
            {
                List<int> list = (List<int>)Session["sostojba"];
                for (int i = 0; i < list.Count; i++)
                {
                    gvRss.Rows[list[i]].BackColor = Color.FromArgb(153, 255, 102);
                     
                    gvRss.Rows[list[i]].Enabled = false;
                }
            }
            if (Session["korisnik"] != null)
            {
                Label1.ForeColor = Color.MediumSeaGreen;
                Label1.Font.Bold = true;
                Label1.Text = "Ве молиме притиснете на копчето за потврда на резервациите.";
                Button1.Visible = true;
                Button2.Visible = true;
            }
            else
                if (Session["korisnik"] == null)
                {
                    Label1.Text = "Потребно е првин да се најавите!";
                    Label1.ForeColor = Color.DarkRed;
                    Label1.Font.Bold = true;
                }
        }

        private void populateScorers()
        {
            string RssFeedUrl = "http://footballpool.dataaccess.eu/data/info.wso/TopGoalScorers?iTopN=15";
            List<Player> feeds = new List<Player>();
            try
            {
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssFeedUrl);
                var items = (from x in xDoc.Descendants("tTopGoalScorer")
                             select new

                             {

                                 Name=x.Element("sName").Value,
                                 Goals=x.Element("iGoals").Value,
                                 Country=x.Element("sFlag").Value
                                 /*link = x.Element("link").Value;
                                 pubDate = x.Element("pubDate").Value,
                                 description = x.Element("description").Value
                                  */
                             });
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        
                            Player f = new Player
                            {

                                name=i.Name,
                                goals=i.Goals,
                                country=i.Country
                            };

                            feeds.Add(f);
                        }
                    
                }
                Session["Scorers"] = feeds;
                GridView1.DataSource = feeds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        private void PopulateRssFeed()
        {
            string RssFeedUrl = "http://footballpool.dataaccess.eu/data/info.wso/AllGames";
           feeds = new List<Feeds>();
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
                                 Time = x.Element("tPlayTime").Value,
                                 image1 = x.Descendants("Team1").Elements("sCountryFlag").First().Value,
                                 image2 = x.Descendants("Team2").Elements("sCountryFlag").First().Value
                                 /*link = x.Element("link").Value;
                                 pubDate = x.Element("pubDate").Value,
                                 description = x.Element("description").Value
                                  */
                             });
                if (items != null)
                {
                   Random r = new Random();
                    foreach (var i in items)
                    {
                       
                        
                            DateTime date1 = Convert.ToDateTime(i.Date+" "+i.Time).AddHours(5);
                            string pom = date1.ToLongDateString();
                            
                           
                            Feeds f = new Feeds
                            {

                                Team1 = i.Team1,
                                Team2 = i.Team2,
                                Date = pom,
                                Time = i.Time,
                                City = i.City,
                                Stadium = i.Stadium,
                                image1 = i.image1,
                                image2 = i.image2,
                                cena=r.Next(50, 100)
                            };

                            feeds.Add(f);
                        
                    }
                }
                Session["Games"] = feeds;
                gvRss.DataSource = feeds;
                gvRss.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvRss_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Visible = true;
            ViewState["index"] = gvRss.SelectedIndex;
            if (Session["korisnik"] != null)
            {

                if (Session["lista"] == null) //ednas ke se izvrsi ova
                {
                    List<Feeds> list = new List<Feeds>();
                    Feeds f = new Feeds
                    {
                        Team1 = gvRss.SelectedRow.Cells[0].Text,
                        Team2 = gvRss.SelectedRow.Cells[1].Text,
                        Stadium = gvRss.SelectedRow.Cells[2].Text,
                        Date = gvRss.SelectedRow.Cells[3].Text,
                        City = gvRss.SelectedRow.Cells[4].Text,
                        cena = Convert.ToInt16(gvRss.SelectedRow.Cells[6].Text)
                    };
                    list.Add(f);
                    Session["lista"] = list;


                }
                else
                {
                    List<Feeds> list = (List<Feeds>)Session["lista"];
                    Feeds f = new Feeds { Team1 = gvRss.SelectedRow.Cells[0].Text, Team2 = gvRss.SelectedRow.Cells[1].Text, Stadium = gvRss.SelectedRow.Cells[2].Text, Date = gvRss.SelectedRow.Cells[3].Text, City = gvRss.SelectedRow.Cells[4].Text, cena = Convert.ToInt16(gvRss.SelectedRow.Cells[6].Text) };
                    list.Add(f);
                    Session["lista"] = list;
                }
                gvRss.Rows[gvRss.SelectedIndex].BackColor = Color.FromArgb(153, 255, 102);
                
                gvRss.Rows[gvRss.SelectedIndex].Enabled = false;
                if (Session["sostojba"] == null)
                {
                    List<int> lista = new List<int>();
                    lista.Add(gvRss.SelectedIndex);
                    Session["sostojba"] = lista;


                }
                else
                {
                    List<int> list = (List<int>)Session["sostojba"];

                    list.Add(gvRss.SelectedIndex);
                   
                    Session["sostojba"] = list;

                }
            }
            else
            {
                Label1.Text = "Потребно е првин да се најавите!";
                Label1.ForeColor = Color.DarkRed;
                Label1.Font.Bold = true;
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ViewState["index"]!=null){
                int index = (int)ViewState["index"];
            SqlCommand comm=new SqlCommand("SELECT MAX(id) AS Expr1 FROM  Tiketi GROUP BY id ORDER BY id DESC", connect);
            SqlDataReader read;
            try{
                connect.Open();
                int pom=0;
                read=comm.ExecuteReader();
                if (read.Read())
                {
                    pom=(int)read["Expr1"];
                    
                    
                }
                read.Close();
                comm.CommandText="INSERT INTO Tiketi (id, Team1, Team2, Date, Stadion, Grad, cena, klient) VALUES (@ID, @Team1, @Team2, @Date, @Stadion, @City, @cena, @klient)";
                
                comm.Parameters.AddWithValue("@ID", pom+1); 
                comm.Parameters.AddWithValue("@Team1", Server.HtmlEncode(gvRss.Rows[index].Cells[0].Text));
                comm.Parameters.AddWithValue("@Team2", Server.HtmlEncode(gvRss.Rows[index].Cells[1].Text));
                comm.Parameters.AddWithValue("@Date", Convert.ToDateTime(gvRss.Rows[index].Cells[3].Text));
                comm.Parameters.AddWithValue("@Stadion", Server.HtmlEncode(gvRss.Rows[index].Cells[2].Text));
                comm.Parameters.AddWithValue("@City", Server.HtmlEncode(gvRss.Rows[index].Cells[4].Text));
                comm.Parameters.AddWithValue("@cena", gvRss.Rows[index].Cells[6].Text);
                comm.Parameters.AddWithValue("@klient", Session["korisnik"] as String);
                int pom1=comm.ExecuteNonQuery();
                if (pom1 == 1) { Label2.Visible = true;
                Label2.Text = "Успешно додадовте резервации. Кликнете на Кошничка за повеќе информации.";
                Label2.ForeColor = Color.SlateBlue;
                Label2.Font.Bold = true;
                }
            }
            catch (Exception ex) {}
            finally {connect.Close();}
        }
        else {}
        }


        protected void gvRss_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<Feeds> games = (List<Feeds>)Session["Games"];
            gvRss.PageIndex = e.NewPageIndex;
            gvRss.DataSource = games;
            gvRss.DataBind();
        }

        protected void gvRss_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            if (Session["korisnik"] == null)
            {
                Label1.Text = "Потребно е првин да се најавите!";
                Label1.ForeColor = Color.DarkRed;
                Label1.Font.Bold = true; e.Cancel = true;
            }
           
        }

    }
}