using HotelBooking.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.HotelBooking.Application.Infrastructure; 
//using HotelBooking.Test;


public class HotelContext : DbContext { 
    public HotelContext(DbContextOptions opt) : base(opt) { } 
    public DbSet<Guest> Guests => Set<Guest>(); 
    public DbSet<Booking> Bookings => Set<Booking>(); 
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Suit> Suits => Set<Suit>();
    public DbSet<Deluxe> Deluxes => Set<Deluxe>();
    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Manager> Managers => Set<Manager>();
    public DbSet<Receptionist> Receptionists => Set<Receptionist>();
    public DbSet<SpecialService> SpecialServices => Set<SpecialService>();
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
        // Hotel
        modelBuilder.Entity<Hotel>().OwnsOne(h => h.Address);
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.HotelRooms)
            .WithOne(r => r.Hotel)
            .HasForeignKey(r => r.HotelId)
            .IsRequired();
        
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.HotelEmployees)
            .WithOne(e => e.Hotel)
            .HasForeignKey(e => e.HotelId)
            .IsRequired();
        
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.Bookings)
            .WithOne(b => b.Hotel)
            .HasForeignKey(b => b.HotelId)
            .IsRequired();
        
        // Room
        modelBuilder.Entity<Room>().HasDiscriminator(h => h.RoomType);
        
        // Guest
        modelBuilder.Entity<Guest>().OwnsOne(g => g.Address);
        modelBuilder.Entity<Guest>()
            .HasMany(g => g.Bookings)
            .WithOne(b => b.Guest)
            .HasForeignKey(b => b.GuestId)
            .IsRequired();
        
        // Employee
        modelBuilder.Entity<Employee>().OwnsOne(e => e.Address);
        modelBuilder.Entity<Employee>().HasDiscriminator(h => h.Role);

        // Manager
        modelBuilder.Entity<Manager>().OwnsOne(e => e.Address);

        // Receptionist
        modelBuilder.Entity<Receptionist>().OwnsOne(e => e.Address);

        modelBuilder.Entity<Deluxe>()
            .HasMany(d => d.SpecialServices);
        // Booking
        /*modelBuilder.Entity<Booking>()
            .HasMany(b => b.Rooms)
            .WithOne(b => b.Booking)
            .HasForeignKey(b => b.BookingId)
            .IsRequired();*/
    }
}
    

