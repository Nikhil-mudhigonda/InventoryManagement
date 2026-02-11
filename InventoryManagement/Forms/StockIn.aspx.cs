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
    public partial class StockIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProductsData();
            LoadSupplierData();
        }

        protected void LoadProductsData()
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "select ProductId, ProductType from products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ProductsDropDownList.DataSource = dt;
                ProductsDropDownList.DataTextField = "ProductType";
                ProductsDropDownList.DataValueField = "ProductId";
                ProductsDropDownList.DataBind();

            }
        }

        protected void LoadSupplierData()
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "select Id, SupplierName from Suppliers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                SupplierDropDownList.DataSource = dt;
                SupplierDropDownList.DataTextField = "SupplierName";
                SupplierDropDownList.DataValueField = "Id";
                SupplierDropDownList.DataBind();
            }
        }

        protected void StockInBtn_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            if (string.IsNullOrEmpty(QtyTxt.Text) || !int.TryParse(QtyTxt.Text, out quantity))
            {
                if (quantity <= 0)
                {
                    StockInInfolbl.Text = "Please enter a valid Quantity";
                    return;
                }
            }

            
            int productId = Convert.ToInt32(ProductsDropDownList.SelectedValue);
            int supplierId = Convert.ToInt32(SupplierDropDownList.SelectedValue);

            using(SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    string query = "insert into StockIn (ProductId, SupplierId, Quantity) values (@productId, @SupplierId, @Qty)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
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
                catch(Exception ex)
                {
                    transaction.Rollback();
                    StockInInfolbl.Text = "StockIn Failed";
                    return;
                }
                
            }
        }

        protected void StockInBackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms/Dashboard.aspx");
        }
    }
}