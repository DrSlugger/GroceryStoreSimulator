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
        DBConnection.OpenConnection();
        PopulateDropDown();
        //        ShoppingCart cart = new ShoppingCart();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
//        cart.loyaltyID.set(txt_LoyaltyNumber.Text);
//        cart.storeID.set(ddl_Stores.SelectedValue);
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
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT S.StoreID, Store FROM tStore S INNER JOIN " +
                    "tStoreHistory H ON S.StoreID = h.StoreID INNER JOIN tStoreStatus SS ON H.StoreStatusID = " +
                    "SS.StoreStatusID WHERE IsOpenForBusiness = 1", conn);
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


    /// <summary>
    /// This method transfers all data from one listbox to another, and avoids repeating the data
    /// </summary>
    /// <param name="listBox">Data to be copied</param>
    /// <param name="listBoxTwo">Data to be copied to</param>
    private void SelectAllInListBox(ListBox listBox, ListBox listBoxTwo)
    {
        List<ListItem> checkList = new List<ListItem>(); // Declares and instantiates a list that will be populated to check which items are in the selected box
        foreach (ListItem item in listBox.Items)
        {
            checkList.Add(item);
        }

        foreach (ListItem item in checkList) // Nested foreach loops used to check which values need to be removed from the selected list box
        {
            foreach (ListItem item2 in listBoxTwo.Items)
            {
                if (item.Value == item2.Value) // If the items match, will be removed from the second listBox
                {
                    listBoxTwo.Items.Remove(item);
                    break;
                }
            }
        }

        foreach (ListItem item in checkList)
        {
            listBoxTwo.Items.Add(item); // Adds all items to listBoxTwo
        }
        listBox.Items.Clear(); // Clears list box
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
}