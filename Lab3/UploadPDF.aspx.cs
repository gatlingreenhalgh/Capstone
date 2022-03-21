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

namespace Lab3
{
    public partial class UploadPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { //Check Login Status
            if (Session["Student"] != null)
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnStringOb2"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select FirstName, LastName from Students WHERE StudentUser='" + Session["Student"].ToString() + "'";
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            Session["pdfFN"] = sdr["FirstName"].ToString();
                            Session["pdfLN"] = sdr["LastName"].ToString();
                        }
                        con.Close();
                    }
                } 

                String query = "SELECT Count(StudentResume) FROM Students WHERE StudentUser ='" + Session["Student"].ToString() + "'";

                SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString);

                SqlCommand command = new SqlCommand(query, connect);

                connect.Open();

                int count = Convert.ToInt32(command.ExecuteScalar());

                connect.Close();

                if (count == 1)
                {
                    BindGrid();
                    GridView1.Visible = true;
                }
                else
                {
                    GridView1.Visible = false;
                }
            }
            else
            {
                Session["MustLogin"] = "You must Login First to Access That Page!";
                Response.Redirect("LoginPage.aspx");
            }
        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select StudentID, ResumeName from Students WHERE StudentUser='" + Session["Student"].ToString() + "'";

                    cmd.Connection = con;
                    con.Open();
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    con.Close();
                }
            }
        }

        protected void Upload(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            if (!filename.Equals(""))
            {
                using (Stream fs = FileUpload1.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["ConnStringOb1"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            string query = "UPDATE Students SET ResumeName=@Name, ContentType=@ContentType, StudentResume=@Data WHERE StudentUser='" + Session["Student"].ToString() + "'";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Name", filename);
                                cmd.Parameters.AddWithValue("@ContentType", contentType);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                }
                Response.Redirect("UploadPDF.aspx");
            }
        }
    }
}