using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Model; 
[Table("Employee")]
public abstract class Employee {
    
    // Properties
    public Guid Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
    public Address Address { get; set; }
    public int HotelId { get; private set; }
    public virtual Hotel Hotel { get; private set; }
    public string Role { get; protected set; }

    // Constructor with properties
    public Employee(string firstName, string lastName, decimal salary, Address address, Hotel hotel) {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
        Address = address;
        Hotel = hotel;
    }
#pragma warning disable CS8618 
    
    // Constructor 
    protected Employee() { }
    

#pragma warning restore CS8618 

    
    // Common abstract methods for all employees
    public abstract bool PerformDuties();


}