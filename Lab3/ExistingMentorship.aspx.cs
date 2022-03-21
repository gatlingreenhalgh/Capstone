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
    public partial class ExistingMentorship : System.Web.UI.Page
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

        protected void lstbxMentor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstbxStudentsofMentor.Items.Clear();

            int index = lstbxMentor.SelectedIndex;
            String mentor = lstbxMentor.Items[index].ToString();
            string[] words = mentor.Split(' ');

            // Create the Query:
            String sqlQuery =
            "SELECT FirstName + ' ' + LastName AS Students, Students.StudentID FROM Students, Mentorship, Members " +
            "WHERE Mentorship.MemberID = Members.MemberID " +
            "AND Mentorship.StudentID = Students.StudentID " +
            "AND Members.MemberFirstName = '" + words[0] + "' AND Members.MemberLastName = '" + words[1] + "'";
            // Define the connection to the DB:
            SqlConnection sqlConnect =
             new SqlConnection(
            WebConfigurationManager.ConnectionStrings
            ["ConnStringOb1"].ConnectionString);
            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            // Execute the Query and Retrieve the Results
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            // Read the results and populate the ListBox
            while (queryResults.Read())
            {
                lstbxStudentsofMentor.Items.Add(
                new ListItem(
               queryResults["Students"].ToString(), queryResults
               ["StudentID"].ToString()
                ));
            }
            sqlConnect.Close();
            queryResults.Close();

        }

        protected void lstbxStudentsofMentor_SelectedIndexChanged(object sender, EventArgs e)
        { 
                int index = lstbxStudentsofMentor.SelectedIndex;
                String student = lstbxStudentsofMentor.Items[index].ToString();
                string[] split = student.Split(' ');
                // Create the Query:
                String sqlQuery = "SELECT FirstName, LastName, EmailAddress, Major, GradeLevel, EmploymentStatus FROM Students WHERE FirstName ='" + split[0] + "' AND LastName = '" + split[1] + "'";

                // Define the connection to the DB:
                SqlConnection sqlConnect =
                new SqlConnection(
                WebConfigurationManager.ConnectionStrings
                ["ConnStringOb1"].ConnectionString);

                // Create and Structure the Query Command:
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                // Execute the Query and Retrieve the Results
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                // Read the results and populate the ListBox
                while (queryResults.Read())
                {
                    txtMentoredStudentFirstName.Text = queryResults["FirstName"].ToString();
                    txtMentoredStudentLastName.Text = queryResults["LastName"].ToString();
                    txtMentoredStudentEmail.Text = queryResults["EmailAddress"].ToString();
                    txtMentoredStudentMajor.Text = queryResults["Major"].ToString();
                    txtMentoredStudentGradeLevel.Text = queryResults["GradeLevel"].ToString();
                    txtMentoredStudentEmployment.Text = queryResults["EmploymentStatus"].ToString();
                }

                sqlConnect.Close();
                queryResults.Close();
            
        }
    }
}