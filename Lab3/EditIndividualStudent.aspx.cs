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
    public partial class EditIndividualStudent : System.Web.UI.Page
    {
        private void Page_PreInit(object sender, EventArgs e)
        {
            //Choose MasterPage
            if (Session["Student"] != null)
            {
                MasterPageFile = "~/StudentMaster.Master";
            }
            else if (Session["Member"] != null)
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
            if (Session["Member"] != null || Session["Student"] != null || Session["Admin"] != null)
            {

            }
            else
            {
                Session["MustLogin"] = "You must Login First to Access That Page!";
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void btnStudentEdit_Click(object sender, EventArgs e)
        {

            String use = Session["Student"].ToString();
            String logFN = Session["LoggedInFN"].ToString();
            String logLN = Session["LoggedInLN"].ToString();

            String sqlBoth = "UPDATE Students SET FirstName=@fn, LastName=@ln" +
                ", EmailAddress=@email, PhoneNumber=@phone, GradeLevel=@gl" +
                ", GraduationYear=@gy , InternshipStatus=@intern, EmploymentStatus=@job, Major=@major" + 
                " FROM Students " +
                "WHERE StudentUser =@use AND FirstName=@logFN AND LastName=@logLN";
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

            commandBoth.Parameters.AddWithValue("@fn", HttpUtility.HtmlEncode(txtStudentFirstName.Text));
            commandBoth.Parameters.AddWithValue("@ln", HttpUtility.HtmlEncode(txtStudentLastName.Text));
            commandBoth.Parameters.AddWithValue("@email", HttpUtility.HtmlEncode(txtStudentEmail.Text));
            commandBoth.Parameters.AddWithValue("@phone", HttpUtility.HtmlEncode(txtStudentPhone.Text));
            commandBoth.Parameters.AddWithValue("@major", HttpUtility.HtmlEncode(txtStudentMajor.Text));
            commandBoth.Parameters.AddWithValue("@gl", HttpUtility.HtmlEncode(txtStudentGradeLevel.Text));
            commandBoth.Parameters.AddWithValue("@gy", HttpUtility.HtmlEncode(txtStudentGradYear.Text));
            commandBoth.Parameters.AddWithValue("@intern", HttpUtility.HtmlEncode(ddlStudentInternship.SelectedValue));
            commandBoth.Parameters.AddWithValue("@job", HttpUtility.HtmlEncode(ddlStudentJob.SelectedValue));
            commandBoth.Parameters.AddWithValue("@use", use);
            commandBoth.Parameters.AddWithValue("@logFN", logFN);
            commandBoth.Parameters.AddWithValue("@logLN", logLN);

            // Execute the Query and Retrieve the Results
            connectBoth.Open();
            commandBoth.ExecuteReader(); // Used for other than SELECT Queries
            connectBoth.Close();

            String sqlBoth1 = "UPDATE Students SET FirstName=@Afn, LastName=@Aln" +
               ", EmailAddress=@Aemail " +
               "WHERE StudentUser ='" + use + "' AND FirstName='" + logFN + "' AND LastName='" + logLN + "'";
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

            commandBoth1.Parameters.AddWithValue("@Afn", HttpUtility.HtmlEncode(txtStudentFirstName.Text));
            commandBoth1.Parameters.AddWithValue("@Aln", HttpUtility.HtmlEncode(txtStudentLastName.Text));
            commandBoth1.Parameters.AddWithValue("@Aemail", HttpUtility.HtmlEncode(txtStudentEmail.Text));
            // Execute the Query and Retrieve the Results
            connectBoth1.Open();
            commandBoth1.ExecuteReader(); // Used for other than SELECT Queries
            connectBoth1.Close();

            Response.Redirect("EditIndividualStudent.aspx");

        }

        protected void viewInfo()
        {
            // Create the Query:
            String sqlQuery = "SELECT FirstName, LastName, PhoneNumber, EmailAddress, Major, GraduationYear, GradeLevel, InternshipStatus, EmploymentStatus FROM Students WHERE StudentUser ='" + Session["Student"].ToString() + "'";

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
                txtStudentFirstName.Text = queryResults["FirstName"].ToString();
                txtStudentLastName.Text = queryResults["LastName"].ToString();
                txtStudentEmail.Text = queryResults["EmailAddress"].ToString();
                txtStudentPhone.Text = queryResults["PhoneNumber"].ToString();
                txtStudentMajor.Text = queryResults["Major"].ToString();
                txtStudentGradYear.Text = queryResults["GraduationYear"].ToString();
                txtStudentGradeLevel.Text = queryResults["GradeLevel"].ToString();
                ddlStudentInternship.SelectedValue = queryResults["InternshipStatus"].ToString();
                ddlStudentJob.SelectedValue = queryResults["EmploymentStatus"].ToString(); 
            }

            sqlConnect.Close();
            queryResults.Close();
        }

        protected void btnViewInfo_Click(object sender, EventArgs e)
        {
            viewInfo();
        }
    }
}