using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStoreSimulator
{
    /// <summary>
    /// This class models a product from the GroceryStoreSimulator database
    /// Author: marlerkw
    /// Email: marlerkw@mail.uc.edu
    /// GroceryStoreSimulator database
    /// </summary>
    public class Product
    {

        public Product(string SKU, string brand, string description, double price)
        {
            this.SKU = SKU;
            this.brand = brand;
            this.description = description;
            this.price = price;
        }
        private string mSKU;
        private string mBrand;
        private string mDescription;
        private double mPrice;

        public string SKU
        {
            get { return mSKU; }
            set { mSKU = value; }
        }

        public string brand
        {
            get { return mBrand; }
            set { mBrand = value; }
        }

        public string description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
            }
        }

        public double price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
    }

}
