using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Allows us to create an object for the ShoppingCart in the webform
/// </summary>
public class ShoppingCart
{
    private List<SelectedProduct> selectedProducts;
    public ShoppingCart()
    {
        selectedProducts = new List<SelectedProduct>();
    }

    public double CalculateTotal()
    {
        double finalPrice = 0;
        foreach (SelectedProduct p in selectedProducts)
        {
            finalPrice = p.quantity * p.price;
        }
        return finalPrice;
    }

    public void RemoveProduct(SelectedProduct product)
    {
        foreach (SelectedProduct p in selectedProducts)
        {
            if (p.SKU == product.SKU)
            {
                selectedProducts.Remove(p);
            }
        }
    }

    public void AddProduct(SelectedProduct product)
    {
        bool isInCart = false;
        foreach (SelectedProduct p in selectedProducts)
        {
            if (p.SKU == product.SKU)
            {
                isInCart = true;
                break;
            }
        }
        if (isInCart == false)
        {
            selectedProducts.Add(product);
        }
    }
}