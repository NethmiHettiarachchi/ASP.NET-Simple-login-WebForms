using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2
{
    public partial class manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            String logoutUser = "update UserData set isLoggedIn=0";
            SqlCommand comdel = new SqlCommand(logoutUser, conn);
            comdel.ExecuteNonQuery();
            Response.Redirect("login.aspx");
        }

        protected void SqlDataSourceRegistration_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void delete_Click(object sender, EventArgs e)
        {
            Response.Redirect("deleteUsers.aspx");
        }
    }
}