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