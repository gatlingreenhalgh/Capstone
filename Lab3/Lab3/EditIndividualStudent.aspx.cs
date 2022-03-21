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

            String email = HttpUtility.HtmlEncode(Session["Student"].ToString());
            String logFN = HttpUtility.HtmlEncode(Session["LoggedInFN"].ToString());
            String logLN = HttpUtility.HtmlEncode(Session["LoggedInLN"].ToString());
            String fn = HttpUtility.HtmlEncode(txtStudentFirstName.Text);
            String ln = HttpUtility.HtmlEncode(txtStudentLastName.Text);
            String sEmail = HttpUtility.HtmlEncode(txtStudentEmail.Text);
            String phone = HttpUtility.HtmlEncode(txtStudentPhone.Text);
            String major = HttpUtility.HtmlEncode(txtStudentMajor.Text);
            String gradeLevel = HttpUtility.HtmlEncode(txtStudentGradeLevel.Text);
            String grad = HttpUtility.HtmlEncode(txtStudentGradYear.Text);
            String intern = HttpUtility.HtmlEncode(ddlStudentInternship.SelectedValue);
            String employ = HttpUtility.HtmlEncode(ddlStudentJob.SelectedValue);

            String sqlBoth = "UPDATE Students SET FirstName='" + fn + "', LastName='" + ln + "'" +
                ", EmailAddress='" + sEmail + "', PhoneNumber='" + phone + "', GradeLevel='" + gradeLevel +
                "', GraduationYear='" + grad + "', InternshipStatus='" + intern + "', EmploymentStatus='" + employ + "', Major='" + major + 
                "' FROM Students " +
                "WHERE EmailAddress ='" + email + "' AND FirstName='" + logFN + "' AND LastName='" + logLN + "'";
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
            commandBoth.ExecuteReader(); // Used for other than SELECT Queries
            connectBoth.Close();

            Session["Student"] = txtStudentEmail.Text;
            Response.Redirect("EditIndividualStudent.aspx");
        }

        protected void viewInfo()
        {
            // Create the Query:
            String sqlQuery = "SELECT FirstName, LastName, PhoneNumber, EmailAddress, Major, GraduationYear, GradeLevel, InternshipStatus, EmploymentStatus FROM Students WHERE EmailAddress ='" + Session["Student"].ToString() + "'";

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
                HttpUtility.HtmlEncode(txtStudentFirstName.Text = queryResults["FirstName"].ToString());
                HttpUtility.HtmlEncode(txtStudentLastName.Text = queryResults["LastName"].ToString());
                HttpUtility.HtmlEncode(txtStudentEmail.Text = queryResults["EmailAddress"].ToString());
                HttpUtility.HtmlEncode(txtStudentPhone.Text = queryResults["PhoneNumber"].ToString());
                HttpUtility.HtmlEncode(txtStudentMajor.Text = queryResults["Major"].ToString());
                HttpUtility.HtmlEncode(txtStudentGradYear.Text = queryResults["GraduationYear"].ToString());
                HttpUtility.HtmlEncode(txtStudentGradeLevel.Text = queryResults["GradeLevel"].ToString());
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