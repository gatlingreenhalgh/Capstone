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

        

        protected void btnMentorshipSave_Click(object sender, EventArgs e)
        {
            int index = lstbxMentor.SelectedIndex;
            String mentor = lstbxMentor.Items[index].ToString();
            string[] words = mentor.Split(' ');

            int i = lstbxStudent.SelectedIndex;
            String student = lstbxStudent.Items[index].ToString();
            string[] split = student.Split(' ');


            // Create the Query with Concatenation of Text Boxes:
            String theQuery = "SELECT MentorshipID FROM Mentorship, Students, Members WHERE Mentorship.StudentID = Students.StudentID and Members.MemberID = Mentorship.MemberID AND FirstName='" 
                       + split[0] + "' AND LastName = '" + split[1] + "' AND MemberFirstName = '" + words[0] + "' AND MemberLastName = '" + words[1] + "'";

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
                        String mentorQuery1 = "INSERT INTO Mentorship (MemberID, StudentID) SELECT MemberID, StudentID FROM Members, Students WHERE " +
                        "MemberFirstName = '" + words[0] + "' AND " +
                        "MemberLastName = '" + words[1] + "' AND " +
                        "FirstName = '" + split[0] + "' AND " +
                        "LastName = '" + split[1] + "'";
                        // Define the connection to the DB:
                        SqlConnection sqlConnect1 =
                        new SqlConnection(
                       WebConfigurationManager.ConnectionStrings
                       ["ConnStringOb1"].ConnectionString);
                        // Create and Structure the Query Command:
                        SqlCommand sqlCommand1 = new SqlCommand();
                        sqlCommand1.Connection = sqlConnect1;
                        sqlCommand1.CommandType = CommandType.Text;
                        sqlCommand1.CommandText = mentorQuery1;
                        // Execute the Query and Retrieve the Results
                        sqlConnect1.Open();
                        sqlCommand1.ExecuteScalar(); // Used for other than SELECT Queries
                        sqlConnect1.Close();
            }
        }
    }
}