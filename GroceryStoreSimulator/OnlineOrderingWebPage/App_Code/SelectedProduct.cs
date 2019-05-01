/* Authors: Kyle Marler, Evan Batsch
 * Class: Web Server Application Development
 * Assignment: Final Project
 * Date due: 2019-05-01
 * Description: This class describes a product that the user has selected from lstItems in Order.aspx.
 * Other: N/A
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SelectedProduct
/// </summary>
namespace OnlineOrder.App_Code
{
    public class SelectedProduct : Product
    {
        private int mQuantity;

        public int quantity { get { return mQuantity; } set { mQuantity = value; } }

        public SelectedProduct(Product product, int quantity) : base(product.productID, product.brandDescription, product.price)
        {
            this.brandDescription = product.brandDescription;
            this.productID = product.productID;
            this.price = price;
            this.quantity = quantity;
        }

        public SelectedProduct(int productID, string brandDescription, double price, int quantity) : base(productID, brandDescription, price)
        {
            this.brandDescription = brandDescription;
            this.productID = productID;
            this.price = price;
            this.quantity = quantity;
        }

        public SelectedProduct()
        {

        }
    }
}