using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Model; 

//[Table("Room")]
public class Room {
    
    // Properties
    public int Id { get; private set; }
    public decimal Price { get; set; }
    public int HotelId { get; private set; }
    public virtual Hotel Hotel { get; private set; }
    public string RoomType { get; protected set; }
    
    // Constructor with properties
    public Room(Hotel hotel, decimal price)
    {
        Hotel = hotel;
        Price = price;
        RoomType = "Standard";
    }
#pragma warning disable CS8618 
    
    // Constructor 
    protected Room() { }
#pragma warning restore CS8618 

}
