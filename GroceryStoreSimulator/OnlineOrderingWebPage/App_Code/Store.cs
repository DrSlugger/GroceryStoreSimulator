/* Authors: Kyle Marler, Evan Batsch
 * Class: Web Server Application Development
 * Assignment: Final Project
 * Date due: 2019-05-01
 * Description: This class represents a store, as chosen by the user in Default.aspx.
 * ...Data stored here is used later on, when the user's order is formed and submitted to the database.
 * Other: N/A
 */

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