using HotelBooking.Model;
using Xunit;
using Xunit.Abstractions;

namespace HotelBooking.HotelBooking.Test; 

public class RoomTests : DatabaseTest {
    public RoomTests() {
        _db.Database.EnsureCreated();

        var hotel = new Hotel(name: "hotel", stars: Stars.Five,
            new Address(Street: "street", Zip: "Zip", City: "City"));
        _db.Hotels.Add(hotel);
        var room = new Room(hotel: hotel, price: 50);
        _db.Rooms.Add(room);

        var roomDeluxe = new Deluxe(hotel: hotel, price: 200, specialService: 4);
        roomDeluxe.AddSpecialServicePrice();
        _db.Deluxes.Add(roomDeluxe);

        var roomSuit = new Suit(hotel: hotel, price: 100, jacuzzi: true);
        roomSuit.AddJacuzziPrice();
        _db.Suits.Add(roomSuit);

        _db.SaveChanges();
    }

    [Fact]
    public void AddRoomsSuccesTest() { 
        var hotel = _db.Hotels.First(); 
        Assert.True(hotel.HotelRooms.ToList().Count == 3);
        _db.ChangeTracker.Clear();
    }

    [Fact]
    public void CalculateRoomPrice() {
        var hotel = _db.Hotels.First();
        foreach (var rooom in hotel.HotelRooms) {
            if (rooom.GetType().Equals(typeof(Room))) {
                Assert.True(rooom.Price == 50);
            }
            else if (rooom.GetType().Equals(typeof(Deluxe))) {
               Assert.True(rooom.Price == 600);
            } else {
                Assert.True(rooom.Price == 400);
            }
        }
        _db.ChangeTracker.Clear();
    }
}