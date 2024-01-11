using System.Diagnostics;
using HotelBooking.HotelBooking.Application.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.HotelBooking.Test; 

public class DatabaseTest : IDisposable {
    private readonly SqliteConnection _connection;
    protected readonly HotelContext _db;

    public DatabaseTest() {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        var opt = new DbContextOptionsBuilder()
            .UseSqlite(_connection)  // Keep connection open (only needed with SQLite in memory db)
            .UseLazyLoadingProxies()
            .LogTo(message => Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging()
            .Options;
        _db = new HotelContext(opt);
    }

    public void Dispose() {
        _db.Dispose();
        _connection.Dispose();
    }
}