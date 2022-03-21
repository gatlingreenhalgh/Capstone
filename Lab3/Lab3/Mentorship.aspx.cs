using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Greenhalgh_Lab_1
{
    public partial class Mentorship : System.Web.UI.Page
    {
        private void Page_PreInit(object sender, EventArgs e)
        {
            //Choose MasterPage
            if (Session["Member"] != null)
            {
                MasterPageFile = "~/MemberMaster.Master";
            }
            else
            {
                MasterPageFile = "~/Admin.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check Login Status
            if (Session["Member"] != null || Session["Admin"] != null)
            {

            }
            else
            {
                Session["MustLogin"] = "You must Login First to Access That Page!";
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void btnMentorshipPopulate_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtMenteeFirstName.Text = "Joe");
            HttpUtility.HtmlEncode(txtMenteeLastName.Text = "Schmoe");
            HttpUtility.HtmlEncode(txtMentorFirstName.Text = "Jeremy");
            HttpUtility.HtmlEncode(txtMentorLastName.Text = "Ezell");
        }

        protected void btnMentorshipSave_Click(object sender, EventArgs e)
        {
            String fn = HttpUtility.HtmlEncode(txtMenteeFirstName.Text.ToString());
            String ln = HttpUtility.HtmlEncode(txtMenteeLastName.Text.ToString());
            String mfn = HttpUtility.HtmlEncode(txtMentorFirstName.Text.ToString());
            String mln = HttpUtility.HtmlEncode(txtMentorLastName.Text.ToString()); 


            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT FirstName FROM Students WHERE FirstName = '" + fn + "' AND LastName = '" + ln + "'";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            // Execute the Query and Retrieve the Results
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            if (queryResults.Read())
            {
                lblError.Visible = false;
                sqlConnect.Close();
                queryResults.Close();
                
                // Create the Query with Concatenation of Text Boxes:
                String Query = "SELECT MemberFirstName FROM Members WHERE MemberFirstName = '" + mfn + "' AND MemberLastName = '" + mln + "'";

                // Define the connection to the DB:
                SqlConnection Connect =
                new SqlConnection(
                WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

                // Create and Structure the Query Command:
                SqlCommand Command = new SqlCommand();
                Command.Connection = Connect;
                Command.CommandType = CommandType.Text;
                Command.CommandText = Query;
                // Execute the Query and Retrieve the Results
                Connect.Open();
                SqlDataReader results = Command.ExecuteReader();

                if (results.Read())
                {
                    lblError.Visible = false;
                    Connect.Close();
                    results.Close();

                    // Create the Query with Concatenation of Text Boxes:
                    String theQuery = "SELECT MentorshipID FROM Mentorship, Students, Members WHERE Mentorship.StudentID = Students.StudentID and Members.MemberID = Mentorship.MemberID AND FirstName='" 
                       + fn + "' AND LastName = '" + ln + "' AND MemberFirstName = '" + mfn + "' AND MemberLastName = '" + mln + "'";

                    // Define the connection to the DB:
                    SqlConnection sqlConnection =
                    new SqlConnection(
                    WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

                    // Create and Structure the Query Command:
                    SqlCommand theCommandsql = new SqlCommand();
                    theCommandsql.Connection = sqlConnection;
                    theCommandsql.CommandType = CommandType.Text;
                    theCommandsql.CommandText = theQuery;
                    // Execute the Query and Retrieve the Results
                    sqlConnection.Open();
                    SqlDataReader theResultssql = theCommandsql.ExecuteReader();

                    if (theResultssql.Read())
                    {
                        lblError.Visible = true;
                        sqlConnection.Close();
                        theResultssql.Close();
                    }
                    else {
                        lblError.Visible = false;
                        sqlConnection.Close();
                        theResultssql.Close();

                        // Create the Query with Concatenation of Text Boxes:
                        String mentorQuery = "INSERT INTO Mentorship (MemberID, StudentID) SELECT MemberID, StudentID FROM Members, Students WHERE " +
                        "MemberFirstName = '" + mfn + "' AND " +
                        "MemberLastName = '" + mln + "' AND " +
                        "FirstName = '" + fn + "' AND " +
                        "LastName = '" + ln + "'";
                        // Define the connection to the DB:
                        SqlConnection sqlConnect1 =
                        new SqlConnection(
                       WebConfigurationManager.ConnectionStrings
                       ["ConnStringOb1"].ConnectionString);
                        // Create and Structure the Query Command:
                        SqlCommand sqlCommand1 = new SqlCommand();
                        sqlCommand.Connection = sqlConnect;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = mentorQuery;
                        // Execute the Query and Retrieve the Results
                        sqlConnect.Open();
                        sqlCommand.ExecuteScalar(); // Used for other than SELECT Queries
                        sqlConnect.Close();
                    }

                   
                }
                else
                {
                   lblError.Visible = true;
                    sqlConnect.Close();
                    queryResults.Close();

                }


            }
            else
            {
                lblError.Visible = true;
                sqlConnect.Close();
                queryResults.Close();

            }
        }

        protected void btnMentorshipClear_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtMenteeFirstName.Text = "");
            HttpUtility.HtmlEncode(txtMenteeLastName.Text = "");
            HttpUtility.HtmlEncode(txtMentorFirstName.Text = "");
            HttpUtility.HtmlEncode(txtMentorLastName.Text = "");
        }
    }
}