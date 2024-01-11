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
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
        // Hotel
        modelBuilder.Entity<Hotel>().OwnsOne(h => h.Address);
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.HotelRooms)
            .WithOne(h => h.Hotel)
            .HasForeignKey(h => h.HotelId)
            .IsRequired();
        
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.HotelEmployees)
            .WithOne(h => h.Hotel)
            .HasForeignKey(h => h.HotelId)
            .IsRequired();
        
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.Bookings)
            .WithOne(h => h.Hotel)
            .HasForeignKey(h => h.HotelId)
            .IsRequired();
        
        // Room
        modelBuilder.Entity<Room>().HasDiscriminator(h => h.RoomType);
        
        // Guest
        modelBuilder.Entity<Guest>().OwnsOne(g => g.Address);
        modelBuilder.Entity<Guest>()
            .HasMany(g => g.Bookings)
            .WithOne(g => g.Guest)
            .HasForeignKey(g => g.GuestId)
            .IsRequired();
        
        // Employee
        modelBuilder.Entity<Employee>().OwnsOne(e => e.Address);
        modelBuilder.Entity<Employee>().HasDiscriminator(h => h.Role);

        // Manager
        modelBuilder.Entity<Manager>().OwnsOne(e => e.Address);

        // Receptionist
        modelBuilder.Entity<Receptionist>().OwnsOne(e => e.Address);
        
        // Booking
        /*modelBuilder.Entity<Booking>()
            .HasMany(b => b.Rooms)
            .WithOne(b => b.Booking)
            .HasForeignKey(b => b.BookingId)
            .IsRequired();*/
    }
}
    

