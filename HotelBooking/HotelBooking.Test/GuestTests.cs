using HotelBooking.Model;
using Xunit;

namespace HotelBooking.HotelBooking.Test; 

public class GuestTests : DatabaseTest{
    public GuestTests() {
        _db.Database.EnsureCreated();
        var guest = new Guest(firstname: "fn", lastname: "ln",
            address: new Address(Street: "street", Zip: "Zip", City: "City"));
        _db.Guests.Add(guest);
        var booking = new Booking(
            new Hotel(name: "HotelName", stars: Stars.Three, address: new Address(Street: "street1", Zip: "Zip1", City: "City1")),
            date: new DateTime(2022, 1, 1),
            guest: new Guest(firstname:"fn", lastname:"ln", new Address(Street: "street", Zip: "Zip", City: "City")),
            bookingDuration:5);
        guest.AddBooking(booking);
        _db.SaveChanges();
    }

    [Fact]
    public void AddBookingSuccessTest() {
        Assert.True(_db.Guests.ToList().Count() == 1);
        Assert.True(_db.Guests.ToList().First().Bookings.Count == 1);
        _db.ChangeTracker.Clear();
    }
}