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
    public partial class Member : System.Web.UI.Page
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

        protected void btnMemberPopulate_Click(object sender, EventArgs e)
        {
            txtMemberFirstName.Text = "Bob";
            txtMemberLastName.Text = "Roberts";
            txtMemberEmail.Text = "broberts@jmu.edu";
            txtMemberPhone.Text = "555-111-1112";
            txtMemberGradYear.Text = "1854";
            txtMemberTitle.Text = "Director";
            txtMemberUser.Text = "newUser";
            txtMemberPass.Text = "newPassword";
        }

        protected void btnMemberSave_Click(object sender, EventArgs e)
        {
            String fn = HttpUtility.HtmlEncode(txtMemberFirstName.Text.ToString());
            String ln = HttpUtility.HtmlEncode(txtMemberLastName.Text.ToString());
            String email = HttpUtility.HtmlEncode(txtMemberEmail.Text.ToString());
            String phone = HttpUtility.HtmlEncode(txtMemberPhone.Text.ToString());
            String gy = HttpUtility.HtmlEncode(txtMemberGradYear.Text.ToString());
            String title = HttpUtility.HtmlEncode(txtMemberTitle.Text.ToString());
            String user = HttpUtility.HtmlEncode(txtMemberUser.Text.ToString());
            String pass = HttpUtility.HtmlEncode(txtMemberPass.Text.ToString());


            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT MemberFirstName FROM Members WHERE MemberEmailAddress = @email";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@email", email);
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
                String sqlQuery2 = "SELECT PMMemberFirstName FROM ProposedMembers WHERE PMMemberEmailAddress = @email";

                // Define the connection to the DB:
                SqlConnection sqlConnect2 =
                new SqlConnection(
                WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

                // Create and Structure the Query Command:
                SqlCommand sqlCommand2 = new SqlCommand();
                sqlCommand.Connection = sqlConnect2;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery2;
                sqlCommand.Parameters.AddWithValue("@mail", email);
                // Execute the Query and Retrieve the Results
                sqlConnect2.Open();
                SqlDataReader queryResults2 = sqlCommand.ExecuteReader();

                if (queryResults2.Read())
                {
                    lblError.Visible = true;
                    sqlConnect2.Close();
                    queryResults2.Close();
                }
                else
                {
                    lblError.Visible = false;
                    sqlConnect2.Close();
                    queryResults2.Close();


                    // Create the Query with Concatenation of Text Boxes:
                    String sqlQuery1 = "INSERT INTO ProposedMembers (PMMemberFirstName, PMMemberLastName, PMMemberEmailAddress, PMMemberPhoneNumber, PMMemberGraduationYear, PMtitle, PMMemberUser, PMMemberPassword)" +
                 " VALUES("
                 + "@fn,"
                + "@ln,"
                + "@email,"
                + "@phone,"
                + "@gy,"
                + "@title,"
                + "@user,"
                + "@pass)";
                    // Define the connection to the DB:
                    SqlConnection sqlConnect1 =
                    new SqlConnection(
                   WebConfigurationManager.ConnectionStrings
                   ["ConnStringOb2"].ConnectionString);
                    // Create and Structure the Query Command:
                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;
                    sqlCommand1.Parameters.AddWithValue("@fn", HttpUtility.HtmlEncode(txtMemberFirstName.Text));
                    sqlCommand1.Parameters.AddWithValue("@ln", HttpUtility.HtmlEncode(txtMemberLastName.Text));
                    sqlCommand1.Parameters.AddWithValue("@email", HttpUtility.HtmlEncode(txtMemberEmail.Text));
                    sqlCommand1.Parameters.AddWithValue("@phone", HttpUtility.HtmlEncode(txtMemberPhone.Text));
                    sqlCommand1.Parameters.AddWithValue("@gy", HttpUtility.HtmlEncode(txtMemberGradYear.Text));
                    sqlCommand1.Parameters.AddWithValue("@title", HttpUtility.HtmlEncode(txtMemberTitle.Text));
                    sqlCommand1.Parameters.AddWithValue("@user", HttpUtility.HtmlEncode(txtMemberUser.Text));
                    sqlCommand1.Parameters.Add(new SqlParameter("@pass", PasswordHash.HashPassword(txtMemberPass.Text)));
                    // Execute the Query and Retrieve the Results
                    sqlConnect1.Open();
                    sqlCommand1.ExecuteScalar(); // Used for other than SELECT Queries
                    sqlConnect1.Close();
                }
            }
        }

        protected void btnMemberClear_Click(object sender, EventArgs e)
        {
            txtMemberFirstName.Text = "";
            txtMemberLastName.Text = "";
            txtMemberEmail.Text = "";
            txtMemberPhone.Text = "";
            txtMemberGradYear.Text = "";
            txtMemberTitle.Text = "";
            txtMemberUser.Text = "";
            txtMemberPass.Text = "";
        }
    }
}