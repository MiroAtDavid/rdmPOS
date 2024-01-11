using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Model; 
//[Table("Guest")]
public class Guest {
    
    // Properties
    public Guid Id { get; private set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Address Address { get; set; }  
    protected List<Booking> _bookings = new();
    public virtual IReadOnlyCollection<Booking> Bookings => _bookings;
    
    // Constructor
    public Guest(string firstname, string lastname, Address address) {
        Id = Guid.NewGuid();
        Firstname = firstname;
        Lastname = lastname;
        Address = address;
    }
#pragma warning disable CS8618
    // Consturctor
    protected Guest() { }
#pragma warning restore CS8618
    
    
    // Other Methods
    // Add booking to guest
    public void AddBooking(Booking booking) {
        _bookings.Add(booking);
    }
}
