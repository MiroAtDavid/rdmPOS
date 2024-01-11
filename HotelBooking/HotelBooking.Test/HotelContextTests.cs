using Xunit;

namespace HotelBooking.HotelBooking.Test; 

public class HotelContextTests : DatabaseTest{
    [Fact]
    public void CreateDatabaseTest() {
        _db.Database.EnsureCreated();
    }
}