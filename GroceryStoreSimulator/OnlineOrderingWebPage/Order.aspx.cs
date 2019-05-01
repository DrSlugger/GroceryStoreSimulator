using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
//        ShoppingCart cart = new ShoppingCart();
//        lbx_Items.Items.Add();

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

    // TODO: Change webconfig.aspx to not display code in errors (debug mode).

    // Functionality to remove an item from the cart?
}