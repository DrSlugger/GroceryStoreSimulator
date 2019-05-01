using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SelectedProduct
/// </summary>
namespace OnlineOrderApp_Code
{
    public class SelectedProduct : Product
    {
        private int mQuantity;

        public int quantity { get { return mQuantity; } set { mQuantity = value; } }

        public SelectedProduct(Product product, int quantity) : base(product.SKU, product.brand, product.description, product.price)
        {
            this.brand = product.brand;
            this.SKU = product.SKU;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }

        public SelectedProduct(string brand, string SKU, string description, double price, int quantity) : base(brand, SKU, description, price, quantity)
        {
            this.brand = brand;
            this.SKU = SKU;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }
    }
}