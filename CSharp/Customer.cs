using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp;

public class Customer
{
    public required string Name { get; init; }
    //public string? Address { get; init; } = null;
    // Exercise 6.2
    public string? Address { get; set; }

    //public int? Age { get; init; } = null;
    // Exercise 6.3
    public required int Age { get; init; }
    public required List<Product> Order { get; init; }
}

// Exercise 6.1
public class Product
{
    //public required string Name { get; init; }
    //public required decimal Price { get; init; }
    public string Name { get; }
    public string Address { get; }
    
    // Must be added constructor
    public Product(string name, string address)
    {
        Name = name;
        Address = address;
    }

    // Exercise 6.4
    public decimal? Price { get; private set; }
}


