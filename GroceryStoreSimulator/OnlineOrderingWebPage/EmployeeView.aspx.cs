using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeView : System.Web.UI.Page
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Show pending orders
        conn = (SqlConnection)Session["ConnectionObject"];
        conn.Open();
    }

    // CheckboxList: select orders, hit submit to remove from list
    // On submit, change status to "delivered"
    
    // Bulleted list: just show a list of all complete orders in database
    // Loyalty ID, total cost, etc.
}