using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Greenhalgh_Lab_1
{
    public partial class Home : System.Web.UI.Page
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
            else if (Session["Admin"] != null)
            {
                MasterPageFile = "~/Admin.Master";
            }
            else
            {
                MasterPageFile = "~/Lab3Master.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}