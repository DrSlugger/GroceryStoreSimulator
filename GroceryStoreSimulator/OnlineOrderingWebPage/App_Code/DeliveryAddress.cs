using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeliverAddress
/// </summary>

namespace OnlineOrder.App_Code
{
    public class DeliveryAddress
    {
        private string mStreet;
        private string mCity;
        private string mState;
        private string mZip;

        public string street { get { return mStreet; } set { mStreet = value; } }
        public string city { get { return mCity; } set { mCity = value; } }
        public string state { get { return mState; } set { mState = value; } }
        public string zip { get { return mZip; } set { mZip = value; } }

        public DeliveryAddress(string street, string city, string state, string zip)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }
    }
}