using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Creates a store object
/// </summary>
namespace OnlineOrder.App_Code
{
    public class Store
    {
        private string mStoreName;
        private int mStoreID;

        public string storeName { get { return mStoreName; } set { mStoreName = value; } }
        public int storeID { get { return mStoreID; } set { mStoreID = value; } }
        public Store(string storeName, int storeID)
        {
            this.storeName = storeName;
            this.storeID = storeID;
        }
    }
}