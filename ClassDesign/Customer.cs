using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassDesign;

// Usage of JsonIgnore: https://stackoverflow.com/questions/10169648/how-to-exclude-property-from-json-serialization
public class Customer
{
    // auto-implemented properties
    // normal property have a variable
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required DateOnly DateOfBirth { get; init; }

    // computed properties
    [JsonIgnore] // Tag for identify that field be don't collect

    // Property don't have () same method
    public string FullName => FirstName + " " + LastName;

    [JsonIgnore]
    // This is compute property
    public int Age
    {
        get
        {   // Todo: Refactoring (Extract and Move to Utility Class)
            // from : https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday
            var today = DateTime.Today;
            var birth = DateOfBirth.ToDateTime(new TimeOnly());
            var age = today.Year - birth.Year; // Difference between current year and birth year

            // If the birthdate hasn't arrived yet, subtract one year.
            if (birth.Date > today.AddYears(-age)) 
                age--;

            return age;
        }
    }

    public Customer() { } // Empty Constructor can created autometric by default

    [SetsRequiredMembers] // To set up every field when new object
    public Customer(Customer obj) // Copy Constructor
    {
        FirstName = obj.FirstName;
        LastName = obj.LastName;
        DateOfBirth = obj.DateOfBirth;
    }
    

    // Every object can override ToString()
    public override string ToString() => $"(FirstName={FirstName},DOB={DateOfBirth})";
}
