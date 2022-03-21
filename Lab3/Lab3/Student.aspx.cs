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
    public partial class Student : System.Web.UI.Page
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

        protected void btnStudentPopulate_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtStudentFirstName.Text = "Joe");
            HttpUtility.HtmlEncode(txtStudentLastName.Text = "Schmoe");
            HttpUtility.HtmlEncode(txtStudentEmail.Text = "jschmoe@dukes.jmu.edu");
            HttpUtility.HtmlEncode(txtStudentPhone.Text = "5551234567");
            HttpUtility.HtmlEncode(txtStudentMajor.Text = "Accounting");
            HttpUtility.HtmlEncode(txtStudentGradeLevel.Text = "Freshman");
            HttpUtility.HtmlEncode(txtStudentGradYear.Text = "2026");
            HttpUtility.HtmlEncode(txtStudentUser.Text = "newStudent");
            HttpUtility.HtmlEncode(txtStudentPass.Text = "newStudentPass");

        }

        protected void btnStudentClear_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtStudentFirstName.Text = "");
            HttpUtility.HtmlEncode(txtStudentLastName.Text = "");
            HttpUtility.HtmlEncode(txtStudentEmail.Text = "");
            HttpUtility.HtmlEncode(txtStudentPhone.Text = "");
            HttpUtility.HtmlEncode(txtStudentMajor.Text = "");
            HttpUtility.HtmlEncode(txtStudentGradeLevel.Text = "");
            HttpUtility.HtmlEncode(txtStudentGradYear.Text = "");
            ddlStudentInternship.SelectedValue = "No";
            ddlStudentJob.SelectedValue = "No";
            HttpUtility.HtmlEncode(txtStudentUser.Text = "");
            HttpUtility.HtmlEncode(txtStudentPass.Text = "");
        }

        protected void btnStudentSave_Click(object sender, EventArgs e)
        {

            String fn = HttpUtility.HtmlEncode(txtStudentFirstName.Text.ToString());
            String ln = HttpUtility.HtmlEncode(txtStudentLastName.Text.ToString());
            String email = HttpUtility.HtmlEncode(txtStudentEmail.Text.ToString());
            String phone = HttpUtility.HtmlEncode(txtStudentPhone.Text.ToString());
            String major = HttpUtility.HtmlEncode(txtStudentMajor.Text.ToString());
            String gl = HttpUtility.HtmlEncode(txtStudentGradeLevel.Text.ToString());
            String gy = HttpUtility.HtmlEncode(txtStudentGradYear.Text.ToString());
            String intern = ddlStudentInternship.SelectedValue.ToString();
            String job = ddlStudentJob.SelectedValue.ToString();
            String user = HttpUtility.HtmlEncode(txtStudentUser.Text.ToString());
            String pass = HttpUtility.HtmlEncode(txtStudentPass.Text.ToString());


            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT EmailAddress FROM Students WHERE EmailAddress = '" + email + "'";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

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
                lblError.Visible = true;
                sqlConnect.Close();
                queryResults.Close();
            }
            else
            {
                lblError.Visible = false;
                sqlConnect.Close();
                queryResults.Close();
                // Create the Query with Concatenation of Text Boxes:
                String sqlQuery1 = "INSERT INTO Students (FirstName, LastName,EmailAddress, PhoneNumber, Major, GradeLevel, GraduationYear, InternshipStatus, EmploymentStatus, StudentUser, StudentPass)" +
                 " VALUES("
                 + "@fn,"
                + "@ln,"
                + "@email,"
                + "@phone,"
                + "@major,"
                + "@gl,"
                + "@gy,"
                + "@intern,"
                + "@job,"
                + "@user,"
                + "@pass)";
                // Define the connection to the DB:
                SqlConnection sqlConnect1 =
                new SqlConnection(
               WebConfigurationManager.ConnectionStrings
               ["ConnStringOb2"].ConnectionString);
                // Create and Structure the Query Command:
                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery1;
                sqlCommand.Parameters.AddWithValue("@fn", txtStudentFirstName.Text);
                sqlCommand.Parameters.AddWithValue("@ln", txtStudentLastName.Text);
                sqlCommand.Parameters.AddWithValue("@email", txtStudentEmail.Text);
                sqlCommand.Parameters.AddWithValue("@phone", txtStudentPhone.Text);
                sqlCommand.Parameters.AddWithValue("@major", txtStudentMajor.Text);
                sqlCommand.Parameters.AddWithValue("@gl", txtStudentGradeLevel.Text);
                sqlCommand.Parameters.AddWithValue("@gy", txtStudentGradYear.Text);
                sqlCommand.Parameters.AddWithValue("@intern", ddlStudentInternship.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@job", ddlStudentJob.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@user", txtStudentUser.Text);
                sqlCommand.Parameters.Add(new SqlParameter("@pass", PasswordHash.HashPassword(txtStudentPass.Text)));
                // Execute the Query and Retrieve the Results
                sqlConnect.Open();
                sqlCommand.ExecuteScalar(); // Used for other than SELECT Queries
                sqlConnect.Close();
            }
            
        }
    }
}
