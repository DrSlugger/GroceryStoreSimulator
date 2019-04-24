using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    private string mBrand;
    private string mDescription;
    private double mPrice;

    public string brand { get { return mBrand; } set { mBrand = value; } }
    public string description{ get { return mDescription; } set { mDescription = value; } }
    public double price { get { return mPrice; } set { mPrice = value; } }
    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}