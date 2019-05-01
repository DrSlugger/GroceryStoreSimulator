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
        private DeliveryAddress mDeliveryAddress;
        private double mFinalPrice;

        public int orderID { get { return mOrderID; } set { mOrderID = value; } }
        public string loyaltyID { get { return mLoyaltyID; } set { mLoyaltyID = value; } }
        public Store store { get { return mStore; } set { mStore = value; } }
        public int statusID { get { return mStatusID; } set { mStatusID = value; } }
        public DeliveryAddress deliveryAddress { get { return mDeliveryAddress; } set { mDeliveryAddress = value; } }

        public double finalPrice { get { return mFinalPrice; } set { mFinalPrice = value; } }

        public Order(int orderID, string loyaltyID, Store store, int statusID, DeliveryAddress deliveryAddress)
        {
            this.orderID = orderID;
            this.loyaltyID = loyaltyID;
            this.store = store;
            this.statusID = statusID;
            this.deliveryAddress = deliveryAddress;
        }
    }
}