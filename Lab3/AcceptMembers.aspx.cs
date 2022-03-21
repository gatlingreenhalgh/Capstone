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
    public partial class AcceptMembers : System.Web.UI.Page
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

        protected void btnAcceptMember_Click(object sender, EventArgs e)
        {
            int index = lstbxMemberAccounts.SelectedIndex;
            String application = lstbxMemberAccounts.Items[index].ToString();
            string[] split = application.Split(' ');

            String querysql = "SELECT PMMemberFirstName, PMMemberLastName, PMMemberEmailAddress, PMMemberUser, PMMemberPassword, PMMemberPhoneNumber, PMMemberGraduationYear, PMTitle FROM ProposedMembers WHERE PMMemberFirstName=@fn AND PMMemberLastName=@ln";

            SqlConnection connectsql = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

            SqlCommand commandsql = new SqlCommand(querysql, connectsql);
            commandsql.Parameters.AddWithValue("@fn", split[0]);
            commandsql.Parameters.AddWithValue("@ln", split[1]);

            connectsql.Open();

            SqlDataReader readersql = commandsql.ExecuteReader(); // create a reader

            if (readersql.HasRows) // if the username exists, it will continue
            {
                while (readersql.Read()) // this will read the single record that matches the entered username
                {
                    String fn = readersql[0].ToString();
                    String ln = readersql[1].ToString();
                    String email = readersql[2].ToString();
                    String user = readersql[3].ToString();
                    String pass = readersql[4].ToString();
                    String phone = readersql[5].ToString();
                    String gradyear = readersql[6].ToString();
                    String title = readersql[7].ToString();

                    // Create the Query with Concatenation of Text Boxes:
                    String sqlQuery = "INSERT INTO Members(MemberFirstName, MemberLastName, MemberEmailAddress, MemberUser, MemberPassword) "
                        + "VALUES(@fn, @ln, @email, @user, @pass)";

                    // Define the connection to the DB:
                    SqlConnection sqlConnect =
                    new SqlConnection(
                    WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

                    // Create and Structure the Query Command:
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;
                    sqlCommand.Parameters.AddWithValue("@fn", fn);
                    sqlCommand.Parameters.AddWithValue("@ln", ln);
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@user", user);
                    sqlCommand.Parameters.AddWithValue("@pass", pass);
                    // Execute the Query and Retrieve the Results
                    sqlConnect.Open();
                    sqlCommand.ExecuteScalar();
                    sqlConnect.Close();

                    // Create the Query with Concatenation of Text Boxes:
                    String sqlQuery1 = "INSERT INTO Members(MemberFirstName, MemberLastName, MemberEmailAddress, MemberUser, MemberPhoneNumber, MemberGraduationYear, Title) "
                        + "VALUES(@fn, @ln, @email, @user, @phone, @gradyear, @title)";

                    // Define the connection to the DB:
                    SqlConnection sqlConnect1 =
                    new SqlConnection(
                    WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

                    // Create and Structure the Query Command:
                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;
                    sqlCommand1.Parameters.AddWithValue("@fn", fn);
                    sqlCommand1.Parameters.AddWithValue("@ln", ln);
                    sqlCommand1.Parameters.AddWithValue("@email", email);
                    sqlCommand1.Parameters.AddWithValue("@user", user);
                    sqlCommand1.Parameters.AddWithValue("@phone", phone);
                    sqlCommand1.Parameters.AddWithValue("@gradyear", gradyear);
                    sqlCommand1.Parameters.AddWithValue("@title", title);
                    // Execute the Query and Retrieve the Results
                    sqlConnect1.Open();
                    sqlCommand1.ExecuteScalar();
                    sqlConnect1.Close();

                }
                connectsql.Close();
                denyMember();
            }
        }

        protected void denyMember()
        {
            int index = lstbxMemberAccounts.SelectedIndex;
            String application = lstbxMemberAccounts.Items[index].ToString();
            string[] split = application.Split(' ');

            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "DELETE FROM ProposedMembers WHERE PMMemberFirstName = @fn AND PMMemberLastName= @ln";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@fn", split[0]);
            sqlCommand.Parameters.AddWithValue("@ln", split[1]);
            // Execute the Query and Retrieve the Results
            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();
            Response.Redirect("AcceptMembers.aspx");
        }

        protected void btnDenyMember_Click(object sender, EventArgs e)
        {
            denyMember();
        }
    }
}