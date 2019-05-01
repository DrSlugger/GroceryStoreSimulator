using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStoreSimulator.Code
{
    /// <summary>
    /// This class models a product from the GroceryStoreSimulator database
    /// Author: marlerkw
    /// Email: marlerkw@mail.uc.edu
    /// GroceryStoreSimulator database
    /// </summary>
    public class SelectedProduct : Product
    {

        public SelectedProduct(Product product, int quantity) : base(product.SKU, product.brand, product.description, product.price)
        {
            this.quantity = quantity;
        }
        private int mQuantity;

        public int quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
    }

}
