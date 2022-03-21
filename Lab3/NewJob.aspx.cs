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
    public partial class NewJob : System.Web.UI.Page
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

        protected void btnJobPopulate_Click(object sender, EventArgs e)
        {
            txtJobTitle.Text = "Employee";
            txtHiringCompany.Text = "Workplace Inc.";
            txtJobDescription.Text = "The job is good and you will work hard to make money from the company";
            txtJobStart.Text = "06/15/2022";


        }

        protected void btnJobSave_Click(object sender, EventArgs e)
        {
            String title = HttpUtility.HtmlEncode(txtJobTitle.Text.ToString());
            String desc = HttpUtility.HtmlEncode(txtJobDescription.Text.ToString());
            String start = HttpUtility.HtmlEncode(txtJobStart.Text.ToString());
            String hc = HttpUtility.HtmlEncode(txtHiringCompany.Text.ToString());


            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT JobID FROM Jobs WHERE JobDescription =@desc";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@desc", desc);
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
                String query = "SELECT CompanyID FROM Company WHERE CompanyName =@hc";

                // Define the connection to the DB:
                SqlConnection connect =
                new SqlConnection(
                WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

                // Create and Structure the Query Command:
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@hc", hc);
                // Execute the Query and Retrieve the Results
                connect.Open();
                SqlDataReader results = command.ExecuteReader();

                if (results.Read())
                {
                    lblError.Visible = false;
                    sqlConnect.Close();
                    queryResults.Close();

                    // Create the Query with Concatenation of Text Boxes:
                    String sqlQuery1 = "INSERT INTO jobs (JobTitle, JobDescription, StartDate)" +
                     " VALUES(@title, @dESC, @start)";
                    // Define the connection to the DB:
                    SqlConnection sqlConnects =
                    new SqlConnection(
                   WebConfigurationManager.ConnectionStrings
                   ["ConnStringOb1"].ConnectionString);
                    // Create and Structure the Query Command:
                    SqlCommand sqlCommands = new SqlCommand();
                    sqlCommands.Connection = sqlConnects;
                    sqlCommands.CommandType = CommandType.Text;
                    sqlCommands.CommandText = sqlQuery1;
                    sqlCommands.Parameters.AddWithValue("@title", title);
                    sqlCommands.Parameters.AddWithValue("@dESC", desc);
                    sqlCommands.Parameters.AddWithValue("@start", start);
                    // Execute the Query and Retrieve the Results
                    sqlConnects.Open();
                    sqlCommands.ExecuteScalar(); // Used for other than SELECT Queries
                    sqlConnects.Close();

                    String sql = "UPDATE Jobs SET Jobs.CompanyID=Company.CompanyID FROM Company " +
                        "WHERE Company.CompanyName =@hC" +
                        " AND Jobs.JobTitle =@t";
                    // Define the connection to the DB:
                    SqlConnection connect1 =
                    new SqlConnection(
                   WebConfigurationManager.ConnectionStrings
                   ["ConnStringOb1"].ConnectionString);
                    // Create and Structure the Query Command:
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connect1;
                    command1.CommandType = CommandType.Text;
                    command1.CommandText = sql;
                    command1.Parameters.AddWithValue("hC", hc);
                    command1.Parameters.AddWithValue("@t", title);
                    // Execute the Query and Retrieve the Results
                    connect1.Open();
                    command1.ExecuteScalar(); // Used for other than SELECT Queries
                    connect1.Close();

                    String sqlBoth = "UPDATE Jobs SET Jobs.ContactID=Company.ContactID FROM Company, CompanyContact " +
                        "WHERE CompanyContact.CompanyID = Company.CompanyID AND " +
                        "Jobs.CompanyId = Company.CompanyID";
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
                    // Execute the Query and Retrieve the Results
                    connectBoth.Open();
                    commandBoth.ExecuteScalar(); // Used for other than SELECT Queries
                    connectBoth.Close();
                }
                else
                {
                    lblError.Visible = true;
                    connect.Close();
                    results.Close();

                }
            }

        }

        protected void btnJobClear_Click(object sender, EventArgs e)
        {
            txtJobTitle.Text = "";
            txtHiringCompany.Text = "";
            txtJobDescription.Text = "";
            txtJobStart.Text = "";
        }
    }
}