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

        protected void btnMemberPopulate_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtMemberFirstName.Text = "Bob");
            HttpUtility.HtmlEncode(txtMemberLastName.Text = "Roberts");
            HttpUtility.HtmlEncode(txtMemberEmail.Text = "broberts@jmu.edu");
            HttpUtility.HtmlEncode(txtMemberPhone.Text = "555-111-1112");
            HttpUtility.HtmlEncode(txtMemberGradYear.Text = "1854");
            HttpUtility.HtmlEncode(txtMemberTitle.Text = "Director");
            HttpUtility.HtmlEncode(txtMemberUser.Text = "newUser");
            HttpUtility.HtmlEncode(txtMemberPass.Text = "newPassword");
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
            String sqlQuery = "SELECT MemberFirstName FROM Members WHERE MemberEmailAddress = '" + email + "'";

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
                String sqlQuery1 = "INSERT INTO Members (MemberFirstName, MemberLastName, MemberEmailAddress, MemberPhoneNumber, MemberGraduationYear, title)" +
                 " VALUES('"
                 + fn + "','"
                + ln + "','"
                + email + "','"
                + phone + "','"
                + gy + "','"
                + title + "')";
                // Define the connection to the DB:
                SqlConnection sqlConnect1 =
                new SqlConnection(
               WebConfigurationManager.ConnectionStrings
               ["ConnStringOb1"].ConnectionString);
                // Create and Structure the Query Command:
                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery1;
                sqlCommand.Parameters.AddWithValue("@fn", txtMemberFirstName.Text);
                sqlCommand.Parameters.AddWithValue("@ln", txtMemberLastName.Text);
                sqlCommand.Parameters.AddWithValue("@email", txtMemberEmail.Text);
                sqlCommand.Parameters.AddWithValue("@phone", txtMemberPhone.Text);
                sqlCommand.Parameters.AddWithValue("@gy", txtMemberGradYear.Text);
                sqlCommand.Parameters.AddWithValue("@title", txtMemberTitle.Text);
                sqlCommand.Parameters.AddWithValue("@user", txtMemberUser.Text);
                sqlCommand.Parameters.Add(new SqlParameter("@pass", PasswordHash.HashPassword(txtMemberPass.Text)));
                // Execute the Query and Retrieve the Results
                sqlConnect.Open();
                sqlCommand.ExecuteScalar(); // Used for other than SELECT Queries
                sqlConnect.Close();
            }
            
        }

        protected void btnMemberClear_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode( txtMemberFirstName.Text = "");
            HttpUtility.HtmlEncode(txtMemberLastName.Text = "");
            HttpUtility.HtmlEncode(txtMemberEmail.Text = "");
            HttpUtility.HtmlEncode(txtMemberPhone.Text = "");
            HttpUtility.HtmlEncode(txtMemberGradYear.Text = "");
            HttpUtility.HtmlEncode(txtMemberTitle.Text = "");
            HttpUtility.HtmlEncode(txtMemberUser.Text = "");
            HttpUtility.HtmlEncode(txtMemberPass.Text = "");
        }
    }
}