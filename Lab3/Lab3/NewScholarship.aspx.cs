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
    public partial class NewScholarship : System.Web.UI.Page
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

        protected void btnScholarshipPopulate_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtScholarshipTitle.Text = "Good Student Award");
            HttpUtility.HtmlEncode(txtScholarshipAmount.Text = "$123,456,789");
            HttpUtility.HtmlEncode(txtScholarshipYear.Text = "2022");
            HttpUtility.HtmlEncode(txtScholarshipMemberFN.Text = "Bob");
            HttpUtility.HtmlEncode(txtScholarshipMemberLN.Text = "Roberts");
        }

        protected void btnScholarshipSave_Click(object sender, EventArgs e)
        {
            String title = HttpUtility.HtmlEncode(txtScholarshipTitle.Text.ToString());
            String amount = HttpUtility.HtmlEncode(txtScholarshipAmount.Text.ToString());
            String year = HttpUtility.HtmlEncode(txtScholarshipYear.Text.ToString());
            String cfn = HttpUtility.HtmlEncode(txtScholarshipMemberFN.Text.ToString());
            String cln = HttpUtility.HtmlEncode(txtScholarshipMemberLN.Text.ToString());


            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT ScholarshipID FROM Scholarships WHERE ScholarshipName = '" + title + "'";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

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
                // Create the Query with Concatenation of Text Boxes:
                String query = "SELECT MemberID FROM Members WHERE MemberFirstName = '" + cfn + 
                    "' AND MemberLastName = '" + cln + "'";

                // Define the connection to the DB:
                SqlConnection connect =
                new SqlConnection(
                WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

                // Create and Structure the Query Command:
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                // Execute the Query and Retrieve the Results
                connect.Open();
                SqlDataReader results = command.ExecuteReader();

                if (results.Read())
                {
                    lblError.Visible = false;
                    sqlConnect.Close();
                    queryResults.Close();

                    // Create the Query with Concatenation of Text Boxes:
                    String sqlQuery1 = "INSERT INTO Scholarships (ScholarshipName, ScholarshipAmount, ScholarshipYear)" +
                     " VALUES('"
                     + title + "','"
                    + amount + "','"
                    + year + "')";
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
                    // Execute the Query and Retrieve the Results
                    sqlConnect.Open();
                    sqlCommand.ExecuteScalar(); // Used for other than SELECT Queries
                    sqlConnect.Close();

                    String sql = "UPDATE Scholarships SET Scholarships.CoordinatorID=Members.MemberID FROM Members, Scholarships " +
                        "WHERE Members.MemberFirstName ='" + cfn +
                        "' AND Members.MemberLastName = '" + cln + "' AND " +
                        "Scholarships.ScholarshipName ='" + title + "'";
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
                    // Execute the Query and Retrieve the Results
                    connect1.Open();
                    command.ExecuteScalar(); // Used for other than SELECT Queries
                    connect1.Close();
                }
                else
                {
                    lblError.Visible = true;
                    connect.Close();
                    results.Close();

                }
            }

        }

protected void btnScholarshipClear_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtScholarshipTitle.Text = "");
            HttpUtility.HtmlEncode(txtScholarshipAmount.Text = "");
            HttpUtility.HtmlEncode(txtScholarshipYear.Text = "");
            HttpUtility.HtmlEncode(txtScholarshipMemberFN.Text = "");
            HttpUtility.HtmlEncode(txtScholarshipMemberLN.Text = "");
        }
    }
}