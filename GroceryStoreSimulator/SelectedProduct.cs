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
    public class SelectedProduct : Product
    {

        public SelectedProduct(string brand, string SKU, string description, double price, int quantity) : base(brand, SKU, description, price)
        {
            this.brand
            
        }
        private int mQuantity;

        public int quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
    }

}
