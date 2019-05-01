using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineOrder.App_Code;

public partial class Results : System.Web.UI.Page
{
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

    protected void btn_Return_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}