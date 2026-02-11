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
    public partial class ignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void SigninBtn_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SgnUsername.Text) || string.IsNullOrEmpty(SgnPassword.Text))
            {
                InfoTxt.Text = "Please enter a valid user name and password";
                return;
            }

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "insert into users (username, password, role) values (@username, @password, @role)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", SgnUsernameTxt.Text);
                cmd.Parameters.AddWithValue("@password", Utilities.PasswordHelper.HashPassword(SgnPasswordTxt.Text));
                cmd.Parameters.AddWithValue("@role", RoleButtonList1.SelectedValue);
                cmd.CommandTimeout = 120;
                conn.Open();
                cmd.ExecuteNonQuery();
                InfoTxt.Text = "Signin was succefull, please login";
            }
        }

        protected void sgnloginBtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}