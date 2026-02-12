using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesign;

public class Product
{
    public required string Name { get; init; }
    public required int Quantity { get; init; }
    public required decimal Price { get; init; }
    // decimal is a decimal floating point 

    // Todo#1: create computed property "TotalPrice" as decimal
    /*public decimal TotalPrice
    {
        get
        {
            var totalPrice = Price * Quantity;
            return totalPrice;
        }
    }*/

    // Arrow function
    public decimal TotalPrice => Price * Quantity;

    // Todo#2: override ToString() method
    public override string ToString() =>
        $"Product Name: {Name}\n" +
        $"Quantity {Quantity}\n" +
        $"Total Price: {TotalPrice}\n";
}
