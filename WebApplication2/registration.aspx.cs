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
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();

                String checkuser = "select count(*) from userData where userName='"+userName.Text+"' ";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
                if(temp == 1)
                {
                    Response.Write("User already exists");
                }
                
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Guid newGuid = Guid.NewGuid();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();

                String insertUser = "insert into UserData (Id,firstName,lastName,userName,email,password) values(@id,@firstName, @lastName, @userName, @email, @password)";
                SqlCommand com = new SqlCommand(insertUser, conn);
                com.Parameters.AddWithValue("@id", newGuid.ToString());
                com.Parameters.AddWithValue("@firstName", firstName.Text);
                com.Parameters.AddWithValue("@lastName", lastName.Text);
                com.Parameters.AddWithValue("@userName", userName.Text);
                com.Parameters.AddWithValue("@email", email.Text);
                com.Parameters.AddWithValue("@password", password.Text);

                com.ExecuteNonQuery();
                Response.Redirect("manager.aspx");
                Response.Write("Registration sucessful");
                conn.Close();

                
            }
            catch(Exception ex)
            {
                Response.Write("Error " + ex.ToString());
            }
        }
    }
}