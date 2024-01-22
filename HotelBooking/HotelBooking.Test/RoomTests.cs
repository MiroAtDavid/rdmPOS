using HotelBooking.Model;
using Xunit;
using Xunit.Abstractions;

namespace HotelBooking.HotelBooking.Test; 

public class RoomTests : DatabaseTest {
    private readonly ITestOutputHelper _testOutputHelper;

    public RoomTests(ITestOutputHelper testOutputHelper) {
        _testOutputHelper = testOutputHelper;
        _db.Database.EnsureCreated();

        var hotel = new Hotel(name: "hotel", stars: Stars.Five,
            new Address(Street: "street", Zip: "Zip", City: "City"));
        _db.Hotels.Add(hotel);
        var room = new Room(hotel: hotel, price: 50);
        _db.Rooms.Add(room);

        var Massage = new SpecialService("Massage", 50);
        var Sauna = new SpecialService("Sauna", 30);
        var Party = new SpecialService("Party", 20);
        _db.SpecialServices.Add(Massage);
        _db.SpecialServices.Add(Sauna);
        _db.SpecialServices.Add(Party);
        var roomDeluxe = new Deluxe(hotel: hotel, price: 200 );
        roomDeluxe.AddSpecialService(Massage);
        roomDeluxe.AddSpecialService(Sauna);
        roomDeluxe.AddSpecialService(Party);
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
        decimal specialServicePricetotal = 0;
        foreach (var rooom in hotel.HotelRooms) {
            if (rooom.GetType().Equals(typeof(Room))) {
                Assert.True(rooom.Price == 50);
            }
            else if (rooom is Deluxe deluxeRoom) {
                specialServicePricetotal = deluxeRoom.CalculateSpecialServicePrice();
                Assert.True(rooom.Price == 200 + specialServicePricetotal);
            } else {
               Assert.True(rooom.Price == 400);
            }
        }
        _db.ChangeTracker.Clear();
    }
}