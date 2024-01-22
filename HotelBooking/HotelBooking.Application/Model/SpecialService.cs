namespace HotelBooking.Model; 

public class SpecialService {
    
    // Properties
    public int Id { get; private set; }
    //public int DeluxeId { get; private set; }
    //public virtual Deluxe Deluxe { get; private set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    // Consturctor with parameters
    public SpecialService(string name, decimal price) {
        Name = name;
        Price = price;
    }
#pragma warning disable CS8618
    
    // Constructor
    protected SpecialService (){}
#pragma warning disable CS8618
    
}