using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab2
{
    public partial class StudentMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Create footer name
            if (Session["Member"] != null)
            {
                String sqlQuery = "SELECT MemberFirstName, MemberLastName FROM Members WHERE MemberEmailAddress=@Member";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);


                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddWithValue("@Member", Session["Member"].ToString());
                // Execute the Query and Retrieve the Results
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();

                if (queryResults.Read())
                {
                    lblLoggedInUser.Text = queryResults[0].ToString() + " " + queryResults[1].ToString();
                    sqlConnect.Close();
                }
            }
            else if (Session["Student"] != null)
            {

                String query = "SELECT FirstName, LastName FROM Students WHERE EmailAddress=@Student";

                SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

                SqlCommand command = new SqlCommand(query, connect);

                command.Parameters.AddWithValue("@Student", Session["Student"]);

                connect.Open();

                SqlDataReader results = command.ExecuteReader();

                if (results.Read())
                {
                    lblLoggedInUser.Text = results[0].ToString() + " " + results[1].ToString();
                    Session["LoggedInFN"] = results[0].ToString();
                    Session["LoggedInLN"] = results[1].ToString();
                    connect.Close();
                }
                else
                {
                    connect.Close();
                    lblLoggedInUser.Text = "";
                }
            }
        }
    }

}