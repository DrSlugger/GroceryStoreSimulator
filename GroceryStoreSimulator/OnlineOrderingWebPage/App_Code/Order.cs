/* Authors: Kyle Marler, Evan Batsch
 * Class: Web Server Application Development
 * Assignment: Final Project
 * Date due: 2019-05-01
 * Description: This class stores information about the user's order, provided in Order.aspx.
 * ...It is used as a session variable.
 * Other: N/A
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Object that will store the information for an order
/// </summary>
namespace OnlineOrder.App_Code
{
    public class Order
    {
        private int mOrderID;
        private string mLoyaltyID;
        private Store mStore;
        private int mStatusID;
        private double mFinalPrice;
        private ShoppingCart mShoppingCart;

        public int orderID { get { return mOrderID; } set { mOrderID = value; } }
        public string loyaltyID { get { return mLoyaltyID; } set { mLoyaltyID = value; } }
        public Store store { get { return mStore; } set { mStore = value; } }
        public int statusID { get { return mStatusID; } set { mStatusID = value; } }
        public ShoppingCart shoppingCart { get { return mShoppingCart; } set { mShoppingCart = value; } }

        public double finalPrice { get { return mFinalPrice; } set { mFinalPrice = value; } }

        public Order(string loyaltyID, Store store, int statusID, double finalPrice, ShoppingCart shoppingCart)
        {
            this.loyaltyID = loyaltyID;
            this.store = store;
            this.statusID = statusID;
            this.finalPrice = finalPrice;
            this.shoppingCart = shoppingCart;
        }

        public Order()
        {

        }
    }
}