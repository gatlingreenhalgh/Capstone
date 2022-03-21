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
    public partial class EditMember : System.Web.UI.Page
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

        protected void btnMemberUpdate_Click(object sender, EventArgs e)
        {
            
            String user = Session["Member"].ToString();
            String logFN = Session["LoggedInFN"].ToString();
            String logLN = Session["LoggedInLN"].ToString();
            String mfn = HttpUtility.HtmlEncode(txtMemberFirstName.Text);
            String mln = HttpUtility.HtmlEncode(txtMemberLastName.Text);
            String mEmail = HttpUtility.HtmlEncode(txtMemberEmail.Text);
            String phone = HttpUtility.HtmlEncode(txtMemberPhone.Text);
            String grad = HttpUtility.HtmlEncode(txtMemberGradYear.Text);
            String title = HttpUtility.HtmlEncode(txtMemberTitle.Text);

            String sqlBoth = "UPDATE Members SET MemberFirstName=@mfn, MemberLastName=@mln" +
                ", MemberEmailAddress=@mEmail, MemberPhoneNumber=@phone" +  
                ", MemberGraduationYear=@grad, Title=@title " +
                "FROM Members " +
                "WHERE MemberUser ='" + user + "' AND MemberFirstName='" + logFN + "' AND MemberLastName='" + logLN + "'";
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
            commandBoth.Parameters.AddWithValue("@mfn", mfn);
            commandBoth.Parameters.AddWithValue("@mln", mln);
            commandBoth.Parameters.AddWithValue("@mEmail", mEmail);
            commandBoth.Parameters.AddWithValue("@phone", phone);
            commandBoth.Parameters.AddWithValue("@grad", grad);
            commandBoth.Parameters.AddWithValue("@title", title);
            // Execute the Query and Retrieve the Results
            connectBoth.Open();
            commandBoth.ExecuteReader(); // Used for other than SELECT Queries
            connectBoth.Close();

            String sqlBoth1 = "UPDATE Members SET MemberFirstName=@fn, MemberLastName=@ln" +
               ", MemberEmailAddress=@email " +
               "WHERE MemberUser ='" + user + "' AND MemberFirstName='" + logFN + "' AND MemberLastName='" + logLN + "'";
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
            commandBoth1.Parameters.AddWithValue("@fn", mfn);
            commandBoth1.Parameters.AddWithValue("@ln", mln);
            commandBoth1.Parameters.AddWithValue("@email", mEmail);
            // Execute the Query and Retrieve the Results
            connectBoth1.Open();
            commandBoth1.ExecuteReader(); // Used for other than SELECT Queries
            connectBoth1.Close();

            Response.Redirect("EditMember.aspx");
        }

        protected void viewInfo()
        {
            // Create the Query:
            String sqlQuery = "SELECT MemberFirstName, MemberLastName, MemberPhoneNumber, MemberEmailAddress, MemberGraduationYear, Title FROM Members WHERE MemberUser ='" + Session["Member"].ToString() + "'";

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
                txtMemberFirstName.Text = queryResults["MemberFirstName"].ToString();
                txtMemberLastName.Text = queryResults["MemberLastName"].ToString();
                txtMemberEmail.Text = queryResults["MemberEmailAddress"].ToString();
                txtMemberPhone.Text = queryResults["MemberPhoneNumber"].ToString();
                txtMemberGradYear.Text = queryResults["MemberGraduationYear"].ToString();
                txtMemberTitle.Text = queryResults["Title"].ToString();
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