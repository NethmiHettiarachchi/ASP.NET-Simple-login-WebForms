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
    public partial class deleteUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();

                String checkuser = "select count(*) from userData where userName='" + uName.Text + "' and  lastName='" + lName.Text + "' ";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp == 1)
                {
                    String checklogin = "select count(*) from userData where userName='" + uName.Text + "' and  isLoggedIn=1 ";
                    SqlCommand comlog = new SqlCommand(checklogin, conn);
                    int temp1 = Convert.ToInt32(comlog.ExecuteScalar().ToString());

                    if(temp1==1)
                    {
                        Response.Write("You Cannot delete urself :P");
                        conn.Close();
                        Response.Redirect("cantDel.aspx");

                    }
                    String deleteUser = "delete from UserData where userName='" + uName.Text + "'  and lastName='" + lName.Text + "'";
                    SqlCommand comdel = new SqlCommand(deleteUser, conn);
                    comdel.ExecuteNonQuery();
                    Response.Write("Deletion sucessful");
                    Response.Redirect("manager.aspx");
                    conn.Close();
                }
                else
                {
                    Response.Write("User does not exist. Deletion failed");
                }

                


            }
            catch (Exception ex)
            {
                Response.Write("Error " + ex.ToString());
            }
        }
    }
}