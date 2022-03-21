using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Windows;
using System.Net;

namespace Lab3
{
    public partial class pdfViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Student"] != null || Session["Member"] != null || Session["Admin"] != null)
            {
                if (Session["pdfFN"] != null)
                {
                    // Create the Query:
                    String querysql = "select StudentResume, ContentType from Students WHERE FirstName ='" + Session["pdfFN"].ToString() + "' AND LastName = '" + Session["pdfLN"].ToString() + "'";

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
                    SqlDataReader sdr = commandsql.ExecuteReader();
                    sdr.Read();
                    WebClient client = new WebClient();
                    byte[] pdfData = (byte[])sdr["StudentResume"];
                    Response.Buffer = true;
                    Response.ContentType = sdr["ContentType"].ToString();
                    Response.BinaryWrite(pdfData);
                    connectsql.Close();
                }
            }
            else
            {
                Session["MustLogin"] = "You must Login First to Access That Page!";
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}