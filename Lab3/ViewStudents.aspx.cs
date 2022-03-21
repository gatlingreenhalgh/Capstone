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
    public partial class ViewStudents : System.Web.UI.Page
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

        private void BindGrid()
        {
            String student = HttpUtility.HtmlEncode(searchStudent.Text);
            string[] split = student.Split(' ');
            string constr = ConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select StudentID, ResumeName from Students WHERE FirstName ='" + split[0] + "' AND LastName = '" + split[1] + "'";
                    cmd.Connection = con;
                    con.Open();
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    con.Close();
                }
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            String student = searchStudent.Text;
            string[] split = student.Split(' ');
            Session["pdfFN"] = split[0];
            Session["pdfLN"] = split[1];

            String query = "SELECT Count(StudentResume) FROM Students WHERE FirstName ='" + split[0] + "' AND LastName = '" + split[1] + "'";

            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

            SqlCommand command = new SqlCommand(query, connect);

            connect.Open();

            int count = Convert.ToInt32(command.ExecuteScalar());

            connect.Close();

            // Create the Query:
            String sqlQuery = "SELECT FirstName, LastName, PhoneNumber, EmailAddress, Major, GradeLevel, GraduationYear, InternshipStatus, EmploymentStatus, StudentResume FROM Students WHERE FirstName ='" + split[0] + "' AND LastName = '" + split[1] + "'";

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
            if (queryResults.HasRows) { 
            while (queryResults.Read())
            {
                txtFirstName.Text = queryResults["FirstName"].ToString();
                txtLastName.Text = queryResults["LastName"].ToString();
                txtEmail.Text = queryResults["EmailAddress"].ToString();
                txtPhone.Text = queryResults["PhoneNumber"].ToString();
                txtMajor.Text = queryResults["Major"].ToString();
                txtGradeLevel.Text = queryResults["GradeLevel"].ToString();
                txtGradYear.Text = queryResults["GraduationYear"].ToString();
                txtIntern.Text = queryResults["InternshipStatus"].ToString();
                txtEmployment.Text = queryResults["EmploymentStatus"].ToString();

            }
            if (count == 1)
            {
                BindGrid();
                GridView1.Visible = true;
            }
        }
            sqlConnect.Close();
            queryResults.Close();
        }

        protected void View(object sender, EventArgs e)
        {
            String student = searchStudent.Text;
            string[] split = student.Split(' ');

            // Create the Query:
            String querysql = "select StudentResume, ContentType from Students WHERE FirstName ='" + split[0] + "' AND LastName = '" + split[1] + "'";

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
            if(sdr.Read())
            {
                WebClient client = new WebClient();
                Byte[] pdfData = client.DownloadData(sdr["StudentResume"].ToString());
                Response.Buffer = true;
                Response.ContentType = sdr["ContentType"].ToString();
                Response.BinaryWrite(pdfData);
            }
            connectsql.Close();
            }
        

    }
}