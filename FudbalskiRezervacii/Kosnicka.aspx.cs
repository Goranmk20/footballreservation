using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace FudbalskiRezervacii
{
    public partial class Kosnicka : System.Web.UI.Page
    {
        private SqlConnection connect;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename='D:\Fudbalski rezervacii\FudbalskiRezervacii\FudbalskiRezervacii\App_Data\ASPNETDB.MDF';Integrated Security=True;Connect Timeout=30;User Instance=True";

            if ((!IsPostBack) && (Session["korisnik"] != null)&&(Session["kosnicka"]==null))
            {
                Label2.Text = "Корисникот:  "
                + (String)Session["korisnik"] + " вие имате резервации за следниве натпревари: ";
                populateList();
            }
            else if (Session["kosnicka"] != null)
            {
                Label2.Text = "Корисникот: " + (String)Session["korisnik"] + " има резервации за следниве натпревари: ";
                populateList();
            }

        }

        private void populateList()
        {
            GridView1.Visible = true;
            SqlCommand command = new SqlCommand("SELECT id, Team1, Team2, Date, Stadion, Grad, cena  FROM aspnet_Users INNER JOIN Tiketi ON aspnet_Users.UserName = Tiketi.klient WHERE (aspnet_Users.UserName = 'Goranmk20')");
            command.Connection = connect;
            //command.Parameters.AddWithValue("@aspnet_Users.UserName", Convert.ToString(Session["korisnik"]));
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();
            try

            {
                connect.Open();
                adapter.Fill(dataset, "Tabela1");

                Session["kosnicka"] = dataset;
                GridView1.DataSource = dataset;
                GridView1.DataBind();
            }
            catch (Exception ex) { }
            finally {
                connect.Close();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM Tiketi WHERE (id = @id)");
            comm.Connection = connect;
            comm.Parameters.AddWithValue("@id", GridView1.Rows[e.RowIndex].Cells[0].Text);
            try
            {
                connect.Open();
                int pom = comm.ExecuteNonQuery();
                if (pom == 1)
                {
                    Label3.Visible = true;
                    Label3.Text = "Успешно избришавте податок.";
                Label3.Font.Bold = true;
                Label3.ForeColor = Color.IndianRed;
                }
                
            }
            catch (Exception ex) { }
            finally { connect.Close(); }
        }
    }
}