using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Object that will store the information for an order
/// </summary>
public class Order
{
    private string mLoyaltyID;
    private Store mStore;
    private int mStatusID;
    private DeliveryAddress mDeliveryAddress;
    private double mFinalPrice;

    public string loyaltyID { get { return mLoyaltyID; } set { mLoyaltyID = value; } }
    public Store store { get { return mStore } set { mStore = value; } }
    public int statusID { get { return mStatusID; } set { mStatusID = value; } }
    public DeliveryAddress deliveryAddress { get { return mDeliveryAddress; } set { mDeliveryAddress = value; } }

    public double finalPrice { get { return mFinalPrice; } set { mFinalPrice = value; } }

    public Order()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}