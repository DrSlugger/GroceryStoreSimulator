using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
//        ShoppingCart cart = new ShoppingCart();
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
//        cart.loyaltyID.set(txt_LoyaltyNumber.Text);
//        cart.storeID.set(ddl_Stores.SelectedValue);
        Response.Redirect("Order.aspx");
    }
}