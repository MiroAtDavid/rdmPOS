namespace HotelBooking.Model;

public class Suit: Room {
    // Properties
    public bool Jacuzzi { get; set; }

    // Constructor with properties
    public Suit(Hotel hotel, decimal price, bool jacuzzi) : base(hotel, price) {
        Jacuzzi = jacuzzi;
        RoomType = "Suit";
    }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    // Constructor
    protected Suit () {}
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    // Other Methods
    // Add Jacuzzi price
    public void AddJacuzziPrice() {
        Price += Jacuzzi ? 300 : 100;
    }
}