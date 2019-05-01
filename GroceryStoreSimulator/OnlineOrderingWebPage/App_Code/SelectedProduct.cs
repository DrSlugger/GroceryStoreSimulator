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

        public SelectedProduct(Product product, int quantity) : base(product.productID, product.brand, product.description, product.price)
        {
            this.brand = product.brand;
            this.productID = product.productID;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }

        public SelectedProduct(string brand, int productID, string SKU, string description, double price, int quantity) : base(productID, brand, description, price)
        {
            this.brand = brand;
            this.productID = productID;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }
    }
}