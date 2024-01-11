using HotelBooking.Model;
using Xunit;
using Xunit.Abstractions;

namespace HotelBooking.HotelBooking.Test; 

public class BookingTests : DatabaseTest{
    private readonly ITestOutputHelper _testOutputHelper;

    public BookingTests(ITestOutputHelper testOutputHelper) {
        _testOutputHelper = testOutputHelper;
        _db.Database.EnsureCreated();

        var hotel = new Hotel(name: "hotel", stars: Stars.Five, new Address(Street: "street", Zip: "Zip", City: "City"));
        _db.Hotels.Add(hotel);
        var room = new Room(hotel: hotel, price: 50);
        _db.Rooms.Add(room);
        
        var guest = new Guest(firstname: "fn", lastname: "ln",
            new Address(Street: "street2", Zip: "Zip2", City: "City2"));
        _db.Guests.Add(guest);

        var booking = new Booking(hotel, date: new DateTime(2022, 1, 1), guest, 5);
        guest.AddBooking(booking);
        booking.AddBookingRoom(room);

        _db.SaveChanges();
    }

    [Fact]
    public void AddBookingSuccessTest() {
        var booking = _db.Bookings.First(); 
        Assert.True(booking.Rooms.ToList().Count == 1);
        _testOutputHelper.WriteLine(booking.Rooms.Count.ToString());
        _db.ChangeTracker.Clear();
    }
    
    [Fact]
    public void CalculateBookingPriceSuccessTest() {
        var hotel = new Hotel(name: "hotel",stars: Stars.Four, new Address(Street: "street", Zip: "Zip", City: "City"));
        _db.Hotels.Add(hotel);
        
        var room = new Room(hotel: hotel, price: 100);
        var room1 = new Room(hotel: hotel, price: 100);
        var room2 = new Room(hotel: hotel, price: 100);
        var room3 = new Room(hotel: hotel, price: 100);
        _db.Rooms.Add(room);
        _db.Rooms.Add(room1);
        _db.Rooms.Add(room2);
        _db.Rooms.Add(room3);

        var guest = new Guest(firstname: "fn", lastname: "ln",
            new Address(Street: "street2", Zip: "Zip2", City: "City2"));
        _db.Guests.Add(guest);
        
        var booking = new Booking(hotel, date: new DateTime(2022, 1, 1), guest, 5);
        
        booking.AddBookingRoom(room);
        booking.AddBookingRoom(room1);
        booking.AddBookingRoom(room2);
        booking.AddBookingRoom(room3);

        booking.CalculateBookingPrice();

        // Assert
        decimal expectedPrice = (room.Price + room1.Price + room2.Price + room3.Price) * booking.BookingDuration;
        Assert.Equal(expectedPrice, booking.BookingPrice);
        _db.ChangeTracker.Clear();
    }

    
    
}