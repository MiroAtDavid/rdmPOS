using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Model; 
[Table("Employee")]
public class Receptionist : Employee {
    
    // Properties
    public string Email { get; set; }

    // Constructor with properties 
    public Receptionist(string firstName, string lastName, decimal salary, Address address, Hotel hotel, string email) : base(firstName, lastName, salary, address, hotel) {
        Email = email;
        Role = "Receptionist";
    }
#pragma warning disable CS8618 

    // Constructor
    protected Receptionist(string email) { }
#pragma warning disable CS8618 
    
    public override bool PerformDuties() {
        Console.WriteLine($"Employee {LastName} in the role of Recptionist is performing their duties.");
        Console.WriteLine("Attending meetings, responding to calls, and collaborating with colleagues.");
        return true;
    }
}