/* Authors: Kyle Marler, Evan Batsch
 * Class: Web Server Application Development
 * Assignment: Final Project
 * Date due: 2019-05-01
 * Description: The user is able to select an item from a list of products.
 * ...One an item is selected, the user can specify a quantity of that item to add to their cart.
 * ...The total price of the user's order is updated dynamically.
 * ...The quantity of a selected item can be viewed by clicking on it in the shopping cart listbox.
 * Other: N/A
 * Citations: Portions of the database connection code are adapted from Bill Nicholson's GroceryStoreSimulator project.
 * ...https://github.com/nicomp42/GroceryStoreSimulator
 */

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
    private ShoppingCart shoppingCart;
    private Dictionary<int, Product> products;
    private readonly SqlConnection conn;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OpenConnection();
            LoadListBox();
            LoadProducts();
            Session["Products"] = products;
            shoppingCart = new ShoppingCart();
            Session["ShoppingCart"] = shoppingCart;
        }
    }

    // 
    protected void lstCart_SelectedIndexChanged(object sender, EventArgs e)
    {
        string product = lstCart.SelectedItem.Text;
        shoppingCart = (ShoppingCart)Session["ShoppingCart"];

        SelectedProduct sp = new SelectedProduct();
        foreach (SelectedProduct p in shoppingCart.selectedProducts)
        {
            if (product == p.brandDescription)
            {
                sp = p;
            }
        }
        lblCurrentQuantity.Text = sp.quantity.ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        shoppingCart = (ShoppingCart)Session["ShoppingCart"];
        Store store = (Store)Session["SelectedStore"];
        string loyalty = (string)Session["LoyaltyNumber"];
        OnlineOrder.App_Code.Order order = new OnlineOrder.App_Code.Order(loyalty, store, 1, shoppingCart.CalculateTotal(), shoppingCart);

        SubmitOrder(order);
        order.orderID = (int)Session["OrderID"];
        Session["Order"] = order;
        Response.Redirect("Results.aspx");
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        AddToCart(lstItems);
        MoveToListBox(lstItems, lstCart);
        tbxQuantity.Text = "";
        lblTotalCost.Text = shoppingCart.CalculateTotal().ToString();
    }

    private void SubmitOrder(OnlineOrder.App_Code.Order order)
    {
        OpenConnection();

        SqlConnection conn = (SqlConnection)Session["ConnectionObject"];

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "spAddOrder";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        cmd.Parameters.Add(new SqlParameter("LoyaltyID", order.loyaltyID));
        cmd.Parameters.Add(new SqlParameter("StoreID", order.store.storeID));
        cmd.Parameters.Add(new SqlParameter("OrderStatusID", 1));
        cmd.Parameters.Add(new SqlParameter("DeliveryCharge", Convert.ToDecimal(0.00)));

        cmd.Parameters.Add("@OrderID", SqlDbType.Int, 0, "OrderID");
        cmd.Parameters["@OrderID"].Direction = ParameterDirection.Output;

        int orderID;
        try
        {
            cmd.ExecuteNonQuery();
            orderID = (int)cmd.Parameters["@OrderID"].Value;
            Session["OrderID"] = orderID;
        } catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

        cmd.CommandText = "spAddOrderDetail";

        foreach (SelectedProduct p in order.shoppingCart.selectedProducts) {
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("pOrderID", (int)Session["OrderID"]));
            cmd.Parameters.Add(new SqlParameter("pProductID", (int)p.productID));
            cmd.Parameters.Add(new SqlParameter("pQuantity", (int)p.quantity));
            cmd.Parameters.Add(new SqlParameter("pTotalPrice", Convert.ToDecimal(p.quantity * p.price)));
            cmd.Parameters.Add(new SqlParameter("pUnavailableWhenOrderWasFilled", Convert.ToBoolean(0)));
            cmd.ExecuteNonQuery();
        }
        
    }

    private void LoadListBox()
    {
        DataTable products = new DataTable();

        OpenConnection();

        SqlConnection conn = (SqlConnection)Session["ConnectionObject"];

        using (conn)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT ProductID, Brand + ' ' + Description AS BrandDescription" +
                    " FROM tProduct P INNER JOIN tBrand B " +
                "ON P.BrandID = B.BrandID ORDER BY BrandDescription ASC", conn);
                adapter.Fill(products);

                lstItems.DataSource = products;
                lstItems.DataTextField = "BrandDescription";
                lstItems.DataValueField = "ProductID";
                lstItems.DataBind();

            }
            catch (Exception ex)
            {
                // Handle the error
                Response.Write(ex.Message);
            }

        }
    }

    private void LoadProducts()
    {
        OpenConnection();
        SqlConnection conn = (SqlConnection)Session["ConnectionObject"];

        products = new Dictionary<int, Product>();

        using (conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT ProductID AS ID, Brand + ' ' + Description AS BrandDescription," +
                    " InitialPricePerSellableUnit AS Price FROM tProduct P INNER JOIN tBrand B " +
                "ON P.BrandID = B.BrandID ORDER BY BrandDescription ASC", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ID"))), new Product(Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ID"))),
                            Convert.ToString(reader.GetValue(reader.GetOrdinal("BrandDescription"))), Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Price")))));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the error
                Response.Write(ex.Message);
            }
        }
    }

    private void AddToCart(ListBox listBox)
    {
        shoppingCart = (ShoppingCart)Session["ShoppingCart"];
        products = (Dictionary<int, Product>)Session["Products"];
        if (listBox.SelectedIndex != -1) // If statement makes sure an index is selected in the correct box
        {
            int itemToAdd = Convert.ToInt32(listBox.SelectedItem.Value);
            Product productToAdd = new Product();
            bool productFound = false;
            foreach (KeyValuePair<int, Product> p in products)
            {
                if (p.Key == itemToAdd)
                {
                    productFound = true;
                    productToAdd = p.Value;
                    break;
                }
            }
            if (productFound == true)
            {
                SelectedProduct product = new SelectedProduct(productToAdd, Convert.ToInt32(tbxQuantity.Text));
                shoppingCart.AddProduct(product);
                Session["ShoppingCart"] = shoppingCart;
            }
        }
    }

    private void RemoveFromCart(ListBox listBox)
    {
        if (listBox.SelectedIndex != 1)
        {
            int itemToRemove = listBox.SelectedIndex;
            shoppingCart.RemoveProduct(itemToRemove);
        }
    }

    private void ChangeQuantity(ListBox listBox)
    {
        if (listBox.SelectedIndex != 1)
        {
            int itemToRemove = listBox.SelectedIndex;
            shoppingCart.ChangeQuanity(itemToRemove, Convert.ToInt32(tbxQuantity.Text));
        }
    }
    
    /// <summary>
    /// This method moves an item from one listbox to another while removing the item from the first one
    /// </summary>
    /// <param name="listBox">Item to be moved</param>
    /// <param name="listBoxTwo">ListBox to recieve item</param>
    private void MoveToListBox(ListBox listBox, ListBox listBoxTwo)
    {
        if (listBox.SelectedIndex != -1) // If statement makes sure an index is selected in the correct box
        {
            ListItem itemToAdd = listBox.SelectedItem;
            listBoxTwo.Items.Add(itemToAdd);
            listBox.Items.Remove(itemToAdd);
            listBox.SelectedIndex = -1; // Deselects all items in the two boxes
            listBoxTwo.SelectedIndex = -1;
        }
    }

    /*
    * Below are methods for the database connection
    */

    /** Read the connection string from the web.config file. 
    * This is a much more secure way to store sensitive information. Don't hard-code connection information in the source code.
    * Adapted from http://msdn.microsoft.com/en-us/library/ms178411.aspx
    */
    private System.Configuration.ConnectionStringSettings ReadConnectionString()
    {
        String strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";
        System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
        {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["MarlerKWConnectionString"];
        }
        return connString;
    }

    /**
    * Open the connection to the database
    */
    private void OpenConnection()
    {
        System.Configuration.ConnectionStringSettings strConn;
        strConn = ReadConnectionString();
        // Console.WriteLine(strConn.ConnectionString);

        System.Data.SqlClient.SqlConnection conn;
        conn = new System.Data.SqlClient.SqlConnection(strConn.ConnectionString);
        Session.Add("ConnectionObject", conn);
        // This could go wrong in so many ways...
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            // Miserable error handling...
            Response.Write(ex.Message);
        }
    }
}