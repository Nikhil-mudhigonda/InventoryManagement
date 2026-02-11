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
    public partial class StockOut : System.Web.UI.Page
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
            using(SqlConnection con = DbHelper.GetConnection())
            {
                string query = "select ProductId, ProductType from products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                StockOutDropDownList.DataSource = dt;
                StockOutDropDownList.DataTextField = "ProductType";
                StockOutDropDownList.DataValueField = "ProductId";
                StockOutDropDownList.DataBind();

            }
        }

        protected void StockOutBtn_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            if (string.IsNullOrEmpty(StockOutQtyTxt.Text) || !int.TryParse(StockOutQtyTxt.Text, out quantity))
            {
                if (quantity <= 0)
                {
                    stockOutInfolbl.Text = "Please enter a valid Quantity";
                    return;
                }
            }

            int productId = Convert.ToInt32(StockOutDropDownList.SelectedValue);

            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    string query = "insert into StockOut (ProductId, Quantity) values (@productId, @Qty)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@Qty", quantity);
                    cmd.CommandTimeout = 60;
                    cmd.ExecuteNonQuery();

                    string UpdateProducts = "update products set Quntity = Quantity + @Quantity where productid = @ProductId";
                    SqlCommand cmdupdate = new SqlCommand(UpdateProducts, con);
                    cmdupdate.Parameters.AddWithValue("@Quantity", quantity);
                    cmdupdate.Parameters.AddWithValue("ProductId", productId);
                    cmdupdate.CommandTimeout = 60;
                    cmdupdate.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    stockOutInfolbl.Text = "StockIn Failed";
                    return;
                }

            }
        }
    }
}