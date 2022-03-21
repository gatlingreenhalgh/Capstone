using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;

namespace Lab2
{
    public partial class LoginPage : System.Web.UI.Page
    {

        private void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["Member"] != null)
            {
                MasterPageFile = "~/MemberMaster.Master";
            }
            else if (Session["Student"] != null)
            {
                MasterPageFile = "~/StudentMaster.Master";
            }
            else
            {
                MasterPageFile = "~/Lab3Master.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                if (Session["MustLogin"] != null)
                {
                    HttpUtility.HtmlEncode(lblStatus.Text = Session["MustLogin"].ToString());
                }
                else if (Session["Member"] != null)
                {
                   HttpUtility.HtmlEncode( lblStatus.Text = "You are Logged In");
                }
                else
                {
                    HttpUtility.HtmlEncode(lblStatus.Text = "Please Login to Continue :)");
                }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String querysql = "SELECT Pass FROM ADMIN WHERE Username = @Username";

            SqlConnection connectsql = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

            SqlCommand commandsql = new SqlCommand(querysql, connectsql);

            commandsql.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));

            connectsql.Open();

            SqlDataReader readersql = commandsql.ExecuteReader(); // create a reader

            if (readersql.HasRows) // if the username exists, it will continue
            {
                while (readersql.Read()) // this will read the single record that matches the entered username
                {
                    string storedHash = readersql["Pass"].ToString(); // store the database password into this variable

                    if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash)) // if the entered password matches what is stored, it will show success
                    {
                        Session["Admin"] = txtUsername.Text;
                        Response.Redirect("Home.aspx");
                        connectsql.Close();
                    }
                }
            }
            else { 
                String sqlQuery = "SELECT MemberPassword FROM Members WHERE MemberUser = @Username";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);

            sqlCommand.Parameters.Add(new SqlParameter("@Username", txtUsername.Text)); 

            sqlConnect.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader(); // create a reader

                if (reader.HasRows) // if the username exists, it will continue
                {
                    while (reader.Read()) // this will read the single record that matches the entered username
                    {
                        string storedHash = reader["MemberPassword"].ToString(); // store the database password into this variable

                        if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash)) // if the entered password matches what is stored, it will show success
                        {
                            HttpUtility.HtmlEncode(Session["Member"] = txtUsername.Text);
                            Response.Redirect("Home.aspx");
                            sqlConnect.Close();
                        }
                    }
                }
                else
                {
                    sqlConnect.Close();

                    String query = "SELECT StudentPass FROM Students WHERE StudentUser = @student";

                    SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

                    SqlCommand command = new SqlCommand(query, connect);

                    command.Parameters.Add(new SqlParameter("@student", txtUsername.Text));

                    connect.Open();

                    SqlDataReader sqlreader = command.ExecuteReader(); // create a reader

                    if (sqlreader.HasRows) // if the username exists, it will continue
                    {
                        while (sqlreader.Read()) // this will read the single record that matches the entered username
                        {
                            string storedStudentHash = reader["StudentPass"].ToString(); // store the database password into this variable

                            if (PasswordHash.ValidatePassword(txtPassword.Text, storedStudentHash)) // if the entered password matches what is stored, it will show success
                            {
                                HttpUtility.HtmlEncode(Session["Student"] = txtUsername.Text);
                                Response.Redirect("Home.aspx");
                                connect.Close();
                            }
                        }
                    }
                    else
                    {
                        connect.Close();
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Font.Bold = true;
                        lblStatus.Text = "Email and/or Password was Incorrect. Try Again!";
                    }
                }
            }
        }
    }
}