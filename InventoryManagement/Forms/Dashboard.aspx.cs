using InventoryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement.Forms
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductsData();
            }
        }

        protected void LoadProductsData()
        {
            using(SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "select ProductName, Quantity from products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }

        protected void StockInBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockIn.aspx");
        }

        protected void StockOutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockOut.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}