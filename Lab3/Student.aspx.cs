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
            else if (Session["Admin"] != null)
            {
                MasterPageFile = "~/Admin.Master";
            }
            else
            {
                MasterPageFile = "~/Lab3Master.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnStudentPopulate_Click(object sender, EventArgs e)
        {
            txtStudentFirstName.Text = "Joe";
            txtStudentLastName.Text = "Schmoe";
            txtStudentEmail.Text = "jschmoe@dukes.jmu.edu";
            txtStudentPhone.Text = "5551234567";
            txtStudentMajor.Text = "Accounting";
            txtStudentGradeLevel.Text = "Freshman";
            txtStudentGradYear.Text = "2026";
            txtStudentUser.Text = "newStudent";
            txtStudentPass.Text = "newStudentPass";

        }

        protected void btnStudentClear_Click(object sender, EventArgs e)
        {
            txtStudentFirstName.Text = "";
            txtStudentLastName.Text = "";
            txtStudentEmail.Text = "";
            txtStudentPhone.Text = "";
            txtStudentMajor.Text = "";
            txtStudentGradeLevel.Text = "";
            txtStudentGradYear.Text = "";
            ddlStudentInternship.SelectedValue = "No";
            ddlStudentJob.SelectedValue = "No";
            txtStudentUser.Text = "";
            txtStudentPass.Text = "";
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
            String intern = HttpUtility.HtmlEncode(ddlStudentInternship.SelectedValue.ToString());
            String job = HttpUtility.HtmlEncode(ddlStudentJob.SelectedValue.ToString());
            String user = HttpUtility.HtmlEncode(txtStudentUser.Text.ToString());
            String pass = HttpUtility.HtmlEncode(txtStudentPass.Text.ToString());


            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT StudentUser FROM Students WHERE StudentUser = @use";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@use", user);
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
                String sqlQuery1 = "INSERT INTO ProposedStudents (PSFirstName, PSLastName, PSEmailAddress, PSPhoneNumber, PSMajor, PSGradeLevel, PSGraduationYear, PSInternshipStatus, PSEmploymentStatus, PSStudentUser, PSStudentPass)" +
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
                sqlCommand.Parameters.AddWithValue("@fn", HttpUtility.HtmlEncode(txtStudentFirstName.Text));
                sqlCommand.Parameters.AddWithValue("@ln", HttpUtility.HtmlEncode(txtStudentLastName.Text));
                sqlCommand.Parameters.AddWithValue("@email", HttpUtility.HtmlEncode(txtStudentEmail.Text));
                sqlCommand.Parameters.AddWithValue("@phone", HttpUtility.HtmlEncode(txtStudentPhone.Text));
                sqlCommand.Parameters.AddWithValue("@major", HttpUtility.HtmlEncode(txtStudentMajor.Text));
                sqlCommand.Parameters.AddWithValue("@gl", HttpUtility.HtmlEncode(txtStudentGradeLevel.Text));
                sqlCommand.Parameters.AddWithValue("@gy", HttpUtility.HtmlEncode(txtStudentGradYear.Text));
                sqlCommand.Parameters.AddWithValue("@intern", HttpUtility.HtmlEncode(ddlStudentInternship.SelectedValue));
                sqlCommand.Parameters.AddWithValue("@job", HttpUtility.HtmlEncode(ddlStudentJob.SelectedValue));
                sqlCommand.Parameters.AddWithValue("@user", HttpUtility.HtmlEncode(txtStudentUser.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@pass", PasswordHash.HashPassword(txtStudentPass.Text)));
                // Execute the Query and Retrieve the Results
                sqlConnect.Open();
                sqlCommand.ExecuteScalar(); // Used for other than SELECT Queries
                sqlConnect.Close();
            }
            
        }
    }
}
