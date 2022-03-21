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
    public partial class Scholarships : System.Web.UI.Page
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


        protected void lstbxScholarships_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstbxScholarships.SelectedIndex;
            String scholarship = lstbxScholarships.Items[index].ToString();
            // Create the Query:
            String sqlQuery ="SELECT ScholarshipName, ScholarshipAmount, ScholarshipYear FROM Scholarships WHERE ScholarshipName ='" + scholarship + "'";

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
                HttpUtility.HtmlEncode(txtPostedScholarshipTitle.Text = queryResults["ScholarshipName"].ToString());
                HttpUtility.HtmlEncode(txtPostedScholarshipAmount.Text = queryResults["ScholarshipAmount"].ToString());
                HttpUtility.HtmlEncode(txtPostedScholarshipYear.Text = queryResults["ScholarshipYear"].ToString());
            }
            
            sqlConnect.Close();
            queryResults.Close();

            // Create the Query:
            String query = "SELECT MemberFirstName, MemberLastName From Members, Scholarships WHERE Members.MemberID = Scholarships.CoordinatorID" +
                " AND ScholarshipName ='" + scholarship + "'";

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
                HttpUtility.HtmlEncode(txtScholarshipMemberFN.Text = results["MemberFirstName"].ToString());
                HttpUtility.HtmlEncode(txtScholarshipMemberLN.Text = results["MemberLastName"].ToString());
            }

            connect.Close();
            results.Close();
        }

        protected void btnApplySave_Click(object sender, EventArgs e)
        {
            String s = HttpUtility.HtmlEncode(txtPostedScholarshipTitle.Text.ToString());
            String fn = HttpUtility.HtmlEncode(txtApplyFirstName.Text.ToString());
            String ln = HttpUtility.HtmlEncode(txtApplyLastName.Text.ToString());
            String t = HttpUtility.HtmlEncode(txtApplyText.Text.ToString());
            String d = HttpUtility.HtmlEncode(txtApplyDate.Text.ToString());
            String rs = "Not Reviewed";
            String rd = "Not Reviewed";


            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT ApplicationID FROM Applications, Scholarships, Students " +
                        "WHERE Applications.StudentID = Students.StudentID " +
                        "AND Applications.ScholarshipID = Scholarships.ScholarshipID " +
                        "AND FirstName = '" + fn + "' " +
                        "AND LastName = '" + ln + "' " + 
                        "AND ScholarshipName = '" + s + "'";

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
                String query = "SELECT StudentID FROM Students WHERE FirstName = '" + fn + "' AND Lastname ='" + ln + "'";

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
                    String sqlQuery1 = "INSERT INTO Applications (ApplicationDate, ApplicationText, ReviewDate, ReviewStatus)" +
                     " VALUES('"
                    + d + "', '"
                    + t + "', '"
                    + rd + "', '"
                    + rs + "')";
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

                    String sql = "UPDATE Applications SET Applications.ScholarshipID =Scholarships.ScholarshipID FROM Scholarships " +
                        "WHERE Applications.ApplicationText ='" + t +
                        "' AND Scholarships.ScholarshipName = '" + s + "'";
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

                    String sqlBoth = "UPDATE Applications SET Applications.StudentID=Students.StudentID FROM Students " +
                        "WHERE Applications.ApplicationText ='" + t +
                        "' AND Students.FirstName = '" + fn +
                        "' AND Students.LastName = '" + ln + "'";
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

        protected void btnApplyPopulate_Click(object sender, EventArgs e)
        {
           HttpUtility.HtmlEncode(txtApplyFirstName.Text = "Joe");
            HttpUtility.HtmlEncode(txtApplyLastName.Text = "Schmoe");
            HttpUtility.HtmlEncode(txtApplyText.Text = "Give me the scholarship");
            HttpUtility.HtmlEncode(txtApplyDate.Text = "02/05/2022");
        }

        protected void btnApplyClear_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtApplyFirstName.Text = "");
            HttpUtility.HtmlEncode(txtApplyLastName.Text = "");
            HttpUtility.HtmlEncode(txtApplyText.Text = "");
            HttpUtility.HtmlEncode(txtApplyDate.Text = "");
        }
    }
}