/* Authors: Kyle Marler, Evan Batsch
 * Class: Web Server Application Development
 * Assignment: Final Project
 * Date due: 2019-05-01
 * Description: In this view, an employee is able to view and approve pending orders.
 * ...A list of all orders in the database is displayed as well.
 * Other: N/A
 */

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
}