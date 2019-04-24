using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Store
/// </summary>
public class Store
{
    private string mStoreName;
    private int mStoreID;

    public string storeName { get { return mStoreName; } set { mStoreName = value; } }
    public int storeID { get { return mStoreID; } set { mStoreID= value; } }
    public Store()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}