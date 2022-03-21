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
    public partial class ApplicationReview : System.Web.UI.Page
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

        protected void lstbxScholarships_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstbxScholarships.SelectedIndex;
            String application = lstbxScholarships.Items[index].ToString();
            string[] split = application.Split(' ');
            // Create the Query:
            String sqlQuery = "SELECT ScholarshipName, ScholarshipAmount, ScholarshipYear FROM Students, Scholarships, Applications WHERE FirstName ='" + split[0] + "' AND LastName = '" + split[1] + "' AND Scholarships.ScholarshipID=Applications.ScholarshipID AND Students.StudentID=Applications.StudentID";

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
               HttpUtility.HtmlEncode (txtReviewScholarshipTitle.Text = queryResults["ScholarshipName"].ToString());
               HttpUtility.HtmlEncode( txtReviewScholarshipAmount.Text = queryResults["ScholarshipAmount"].ToString());
               HttpUtility.HtmlEncode( txtReviewScholarshipYear.Text = queryResults["ScholarshipYear"].ToString());
            }

            sqlConnect.Close();
            queryResults.Close();

            String theQuery = "SELECT FirstName, LastName From Students, Applications WHERE Students.StudentID = Applications.StudentID AND FirstName='"
                       + split[0] + "' AND LastName = '" + split[1] + "'";

            // Define the connection to the DB:
            SqlConnection sqlConnection =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand theCommandsql = new SqlCommand();
            theCommandsql.Connection = sqlConnection;
            theCommandsql.CommandType = CommandType.Text;
            theCommandsql.CommandText = theQuery;
            // Execute the Query and Retrieve the Results
            sqlConnection.Open();
            SqlDataReader theResultssql = theCommandsql.ExecuteReader();
            while (theResultssql.Read())
            {
                HttpUtility.HtmlEncode(txtScholarshipStudentFN.Text = theResultssql["FirstName"].ToString());
                HttpUtility.HtmlEncode(txtScholarshipStudentLN.Text = theResultssql["LastName"].ToString());
            }
            sqlConnection.Close();
                theResultssql.Close();
            }

        protected void btnApplyPopulate_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtAwardFirstName.Text = "Jeremy");
            HttpUtility.HtmlEncode(txtAwardLastName.Text = "Ezell");
            HttpUtility.HtmlEncode(txtAwardDate.Text = "02/09/2022");
        }

        protected void btnApplySave_Click(object sender, EventArgs e)
        {

            int index = lstbxScholarships.SelectedIndex;
            String application = lstbxScholarships.Items[index].ToString();
            string[] split = application.Split(' ');

            String fn = HttpUtility.HtmlEncode(txtAwardFirstName.Text.ToString());
            String ln = HttpUtility.HtmlEncode(txtAwardLastName.Text.ToString());
            String rs = HttpUtility.HtmlEncode(rbAwardDecison.SelectedValue);
            String rd = HttpUtility.HtmlEncode(txtAwardDate.Text.ToString());

            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT MemberID From Members WHERE MemberFirstName = '" + fn + "' " +
                        "AND MemberLastName = '" + ln + "' ";

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
                String sqlBoth = "UPDATE Applications SET ReviewStatus='" + rs + "', ReviewDate = '" + rd + "' " +
                        "FROM Applications, Students, Scholarships " +
                       "WHERE Applications.StudentID=Students.StudentID AND Applications.ScholarshipID = Scholarships.ScholarshipID AND " +
                       "FirstName = '" + txtScholarshipStudentFN.Text +
                       "' AND LastName = '" + txtScholarshipStudentLN.Text + "' " +
                       "AND ScholarshipName = '" + txtReviewScholarshipTitle.Text + "'";
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
                sqlConnect.Close();
                queryResults.Close();

            }
        }
        protected void btnApplyClear_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtAwardFirstName.Text = "");
            HttpUtility.HtmlEncode(txtAwardLastName.Text = "");
            HttpUtility.HtmlEncode(txtAwardDate.Text = "");
        }
    }
}