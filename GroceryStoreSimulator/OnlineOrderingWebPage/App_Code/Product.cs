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
        private string mBrand;
        private string mDescription;
        private double mPrice;

        public int productID { get { return mProductID; } set { mProductID = value; } }
        public string brand { get { return mBrand; } set { mBrand = value; } }
        public string description { get { return mDescription; } set { mDescription = value; } }
        public double price { get { return mPrice; } set { mPrice = value; } }

        public Product(int productID, string brand, string description, double price)
        {
            this.productID = productID;
            this.brand = brand;
            this.description = description;
            this.price = price;
        }

        public override string ToString()
        {
            return brand + " " + description;
        }
    }
}