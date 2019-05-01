/* Authors: Kyle Marler, Evan Batsch
 * Class: Web Server Application Development
 * Assignment: Final Project
 * Date due: 2019-05-01
 * Description: This class stores a list of selected products. It is used in Order.aspx.
 * ...It contains methods for calculating the total price of an order, and for adjusting product quantities.
 * Other: N/A
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Allows us to create an object for the ShoppingCart in the webform
/// </summary>
namespace OnlineOrder.App_Code
{
    public class ShoppingCart
    {
        private List<SelectedProduct> mSelectedProducts;

        // A list of all products selected by the user.
        public List<SelectedProduct> selectedProducts
        {
            get
            {
                return mSelectedProducts;
            }
        }
        
        public ShoppingCart()
        {
            mSelectedProducts = new List<SelectedProduct>();
        }

        // The following methods are used in Order.aspx.

        public double CalculateTotal()
        {
            double finalPrice = 0;
            foreach (SelectedProduct p in selectedProducts)
            {
                finalPrice += p.quantity * p.price;
            }
            return finalPrice;
        }

        public void RemoveProduct(int removeProduct)
        {
            foreach (SelectedProduct p in selectedProducts)
            {
                if (p.productID == removeProduct)
                {
                    selectedProducts.Remove(p);
                }
            }
        }

        public void AddProduct(SelectedProduct product)
        {
            bool isInCart = false;
            foreach (SelectedProduct p in selectedProducts)
            {
                if (p.productID == product.productID)
                {
                    isInCart = true;
                    break;
                }
            }
            if (isInCart == false)
            {
                selectedProducts.Add(product);
            }
        }

        public void ChangeQuanity(int product, int quantity)
        {
            bool quantityChanged = false;
            foreach (SelectedProduct p in selectedProducts)
            {
                if (p.productID == product)
                {
                    p.quantity = quantity;
                    quantityChanged = true;
                }
                if (quantityChanged)
                {
                    break;
                }
            }
        }
    }
}