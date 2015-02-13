Football reservation for World Cup 2014 in Brazil.
===================

This is simple web application for reservation of football tickets for World Cup 2014 in Brazil. This is implemented in ASP.NET Framework with C# Programming Language.

Authors of the game:

    • Goran Petkovski
    • Viktor Ilieski


   1. Overview

This project exam was about learning concepts in web programming with ASP.NET platform and C# programming language. The main goal that we wanted to achieve was examing the 


   2. Description of the application

Football reservation tickets is an online e-commerce web application for buying and reservation of football tickets for the 2014 World Cup in Brazil. There are several parts that are presented:

     • The list of all football matches playing today and in the next 7 days.
     
     • The shopping cart of the user with selected games and calculated total price.

First, the main home page shows today's headlines about the world cup, along with the results and list of the best goalscorers.
![slika1](https://cloud.githubusercontent.com/assets/6113453/6195802/dc022b6c-b3d1-11e4-87b4-064b6f1821a8.png)
The user can Log in or Sign Up (if he doesn't have already account in the database). After the succesfull loging in our system, we give list of his selected items and bying options. He also can buy more tickets and unbuy any of it, if he decide that he can't go to that match.
![slika2](https://cloud.githubusercontent.com/assets/6113453/6195806/e8e23f8e-b3d1-11e4-83ff-1a124130f103.png)


    3. Solution of the problem
    3.1 Data structures and classes

For our solution we used several important classes and methods. The main classes presents: Player, Group and Match.

The class Player presents the actual football player and it's used for showing who are the top goal scorers. In this class we keep information about:

      • Name - String variable that gives the actual name of the Player
      
      • Country - String variable that gives the origin country of the Player
      
      • Goals - Integer variable that gives the number of goals for the Player

The class Group presents a wrapper class for showing the group consisting of several football teams:

      • Name - String variable of the Name of the Group 
      • List<Team> - ArrayList variable with list of teams in the group. This is changed dynamically according to their scores.
      • BestPlayer - Reference to Player object, that shows the best player in the group according to their goals.

The class Match represents actual match of two teams on some stadium in some city. There are several information conducted in this class:

      • Team1 - String variable of the name of Team1
      
      • Team2 - String variable of the name of Team2
      
      • Stadium - String variable of the name of Stadium presented in original language (portugese)
      
      • City - String variable of city's name in which the football match is playing
      
      • Time - DateTime variable consisting of exact Date and Time of the football match. It's presented in UTC
      
      • Price - Integer variable of the price for the football match. This must be positive (>0)


      3.2 Functions and methods

There are several important functions used in this application. We give some overview and discussion about their implementation.

First function is called after the event Page Load, that is after the web page completed loading the HTML code and all elements are shown. 

    protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Session["korisnik"] == null))
            {
                Label2.Text = "The user must sign in first for using this application!";
                populateList();
            }
            else if (Session["korisnik"] != null)
            {
                Label2.Text = "The user " + (String)Session["korisnik"] + "is successfully loged in.";
                populateList();
            }
        }

This method checks if the User is logged or not, and populates the Grid View. This is done in one Session variable called Session["korisnik"] that keeps track of user behavior, if the user is active the value is the ID or username of the User, if user close the web browser the value is empty.

Another important method is adding football ticket to the shopping cart. This is done with the function addToShoppingCart() that is shown below:

    protected void Button1_Click(object sender, EventArgs e)
    {
    SqlCommand comm;
    connect.Open();
    comm.CommandText="INSERT INTO Tiketi (id, Team1, Team2, Date, Stadion, Grad, cena, klient) VALUES (@ID, @Team1, @Team2, @Date, @Stadion, @City, @cena, @klient)";
      comm.Parameters.AddWithValue("@ID", pom+1); 
      comm.Parameters.AddWithValue("@Team1", Server.HtmlEncode(gvRss.Rows[index].Cells[0].Text));
      comm.Parameters.AddWithValue("@Team2", Server.HtmlEncode(gvRss.Rows[index].Cells[1].Text));
      comm.Parameters.AddWithValue("@Date", Convert.ToDateTime(gvRss.Rows[index].Cells[3].Text));
      int pom1=comm.ExecuteNonQuery();
      if (pom1 == 1) { Label2.Visible = true;
      Label2.Text = "You have succesfully added another ticket. Click on the shopping cart for more information.";
      Label2.ForeColor = Color.SlateBlue;
      Label2.Font.Bold = true;
    }

There some interesting part of this function. First we define SqlCommand variable called comm for defining communication to the database with the SQL syntax. We first fetch nesessary information for the columns of the table Match and execute the Query with calling the method comm.ExecuteNonQuery(). This makes communication to MS SQL Server DB and writes the corresponding values in the table.
