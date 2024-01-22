namespace HotelBooking.Model; 

public class Deluxe : Room {
    
    // Properties
    protected List<SpecialService> _specialServices = new();
    public virtual IReadOnlyCollection<SpecialService> SpecialServices => _specialServices;

    // Constructor with properties
    public Deluxe(Hotel hotel, decimal price) : base(hotel, price) {
        RoomType = "Deluxe";
    }
#pragma warning disable CS8618 
    
    // Constructor
    protected Deluxe() {}
#pragma warning disable CS8618 

    // Other Methods
    // Add SpecialService 
    public void AddSpecialService(SpecialService specialService) {
        _specialServices.Add(specialService);
    }

    // Calculate total price of SpecialServices
    public decimal CalculateSpecialServicePrice() {
        Price = Price + _specialServices.Sum(specialService => specialService.Price);
        return _specialServices.Sum(specialService => specialService.Price);
    }
}