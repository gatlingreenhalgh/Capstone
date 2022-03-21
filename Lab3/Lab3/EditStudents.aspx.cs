using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab2
{
    public partial class EditStudents : System.Web.UI.Page
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

        protected void lstbxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
                int index = lstbxStudents.SelectedIndex;
                String student = lstbxStudents.Items[index].ToString();
                string[] split = student.Split(' ');
                // Create the Query:
                String sqlQuery = "SELECT FirstName, LastName, PhoneNumber, EmailAddress, Major, GradeLevel, GraduationYear, InternshipStatus, EmploymentStatus FROM Students WHERE FirstName ='" + split[0] + "' AND LastName = '" + split[1] + "'";

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
                    HttpUtility.HtmlEncode(txtFirstName.Text = queryResults["FirstName"].ToString());
                    HttpUtility.HtmlEncode(txtLastName.Text = queryResults["LastName"].ToString());
                    HttpUtility.HtmlEncode(txtEmail.Text = queryResults["EmailAddress"].ToString());
                    HttpUtility.HtmlEncode(txtPhone.Text = queryResults["PhoneNumber"].ToString());
                    HttpUtility.HtmlEncode(txtMajor.Text = queryResults["Major"].ToString());
                    HttpUtility.HtmlEncode(txtGradeLevel.Text = queryResults["GradeLevel"].ToString());
                    HttpUtility.HtmlEncode(txtGradYear.Text = queryResults["GraduationYear"].ToString());
                    HttpUtility.HtmlEncode(txtIntern.Text = queryResults["InternshipStatus"].ToString());
                    HttpUtility.HtmlEncode(txtEmployment.Text = queryResults["EmploymentStatus"].ToString());
                }

                sqlConnect.Close();
                queryResults.Close();

            
        }

        protected void btnEditStudent_Click(object sender, EventArgs e)
        {
            int index = lstbxStudents.SelectedIndex;
            String student = lstbxStudents.Items[index].ToString();
            string[] split = student.Split(' ');

            String sqlBoth = "UPDATE Students SET FirstName='" + txtFirstName.Text + "', LastName = '" + txtLastName.Text + "' " +
                ", EmailAddress='" + txtEmail.Text + "', PhoneNumber='" + txtPhone.Text + "', Major='" + txtMajor.Text + "', " +
                "GradeLevel='" + txtGradeLevel.Text + "', GraduationYear='" + txtGradYear.Text + "', InternshipStatus='" + txtIntern.Text +
                "', EmploymentStatus='" + txtEmployment.Text + "'" +
                "FROM Students " +
                "WHERE FirstName ='" + split[0] + "' AND LastName = '" + split[1] + "'";
                // Define the connection to the DB:
                SqlConnection connectBoth =
                new SqlConnection(
                WebConfigurationManager.ConnectionStrings
                ["ConnStringOb1"].ConnectionString);
                // Create and Structure the Query Command:
                SqlCommand commandBoth = new SqlCommand();
                commandBoth.Connection = connectBoth;
                commandBoth.CommandType = CommandType.Text;
                commandBoth.CommandText = sqlBoth;
                // Execute the Query and Retrieve the Results
                connectBoth.Open();
                commandBoth.ExecuteScalar(); // Used for other than SELECT Queries
                connectBoth.Close();
            


        }
    }
}