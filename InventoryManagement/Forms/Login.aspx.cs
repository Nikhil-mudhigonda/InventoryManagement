using InventoryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement.Forms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(LgnUsernameTxt.Text) || string.IsNullOrEmpty(LgnPasswordTxt.Text))
            {
                InfoTxt.Text = "Please enter a valid user name and password";
                return;
            }
            using(SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "select username, password from users where username = @username and password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", LgnUsernameTxt.Text);
                cmd.Parameters.AddWithValue("@password", Utilities.PasswordHelper.HashPassword(LgnPasswordTxt.Text));
                conn.Open();
                cmd.CommandTimeout = 60;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //if(reader["Role"].ToString() == "Admin")
                    //{
                    //    Response.Redirect("Forms/Dashboard.aspx");
                    //}
                    Response.Redirect("Forms/Dashboard.aspx");
                }
                else
                {
                    InfoTxt.Text = "Invalid Credentials";
                }
            }
        }
    }
}