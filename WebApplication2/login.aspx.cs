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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            String checkuser = "select count(*) from userData where userName='" + userName.Text + "' ";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                String checkPassword = "select password from userData where userName='" + userName.Text + "' ";
                SqlCommand compw = new SqlCommand(checkPassword, conn);
                String conpw = compw.ExecuteScalar().ToString().Replace(" ","");
                if (conpw == password.Text)
                {
                    String loginUser = "update UserData set isLoggedIn=1 where userName='" + userName.Text + "'  and password='" + password.Text + "'";
                    SqlCommand comdel = new SqlCommand(loginUser, conn);
                    comdel.ExecuteNonQuery();
                    conn.Close();
                    Session["new"] = userName.Text;
                    Response.Write("password is correct");
                    Response.Redirect("manager.aspx");
                    //Response.
                    
                }
                else
                {
                    Response.Write("password does not match");
                }
            }
            else
            {
                Response.Write("user doesnot exist");
            }

        }
    }
}