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
    private List<Product> products;
    protected void Page_Load(object sender, EventArgs e)
    {
        //        ShoppingCart cart = new ShoppingCart();
        //        lbx_Items.Items.Add();
        OpenConnection();
        LoadProducts();
        LoadListBox();

        shoppingCart = new ShoppingCart();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Add all of the items in the cart to the order...
        // ... or whatever the design was.
        Response.Redirect("Results.aspx");
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        MoveToListBox(lstItems, lstCart);
        AddToCart(lstItems);
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
        SqlConnection conn = (SqlConnection)Session["ConnectionObject"];

        products = new List<Product>();

        using (conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT ProductID, Brand + ' ' + Description AS BrandDescription," +
                    " InitialPricePerSellableUnit AS Price FROM tProduct P INNER JOIN tBrand B " +
                "ON P.BrandID = B.BrandID ORDER BY BrandDescription ASC", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            products.Add(new Product((int)reader.GetOrdinal("ProductID"),
                            reader.GetOrdinal("BrandDescription").ToString(), Convert.ToDouble(reader.GetOrdinal("Price"))));
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
        if (listBox.SelectedIndex != -1) // If statement makes sure an index is selected in the correct box
        {
            int itemToAdd = listBox.SelectedIndex;
            Product productToAdd = new Product();
            bool productFound = false;
            foreach (Product p in products)
            {
                if (p.productID == itemToAdd)
                {
                    productFound = true;
                    productToAdd = p;
                    break;
                }
            }
            if (productFound == true)
            {
                SelectedProduct product = new SelectedProduct(productToAdd, Convert.ToInt32(tbxQuantity.Text));
                shoppingCart.AddProduct(product);
            } else
            {
                Response.Write("Please enter a quantity");
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
            listBox.Items.Remove(itemToAdd);
            listBoxTwo.Items.Add(itemToAdd);
            listBox.SelectedIndex = -1; // Deselects all items in the two boxes
            listBoxTwo.SelectedIndex = -1;
        }
    }

    // Add the initial item - you can add this even if the options from the
    // db were not successfully loaded

    // TODO: Change webconfig.aspx to not display code in errors (debug mode).

    // Functionality to remove an item from the cart?


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