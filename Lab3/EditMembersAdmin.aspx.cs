using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class EditMembersAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check Login Status
            if (Session["Admin"] != null)
            {

            }
            else
            {
                Session["MustLogin"] = "You must Login First to Access That Page!";
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void lstbxMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstbxMembers.SelectedIndex;
            String student = lstbxMembers.Items[index].ToString();
            string[] split = student.Split(' ');
            // Create the Query:
            String sqlQuery = "SELECT MemberFirstName, MemberLastName, MemberPhoneNumber, MemberEmailAddress, MemberGraduationYear, Title FROM Members WHERE MemberFirstName ='" + split[0] + "' AND MemberLastName = '" + split[1] + "'";

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

        protected void btnMemberUpdate_Click(object sender, EventArgs e)
        {
            int index = lstbxMembers.SelectedIndex;
            String student = lstbxMembers.Items[index].ToString();
            string[] split = student.Split(' ');

            String fn = HttpUtility.HtmlEncode(txtMemberFirstName.Text.ToString());
            String ln = HttpUtility.HtmlEncode(txtMemberLastName.Text.ToString());
            String email = HttpUtility.HtmlEncode(txtMemberEmail.Text.ToString());
            String phone = HttpUtility.HtmlEncode(txtMemberPhone.Text.ToString());
            String gy = HttpUtility.HtmlEncode(txtMemberGradYear.Text.ToString());
            String title = HttpUtility.HtmlEncode(txtMemberTitle.Text.ToString());

            String sqlBoth = "UPDATE Members SET MemberFirstName=@fn, MemberLastName = @ln" +
                ", MemberEmailAddress=@email, MemberPhoneNumber=@phone," +
                "MemberGraduationYear=@gy, Title=@title " +
                "FROM Members " +
                "WHERE MemberFirstName ='" + split[0] + "' AND MemberLastName = '" + split[1] + "'";
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

            commandBoth.Parameters.AddWithValue("@fn", fn);
            commandBoth.Parameters.AddWithValue("@ln", ln);
            commandBoth.Parameters.AddWithValue("@email", email);
            commandBoth.Parameters.AddWithValue("@phone", phone);
            commandBoth.Parameters.AddWithValue("@gy", gy);
            commandBoth.Parameters.AddWithValue("@title", title);
            // Execute the Query and Retrieve the Results
            connectBoth.Open();
            commandBoth.ExecuteScalar(); // Used for other than SELECT Queries
            connectBoth.Close();

            String sqlBoth1 = "UPDATE Members SET MemberFirstName=@dfn, MemberLastName = @dln" +
           ", MemberEmailAddress=@mail " +
           "FROM Members " +
           "WHERE MemberFirstName ='" + split[0] + "' AND MemberLastName = '" + split[1] + "'";
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

            commandBoth1.Parameters.AddWithValue("@dfn", fn);
            commandBoth1.Parameters.AddWithValue("@dln", ln);
            commandBoth1.Parameters.AddWithValue("@mail", email);
            // Execute the Query and Retrieve the Results
            connectBoth1.Open();
            commandBoth1.ExecuteScalar(); // Used for other than SELECT Queries
            connectBoth1.Close();

            Response.Redirect("EditMembersAdmin.aspx");

        }
    }
}