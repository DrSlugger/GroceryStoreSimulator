using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineOrder.App_Code;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e)
    {
        OpenConnection();
        PopulateDropDown();
        //        ShoppingCart cart = new ShoppingCart();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //        cart.loyaltyID.set(txt_LoyaltyNumber.Text);
        //        cart.storeID.set(ddl_Stores.SelectedValue);
        Store store = new Store(drpStores.SelectedItem.Text, Convert.ToInt32(drpStores.SelectedItem.Value));
        Session["SelectedStore"] = store;
        Session["LoyaltyNumber"] = tbxLoyaltyNumber.Text;
        Response.Redirect("Order.aspx");
    }

    private void PopulateDropDown()
    {
        DataTable stores = new DataTable();

        SqlConnection conn = (SqlConnection)Session["ConnectionObject"];

        using (conn)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Store, S.StoreID FROM tStore S INNER JOIN " +
                    "tStoreHistory H ON S.StoreID = h.StoreID INNER JOIN tStoreStatus SS ON H.StoreStatusID = " +
                    "SS.StoreStatusID WHERE IsOpenForBusiness = 1 ORDER BY Store ASC", conn);
                adapter.Fill(stores);

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