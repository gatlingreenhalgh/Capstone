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
    public partial class MemberMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Create footer Name
            if (Session["Member"] != null)
            {
                String sqlQuery = "SELECT MemberFirstName, MemberLastName FROM Members WHERE MemberUser=@Member";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);


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
                    Session["LoggedInFN"] = queryResults[0].ToString();
                    Session["LoggedInLN"] = queryResults[1].ToString();
                    sqlConnect.Close();
                }
                           
                else
                {
                    sqlConnect.Close();
                    lblLoggedInUser.Text = "";
                }
            }
        }
    }

}