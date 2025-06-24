using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FlightReservationSystem.Models;

namespace FlightReservationSystem.Data
{
    public class FlightReservationDbContext : IdentityDbContext<ApplicationUser>
    {
        public FlightReservationDbContext(DbContextOptions<FlightReservationDbContext> options)
            : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Checkin> Checkins { get; set; }
        public DbSet<BookingPassenger> BookingPassengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique constraint for Airline IATA code
            modelBuilder.Entity<Airline>()
                .HasIndex(a => a.IATA)
                .IsUnique();

            // Configure BookingPassenger entity
            modelBuilder.Entity<BookingPassenger>(entity =>
            {
                entity.HasKey(bp => bp.Id);

                entity.HasIndex(bp => new { bp.BookingId, bp.PassengerId })
                      .IsUnique();

                entity.HasOne(bp => bp.Booking)
                      .WithMany(b => b.BookingPassengers)
                      .HasForeignKey(bp => bp.BookingId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(bp => bp.Passenger)
                      .WithMany(p => p.BookingPassengers)
                      .HasForeignKey(bp => bp.PassengerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Checkin → Booking relationship
            modelBuilder.Entity<Checkin>()
                .HasOne(c => c.Booking)
                .WithMany(b => b.Checkins)
                .HasForeignKey(c => c.BookingId);

            // Configure Booking → Passenger relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Passenger)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PassengerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Configure Booking → Flight relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Flight)
                .WithMany()
                .HasForeignKey(b => b.FlightId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Configure Flight → FromAirport relationship
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.FromAirport)
                .WithMany()
                .HasForeignKey(f => f.FromAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Flight → ToAirport relationship
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.ToAirport)
                .WithMany()
                .HasForeignKey(f => f.ToAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure decimal precision for Price and Amount fields
            modelBuilder.Entity<Flight>()
                .Property(f => f.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Booking>()
                .Property(b => b.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}
