/* Authors: Kyle Marler, Evan Batsch
 * Class: Web Server Application Development
 * Assignment: Final Project
 * Date due: 2019-05-01
 * Description: This class describes a product that is drawn from the database and stored in lstItems in Order.aspx.
 * Other: N/A
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
namespace OnlineOrder.App_Code
{
    public class Product
    {
        private int mProductID;
        private string mBrandDescription;
        private double mPrice;

        public int productID { get { return mProductID; } set { mProductID = value; } }
        public string brandDescription { get { return mBrandDescription; } set { mBrandDescription = value; } }
        public double price { get { return mPrice; } set { mPrice = value; } }

        public Product(int productID, string brandDescription, double price)
        {
            this.productID = productID;
            this.brandDescription = brandDescription;
            this.price = price;
        }

        public Product(Product product)
        {
            this.productID = productID;
            this.brandDescription = brandDescription;
            this.price = price;
        }

        public Product()
        {

        }
    }
}