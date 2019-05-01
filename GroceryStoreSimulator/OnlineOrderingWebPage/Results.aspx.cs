/* Authors: Kyle Marler, Evan Batsch
 * Class: Web Server Application Development
 * Assignment: Final Project
 * Date due: 2019-05-01
 * Description: The user is able to view information about their order, after it has been submitted.
 * ...A list of purchased items is displayed, as well as the total price of the order.
 * Other: N/A
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineOrder.App_Code;

public partial class Results : System.Web.UI.Page
{
    // The user's order number is displayed, along with a list of relevant information about their...
    //...order, such as a list of items and the total cost.
    protected void Page_Load(object sender, EventArgs e)
    {
        OnlineOrder.App_Code.Order order = (OnlineOrder.App_Code.Order)Session["Order"];
        lblOrderNumber.Text = order.orderID.ToString();
        string description;
        bltDetailsList.Items.Add("Your Selected Store: " + order.store.storeName);
        bltDetailsList.Items.Add("Your Loyalty Number: " + order.loyaltyID);
        foreach (SelectedProduct p in order.shoppingCart.selectedProducts)
        {
            description = p.brandDescription + " ; Quantity: " + p.quantity + "; Price Per Unit: " + p.price;
            bltDetailsList.Items.Add(description);
        }
        bltDetailsList.Items.Add("Final Price: $" + order.finalPrice);
    }

    // The user is able to return to the main page if they want to submit another order.
    protected void btn_Return_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}