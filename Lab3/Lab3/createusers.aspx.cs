using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class createusers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
                

    

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
                    try
                    {
                        System.Data.SqlClient.SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString.ToString());
                         lblStatus.Text = "Database Connection Successful";

                        sc.Open();

                        System.Data.SqlClient.SqlCommand createUser = new System.Data.SqlClient.SqlCommand();
                        createUser.Connection = sc;
                        // INSERT USER RECORD
                        createUser.CommandText = "INSERT INTO ADMIN (Username, Pass) VALUES (@Username, @Password)";
                        createUser.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));
                        createUser.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(txtPassword.Text))); // hash entered password
                        createUser.ExecuteNonQuery();
                    }
                    catch
                    {
                        lblStatus.Text = "Database Error - User not committed.";
                    }
            
    }

        protected void lnkAnother_Click(object sender, EventArgs e)
        {
        HttpUtility.HtmlEncode(txtUsername.Enabled = true);
        HttpUtility.HtmlEncode(txtPassword.Enabled = true);
        HttpUtility.HtmlEncode(btnSubmit.Enabled = true);
        HttpUtility.HtmlEncode(lnkAnother.Visible = false);
        HttpUtility.HtmlEncode(txtUsername.Text = "");
        HttpUtility.HtmlEncode(txtPassword.Text = "");
    }
    }
}