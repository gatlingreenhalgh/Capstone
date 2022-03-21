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
                    txtFirstName.Text = queryResults["FirstName"].ToString();
                    txtLastName.Text = queryResults["LastName"].ToString();
                    txtEmail.Text = queryResults["EmailAddress"].ToString();
                    txtPhone.Text = queryResults["PhoneNumber"].ToString();
                    txtMajor.Text = queryResults["Major"].ToString();
                    txtGradeLevel.Text = queryResults["GradeLevel"].ToString();
                    txtGradYear.Text = queryResults["GraduationYear"].ToString();
                    txtIntern.Text = queryResults["InternshipStatus"].ToString();
                    txtEmployment.Text = queryResults["EmploymentStatus"].ToString();
                }

                sqlConnect.Close();
                queryResults.Close();

            
        }

        protected void btnEditStudent_Click(object sender, EventArgs e)
        {
            int index = lstbxStudents.SelectedIndex;
            String student = lstbxStudents.Items[index].ToString();
            string[] split = student.Split(' ');

            String fn = HttpUtility.HtmlEncode(txtFirstName.Text.ToString());
            String ln = HttpUtility.HtmlEncode(txtLastName.Text.ToString());
            String email = HttpUtility.HtmlEncode(txtEmail.Text.ToString());
            String phone = HttpUtility.HtmlEncode(txtPhone.Text.ToString());
            String major = HttpUtility.HtmlEncode(txtMajor.Text.ToString());
            String gl = HttpUtility.HtmlEncode(txtGradeLevel.Text.ToString());
            String gy = HttpUtility.HtmlEncode(txtGradYear.Text.ToString());
            String intern = HttpUtility.HtmlEncode(txtIntern.Text.ToString());
            String job = HttpUtility.HtmlEncode(txtEmployment.Text.ToString());

            String sqlBoth = "UPDATE Students SET FirstName=@fn, LastName = @ln" +
                ", EmailAddress=@email, PhoneNumber=@phone, Major=@major, " +
                "GradeLevel=@gl, GraduationYear=@gy, InternshipStatus=@intern" +
                ", EmploymentStatus=@job " +
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

            commandBoth.Parameters.AddWithValue("@fn", txtFirstName.Text);
            commandBoth.Parameters.AddWithValue("@ln", txtLastName.Text);
            commandBoth.Parameters.AddWithValue("@email", txtEmail.Text);
            commandBoth.Parameters.AddWithValue("@phone", txtPhone.Text);
            commandBoth.Parameters.AddWithValue("@major", txtMajor.Text);
            commandBoth.Parameters.AddWithValue("@gl", txtGradeLevel.Text);
            commandBoth.Parameters.AddWithValue("@gy", txtGradYear.Text);
            commandBoth.Parameters.AddWithValue("@intern", txtIntern.Text);
            commandBoth.Parameters.AddWithValue("@job", txtEmployment.Text);
            // Execute the Query and Retrieve the Results
            connectBoth.Open();
                commandBoth.ExecuteScalar(); // Used for other than SELECT Queries
                connectBoth.Close();

            String sqlBoth1 = "UPDATE Students SET FirstName=@dfn, LastName = @dln" +
           ", EmailAddress=@mail " +
           "FROM Students " +
           "WHERE FirstName ='" + split[0] + "' AND LastName = '" + split[1] + "'";
            // Define the connection to the DB:
            SqlConnection connectBoth1 =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings
            ["ConnStringOb2"].ConnectionString);
            // Create and Structure the Query Command:
            SqlCommand commandBoth1 = new SqlCommand();
            commandBoth1.Connection = connectBoth1;
            commandBoth1.CommandType = CommandType.Text;
            commandBoth1.CommandText = sqlBoth1;

            commandBoth1.Parameters.AddWithValue("@dfn", HttpUtility.HtmlEncode(txtFirstName.Text));
            commandBoth1.Parameters.AddWithValue("@dln", HttpUtility.HtmlEncode(txtLastName.Text));
            commandBoth1.Parameters.AddWithValue("@mail", HttpUtility.HtmlEncode(txtEmail.Text));
            // Execute the Query and Retrieve the Results
            connectBoth1.Open();
            commandBoth1.ExecuteScalar(); // Used for other than SELECT Queries
            connectBoth1.Close();

            Response.Redirect("EditStudents.aspx");

        }
    }
}