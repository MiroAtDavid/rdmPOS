using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Model; 

[Table("Employee")]
public class Manager : Employee {
    
    // Properties Manager
    public string Vehicle { get; set; }
    public string Phone { get; set; }

    // Constructor with properties
    public Manager(string firstName, string lastName, decimal salary, Address address, Hotel hotel, string vehicle, string phone) : base(firstName, lastName, salary, address, hotel) {
        Vehicle = vehicle;
        Phone = phone;
        Role = "Manager";
    }
#pragma warning disable CS8618 

    // Constructor
    protected Manager() { }
#pragma warning disable CS8618 
    
    // Abstract Methods
    public override bool PerformDuties() {
        Console.WriteLine($"Employee {LastName} in the role of Manager is performing their duties.");
        Console.WriteLine("Attending meetings, responding to calls, and collaborating with colleagues.");
        return true;
    }
}