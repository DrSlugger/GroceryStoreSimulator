using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SelectedProduct
/// </summary>
public class SelectedProduct : Product
{
    private int mQuantity;

    public int quantity { get { return mQuantity; } set { mQuantity = value; } }
    public SelectedProduct()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}