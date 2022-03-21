using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class AcceptStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check Login Status
            if (Session["Admin"] != null)
            {

            }
            else
            {
                Session["MustLogin"] = "You must Login First to Access That Page!";
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void btnAcceptStudent_Click(object sender, EventArgs e)
        {
            int index = lstbxStudentAccounts.SelectedIndex;
            String application = lstbxStudentAccounts.Items[index].ToString();
            string[] split = application.Split(' ');

            String querysql = "SELECT PSFirstName, PSLastName, PSEmailAddress, PSStudentUser, PSStudentPass, PSPhoneNumber, PSMajor, PSGradeLevel, PSGraduationYear, PSInternshipStatus, PSEmploymentStatus FROM ProposedStudents WHERE PSFirstName=@fn AND PSLastName=@ln";

            SqlConnection connectsql = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

            SqlCommand commandsql = new SqlCommand(querysql, connectsql);
            commandsql.Parameters.AddWithValue("@fn", split[0]);
            commandsql.Parameters.AddWithValue("@ln", split[1]);

            connectsql.Open();

            SqlDataReader readersql = commandsql.ExecuteReader(); // create a reader

            if (readersql.HasRows) // if the username exists, it will continue
            {
                while (readersql.Read()) // this will read the single record that matches the entered username
                {
                    String fn = readersql[0].ToString();
                    String ln = readersql[1].ToString();
                    String email = readersql[2].ToString();
                    String user = readersql[3].ToString();
                    String pass = readersql[4].ToString();
                    String phone = readersql[5].ToString();
                    String major = readersql[6].ToString();
                    String gl = readersql[7].ToString();
                    String gy = readersql[8].ToString();
                    String intern = readersql[9].ToString();
                    String job = readersql[10].ToString();

                    // Create the Query with Concatenation of Text Boxes:
                    String sqlQuery = "INSERT INTO Students(FirstName, LastName, EmailAddress, StudentUser, StudentPass) "
                        + "VALUES(@fn, @ln, @email, @user, @pass)";

                    // Define the connection to the DB:
                    SqlConnection sqlConnect =
                    new SqlConnection(
                    WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

                    // Create and Structure the Query Command:
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;
                    sqlCommand.Parameters.AddWithValue("@fn", fn);
                    sqlCommand.Parameters.AddWithValue("@ln", ln);
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@user", user);
                    sqlCommand.Parameters.AddWithValue("@pass", pass);
                    // Execute the Query and Retrieve the Results
                    sqlConnect.Open();
                    sqlCommand.ExecuteScalar();
                    sqlConnect.Close();


                    // Create the Query with Concatenation of Text Boxes:
                    String sqlQuery1 = "INSERT INTO Students(FirstName, LastName, EmailAddress, StudentUser, PhoneNumber, Major, GradeLevel, GraduationYear, InternshipStatus, EmploymentStatus) "
                        + "VALUES(@fn, @ln, @email, @user, @phone, @major, @gl, @gradyear, @intern, @job)";

                    // Define the connection to the DB:
                    SqlConnection sqlConnect1 =
                    new SqlConnection(
                    WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

                    // Create and Structure the Query Command:
                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;
                    sqlCommand1.Parameters.AddWithValue("@fn", fn);
                    sqlCommand1.Parameters.AddWithValue("@ln", ln);
                    sqlCommand1.Parameters.AddWithValue("@email", email);
                    sqlCommand1.Parameters.AddWithValue("@user", user);
                    sqlCommand1.Parameters.AddWithValue("@phone", phone);
                    sqlCommand1.Parameters.AddWithValue("@major", major);
                    sqlCommand1.Parameters.AddWithValue("@gradyear", gy);
                    sqlCommand1.Parameters.AddWithValue("@gl", gl);
                    sqlCommand1.Parameters.AddWithValue("@intern", intern);
                    sqlCommand1.Parameters.AddWithValue("@job", job);
                    // Execute the Query and Retrieve the Results
                    sqlConnect1.Open();
                    sqlCommand1.ExecuteScalar();
                    sqlConnect1.Close();
                }
                connectsql.Close();
                denyStudent();
            }
        }

        protected void denyStudent()
        {
            int index = lstbxStudentAccounts.SelectedIndex;
            String application = lstbxStudentAccounts.Items[index].ToString();
            string[] split = application.Split(' ');

            // Create the Query with Concatenation of Text Boxes:
            String sqlQuery = "DELETE FROM ProposedStudents WHERE PSFirstName = @fn AND PSLastName= @ln";

            // Define the connection to the DB:
            SqlConnection sqlConnect =
            new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString);

            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@fn", split[0]);
            sqlCommand.Parameters.AddWithValue("@ln", split[1]);
            // Execute the Query and Retrieve the Results
            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();
            Response.Redirect("AcceptStudents.aspx");
        }
    

        protected void btnDenyStudent_Click(object sender, EventArgs e)
        {
        denyStudent();
        }
    }
}