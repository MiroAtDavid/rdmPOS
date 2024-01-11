using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Model; 

[Table("Booking")]
public class Booking {

    // Propperties
    public Guid Id { get; private set; }
    public DateTime Date { get; set; }
    public Guid GuestId { get; private set; }             
    public virtual Guest Guest { get; private set; }
    public int HotelId { get; private set; }
    public virtual Hotel Hotel { get; private set; }
    protected List<Room> _rooms = new();
    public virtual IReadOnlyCollection<Room> Rooms => _rooms;
    public decimal BookingPrice { get;  private set; }
    public int BookingDuration { get; private set; }
    
    // Constructor
    public Booking(Hotel hotel, DateTime date, Guest guest, int bookingDuration) {
        Id = Guid.NewGuid(); // Generate a new Guid for the Booking
        Hotel = hotel;
        Date = date; 
        Guest = guest;
        GuestId = guest.Id; // Set the GuestId using the Guest's Guid
        BookingDuration = bookingDuration;
    }
#pragma warning disable CS8618 
    
    // Constructor
    protected Booking() { }
#pragma warning restore CS8618
    
    // Other Methods
    // Add room to booking
    public void AddBookingRoom(Room room) {
        _rooms.Add(room);
    }

    // Calculate booking price
    public void CalculateBookingPrice() {
        BookingPrice = _rooms.Sum(room => room.Price) * BookingDuration;
    }
}
