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
    public partial class Company : System.Web.UI.Page
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

        protected void btnCompanyPopulate_Click(object sender, EventArgs e)
        {
            txtCompanyName.Text = "Workplace Inc.";
            txtCompanyAddress.Text = "2245 West Landing Drive";
            txtCompanyPhone.Text = "555-096-6447";
            txtContactFirstName.Text = "John";
            txtContactLastName.Text = "Workman";
            txtContactPhone.Text = "555-789-3893";
            txtContactEmail.Text = "john.workman@workplace.com";
        }

        protected void btnCompanyClear_Click(object sender, EventArgs e)
        {
            txtCompanyName.Text = "";
            txtCompanyAddress.Text = "";
            txtCompanyPhone.Text = "";
            txtContactFirstName.Text = "";
            txtContactLastName.Text = "";
            txtContactPhone.Text = "";
            txtContactEmail.Text = "";

        }

        protected void btnCompanySave_Click(object sender, EventArgs e)
        {
            String cn = HttpUtility.HtmlEncode(txtCompanyName.Text.ToString());
            String add = HttpUtility.HtmlEncode(txtCompanyAddress.Text.ToString());
            String phone = HttpUtility.HtmlEncode(txtCompanyPhone.Text.ToString());
            String cfn = HttpUtility.HtmlEncode(txtContactFirstName.Text.ToString());
            String cln = HttpUtility.HtmlEncode(txtContactLastName.Text.ToString());
            String cEmail = HttpUtility.HtmlEncode(txtContactEmail.Text.ToString());
            String cPhone = HttpUtility.HtmlEncode(txtContactPhone.Text.ToString());


            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT CompanyAddress FROM Company WHERE CompanyAddress =@add";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@add", add);
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
                // Create the Query with Concatenation of Text Boxes:
                String query = "SELECT ContactEmail FROM CompanyContact WHERE ContactEmail =@cEmail";

                // Define the connection to the DB:
                SqlConnection connect =
                new SqlConnection(
                WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

                // Create and Structure the Query Command:
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@cEmail", cEmail);
                // Execute the Query and Retrieve the Results
                connect.Open();
                SqlDataReader results = command.ExecuteReader();

                if (results.Read())
                {
                    lblError.Visible = true;
                    connect.Close();
                    results.Close();
                }
                else
                {
                    lblError.Visible = false;
                    sqlConnect.Close();
                    queryResults.Close();

                    // Create the Query with Concatenation of Text Boxes:
                    String sqlQuery1 = "INSERT INTO Company (CompanyName, CompanyAddress, CompanyPhone)" +
                     " VALUES(@cn, @addy, @phone)";
                    // Define the connection to the DB:
                    SqlConnection sqlConnect1 =
                    new SqlConnection(
                   WebConfigurationManager.ConnectionStrings
                   ["ConnStringOb1"].ConnectionString);
                    // Create and Structure the Query Command:
                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;
                    sqlCommand1.Parameters.AddWithValue("@cn", cn);
                    sqlCommand1.Parameters.AddWithValue("@addy", add);
                    sqlCommand1.Parameters.AddWithValue("@phone", phone);
                    // Execute the Query and Retrieve the Results
                    sqlConnect1.Open();
                    sqlCommand1.ExecuteScalar(); // Used for other than SELECT Queries
                    sqlConnect1.Close();

                    String sql = "INSERT INTO CompanyContact (ContactFirstName, ContactLastName, ContactPhone, ContactEmail)" +
                        " VALUES(@cfn, @cln, @cPhone, @cemail)";
                    // Define the connection to the DB:
                    SqlConnection connect1 =
                    new SqlConnection(
                   WebConfigurationManager.ConnectionStrings
                   ["ConnStringOb1"].ConnectionString);
                    // Create and Structure the Query Command:
                    SqlCommand Command = new SqlCommand();
                    command.Connection = connect1;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@cfn", cfn);
                    command.Parameters.AddWithValue("@cln", cln);
                    command.Parameters.AddWithValue("@cPhone", cPhone);
                    command.Parameters.AddWithValue("@mail", cEmail);
                    // Execute the Query and Retrieve the Results
                    connect1.Open();
                    command.ExecuteScalar(); // Used for other than SELECT Queries
                    connect1.Close();

                    String sqlBoth = "UPDATE CompanyContact SET CompanyContact.CompanyID=Company.CompanyID FROM Company " +
                        "WHERE CompanyContact.ContactFirstName =@cFN" +
                        " AND Company.CompanyAddress =@aDD";
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
                    commandBoth.Parameters.AddWithValue("@cFN",cfn);
                    commandBoth.Parameters.AddWithValue("@aDD", add);
                    // Execute the Query and Retrieve the Results
                    connectBoth.Open();
                    commandBoth.ExecuteScalar(); // Used for other than SELECT Queries
                    connectBoth.Close();
                
                }
            }
        }
    }
}