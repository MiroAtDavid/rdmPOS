namespace HotelBooking.Model; 

public class Deluxe : Room {
    
    // Properties
    public int SpecialService { get; set; }

    // Constructor with properties
    public Deluxe(Hotel hotel, decimal price, int specialService) : base(hotel, price) {
        SpecialService = specialService;
        RoomType = "Deluxe";
    }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    // Constructor
    protected Deluxe() {}
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    // Other Methods
    // Add SpecialService price
    public void AddSpecialServicePrice() {
        Price += (SpecialService * 100);
    }
}