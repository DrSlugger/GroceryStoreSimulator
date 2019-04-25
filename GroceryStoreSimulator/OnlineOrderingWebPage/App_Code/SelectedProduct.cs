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
    public SelectedProduct(Product product, int quantity) : base(product.SKU, product.brand, product.description, product.price)
    {
        this.brand = product.brand;
        this.SKU = product.SKU;
        this.description = description;
        this.price = price;
        this.quantity = quantity;
    }
}