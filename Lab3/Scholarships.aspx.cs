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
                if (Session["Student"] != null)
                {

                    // Create the Query with Concatenation of Text Boxes:
                    String query = "SELECT FirstName, LastName FROM Students WHERE StudentUser='" + Session["Student"].ToString() + "'";

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
                    while (results.Read())
                    {
                        txtApplyFirstName.Text = results["FirstName"].ToString();
                        txtApplyLastName.Text = results["LastName"].ToString();
                    }
                    DateTime thisDay = DateTime.Today;
                    txtApplyDate.Text = thisDay.ToString("d");
                }
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
                txtPostedScholarshipTitle.Text = queryResults["ScholarshipName"].ToString();
                txtPostedScholarshipAmount.Text = queryResults["ScholarshipAmount"].ToString();
                txtPostedScholarshipYear.Text = queryResults["ScholarshipYear"].ToString();
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
                txtScholarshipMemberFN.Text = results["MemberFirstName"].ToString();
                txtScholarshipMemberLN.Text = results["MemberLastName"].ToString();
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
            String rs = HttpUtility.HtmlEncode("Not Reviewed");
            String rd = HttpUtility.HtmlEncode("Not Reviewed");


            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "SELECT ApplicationID FROM Applications, Scholarships, Students " +
                        "WHERE Applications.StudentID = Students.StudentID " +
                        "AND Applications.ScholarshipID = Scholarships.ScholarshipID " +
                        "AND FirstName =@fn " +
                        "AND LastName =@ln " + 
                        "AND ScholarshipName =@s";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@fn", fn);
            sqlCommand.Parameters.AddWithValue("@ln", ln);
            sqlCommand.Parameters.AddWithValue("@s", s);
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
                    lblError.Visible = false;
                    sqlConnect.Close();
                    queryResults.Close();

                    // Create the Query with Concatenation of Text Boxes:
                    String sqlQuery1 = "INSERT INTO Applications (ApplicationDate, ApplicationText, ReviewDate, ReviewStatus)" +
                     " VALUES(@d, @t, @rd, @rs)";
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
                    sqlCommand1.Parameters.AddWithValue("@d", d);
                    sqlCommand1.Parameters.AddWithValue("@t", t);
                    sqlCommand1.Parameters.AddWithValue("@rd", rd);
                    sqlCommand1.Parameters.AddWithValue("@rs", rs);
                // Execute the Query and Retrieve the Results
                    sqlConnect1.Open();
                    sqlCommand1.ExecuteScalar(); // Used for other than SELECT Queries
                    sqlConnect1.Close();

                    String sql = "UPDATE Applications SET Applications.ScholarshipID =Scholarships.ScholarshipID FROM Scholarships " +
                        "WHERE Applications.ApplicationText =@t" +
                        " AND Scholarships.ScholarshipName =@s";
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
                    command1.Parameters.AddWithValue("@s", s);
                    command1.Parameters.AddWithValue("@t", t);
                    
                    // Execute the Query and Retrieve the Results
                    connect1.Open();
                    command1.ExecuteScalar(); // Used for other than SELECT Queries
                    connect1.Close();

                    String sqlBoth = "UPDATE Applications SET Applications.StudentID=Students.StudentID FROM Students " +
                        "WHERE Applications.ApplicationText =@t" +
                        " AND Students.FirstName =@fn" +
                        " AND Students.LastName =@ln";
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
                    commandBoth.Parameters.AddWithValue("@t", t);
                    // Execute the Query and Retrieve the Results
                    connectBoth.Open();
                    commandBoth.ExecuteScalar(); // Used for other than SELECT Queries
                    connectBoth.Close();
                }
            
        }

        protected void btnApplyPopulate_Click(object sender, EventArgs e)
        {
            txtApplyFirstName.Text = "Joe";
            txtApplyLastName.Text = "Schmoe";
            txtApplyText.Text = "Give me the scholarship";
            txtApplyDate.Text = "02/05/2022";
        }

        protected void btnApplyClear_Click(object sender, EventArgs e)
        {
            txtApplyFirstName.Text = "";
            txtApplyLastName.Text = "";
            txtApplyText.Text = "";
            txtApplyDate.Text = "";
        }
    }
}