using System.Diagnostics.Metrics;
using HotelBooking.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace HotelBooking.HotelBooking.Test; 

public class HotelTests : DatabaseTest {
    private readonly ITestOutputHelper _testOutputHelper;

    public HotelTests (ITestOutputHelper testOutputHelper) {
        _testOutputHelper = testOutputHelper;
        _db.Database.EnsureCreated();
        
        var hotel = new Hotel(name: "hotel", stars: Stars.Five, new Address(Street: "street", Zip: "Zip", City: "City"));
        _db.Hotels.Add(hotel);
        
        var employee2 = new Manager(firstName: "Hans", lastName: "Zimmer", 
            salary: 3500,
            address: new Address(Street: "street5", Zip: "Zip5", City: "City25"),
            hotel,
            vehicle: "Porsche",
            phone: "03434033434");
        //_db.Employees.Add(employee2);
        
        var employee3 = new Receptionist(firstName: "Hansi", lastName: "Zitter", 
            salary: 2500,
            address: new Address(Street: "street5", Zip: "Zip5", City: "City25"),
            hotel,
            email: "rezep@hotel.com");
        //_db.Employees.Add(employee3);
        hotel.AddHotelEmployee(employee2);
        hotel.AddHotelEmployee(employee3);
        
        var room = new Room(hotel: hotel, price: 50);
        //_db.Rooms.Add(room);
        hotel.AddHotelRoom(room);

        var roomDeluxe = new Deluxe(hotel: hotel, price: 200, specialService: 4);
        //_db.Deluxes.Add(roomDeluxe);
        hotel.AddHotelRoom(roomDeluxe);


        var roomSuit = new Suit(hotel: hotel, price: 100, jacuzzi: true);
        //_db.Suits.Add(roomSuit);
        hotel.AddHotelRoom(roomSuit);

        
        var guest = new Guest(firstname: "fn", lastname: "ln",
            new Address(Street: "street2", Zip: "Zip2", City: "City2"));
        _db.Guests.Add(guest);
        
        var booking = new Booking(hotel, date: new DateTime(2022, 1, 1), guest, 5);
        guest.AddBooking(booking);
        booking.AddBookingRoom(room);
        hotel.AddBooking(booking);
        
        _db.SaveChanges();
    }
    
    [Fact]
    public void AddHotelEmployeeSuccessTest() {
        var hotel = _db.Hotels.Include(hotel => hotel.HotelEmployees).First();
        _testOutputHelper.WriteLine(hotel.HotelEmployees.Count.ToString());
        Assert.True(hotel.Name.Equals("hotel"));
        Assert.True(hotel.HotelEmployees.Count == 2); 
    }   
    
    [Fact]
    public void AddHotelRoomSuccessTest() {
        var hotel = _db.Hotels.Include(hotel => hotel.HotelRooms).First();
        Assert.True(hotel.Name.Equals("hotel"));
        Assert.True(hotel.HotelRooms.Count == 3); 
        _db.ChangeTracker.Clear();
    }

    [Fact]
    public void AddBookingSuccesTest() {
        var hotel = _db.Hotels.Include(hotel => hotel.Bookings).First();
        Assert.True(hotel.Name.Equals("hotel"));
        Assert.True(hotel.Bookings.Count == 1);
        _db.ChangeTracker.Clear();
    }

    [Fact]
    public void CheckDutiesSuccesTest() {
        var hotel = _db.Hotels.Include(hotel => hotel.HotelEmployees).First();
        foreach (var e in hotel.HotelEmployees) {
            Assert.True(e.PerformDuties());
        }
        _db.ChangeTracker.Clear();
    }

    [Fact]
    public void CheckBookingIsValidSuccessTest() {
        var hotel = _db.Hotels.Include(hotel => hotel.Bookings).First();
        var guest = new Guest(firstname: "fn", lastname: "ln",
            new Address(Street: "street2", Zip: "Zip2", City: "City2"));
        var booking = new Booking(hotel, date: new DateTime(2024, 1, 1), guest, 5);
        hotel.AddBooking(booking);
        var bookingConfirmation = hotel.CreateBookingConfirmation(booking);
        Assert.NotNull(bookingConfirmation);
        Assert.NotNull(bookingConfirmation.Booking);
        Assert.NotNull(bookingConfirmation.ConfirmationCode);
        _db.ChangeTracker.Clear();
    }
}