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
    public partial class PostedJobs : System.Web.UI.Page
    {

        private void Page_PreInit(object sender, EventArgs e)
        {
            //Choose MasterPage
            if (Session["Student"] != null)
            {
                MasterPageFile = "~/StudentMaster.Master";
            }
            else if (Session["Member"] != null)
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
            if (Session["Member"] != null || Session["Student"] != null || Session["Admin"] != null)
            {

            }
            else
            {
                Session["MustLogin"] = "You must Login First to Access That Page!";
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void lstbxJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ddlJobs.SelectedIndex;
            String job = ddlJobs.Items[index].ToString();
            // Create the Query:
            String sqlQuery = "SELECT JobTitle, JobDescription, StartDate FROM Jobs WHERE JobTitle ='" + job + "'";

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
                HttpUtility.HtmlEncode( txtPostedJobTitle.Text = queryResults["JobTitle"].ToString());
                HttpUtility.HtmlEncode(txtPostedJobDescription.Text = queryResults["JobDescription"].ToString());
                HttpUtility.HtmlEncode(txtPostedStartDate.Text = queryResults["StartDate"].ToString());
            }

            sqlConnect.Close();
            queryResults.Close();

            // Create the Query:
            String querysql = "SELECT CompanyName From Company, Jobs WHERE Company.CompanyID = Jobs.CompanyID" +
                " AND JobTitle ='" + job + "'";

            // Define the connection to the DB:
            SqlConnection connectsql =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings
            ["ConnStringOb1"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand commandsql = new SqlCommand();
            commandsql.Connection = connectsql;
            commandsql.CommandType = CommandType.Text;
            commandsql.CommandText = querysql;
            // Execute the Query and Retrieve the Results
            connectsql.Open();
            SqlDataReader resultssql = commandsql.ExecuteReader();
            // Read the results and populate the ListBox
            while (resultssql.Read())
            {
                txtPostedCompany.Text = resultssql["CompanyName"].ToString();
            }

            connectsql.Close();
            resultssql.Close();

            // Create the Query:
            String query = "SELECT ContactFirstName + ' ' + ContactLastName AS ContactName, ContactPhone From CompanyContact, Jobs WHERE CompanyContact.CompanyID = Jobs.CompanyID" +
                " AND JobTitle ='" + job + "'";

            // Define the connection to the DB:
            SqlConnection connect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings
            ["ConnStringOb1"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand command = new SqlCommand();
            command.Connection = connect;
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            // Execute the Query and Retrieve the Results
            connect.Open();
            SqlDataReader results = command.ExecuteReader();
            // Read the results and populate the ListBox
            while (results.Read())
            {
                HttpUtility.HtmlEncode(txtPostedContactName.Text = results["ContactName"].ToString());
                HttpUtility.HtmlEncode(txtPostedContactPhone.Text = results["ContactPhone"].ToString());
            }

            connect.Close();
            results.Close();
        }
    }
    }
