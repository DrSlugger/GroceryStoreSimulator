using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineOrder.App_Code;

public partial class Order : System.Web.UI.Page
{
    private SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        //        ShoppingCart cart = new ShoppingCart();
        //        lbx_Items.Items.Add();

        conn = (SqlConnection)Session["ConnectionObject"];
        conn.Open();
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        // Add all of the items in the cart to the order...
        // ... or whatever the design was.
        Response.Redirect("Results.aspx");
    }

    protected void btn_AddToCart_Click(object sender, EventArgs e)
    {
        // Check: if item already in cart and you're adding more, just update the qty.
        // I.E. don't create a new entry for it.
//        int productID = (int)lbx_Items.SelectedValue; // To int?
//        int qty = (int)txt_Quantity.Text; // Check if int
//        string comment = lbx_Items.SelectedItem; // ???
//        ShoppingCartItem newItem = new ShoppingCartItem(productID, qty)

//        cart.ShoppingCartItems.add(newItem);

//        lbx_Cart.Items.Add(newItem.);

//        lbl_TotalCost.Text = ;// Order.CalculatePrice(), or something?
    }
    /**
    private void LoadListBox()
    {
        DataTable products = new DataTable();

        SqlConnection conn = (SqlConnection)Session["ConnectionObject"];

        List<Product> listProducts = new List<Product>();

        using (conn)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT Brand, Description FROM tProduct P INNER JOIN tBrand B " +
                "ON P.BrandID = B.BrandID WHERE LEN(Description) > 0", conn);
                adapter.Fill(products);

                for (int i = 0; i < products.Rows.Count; i++)
                {
                    DataRow data = products.Rows[i];


                }

                drpStores.DataSource = stores;
                drpStores.DataTextField = "Store";
                drpStores.DataValueField = "StoreID";
                drpStores.DataBind();
            }
            catch (Exception ex)
            {
                // Handle the error
                Response.Write(ex.Message);
            }

        }

        // Add the initial item - you can add this even if the options from the
        // db were not successfully loaded
        drpStores.Items.Insert(0, new ListItem("<Select Store>", "0"));
    }
    **/
    // TODO: Change webconfig.aspx to not display code in errors (debug mode).

    // Functionality to remove an item from the cart?
}