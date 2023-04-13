namespace TestTaskVMedia.DataStructures;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class RailroadTicketsContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Train> Trains { get; set; }

    public RailroadTicketsContext(
        DbContextOptions<RailroadTicketsContext> options,
        IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Configuration.GetConnectionString("RTDatabase");
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .HasKey(t => t.Id);
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Passenger)
            .WithMany(p => p.Tickets)
            .HasForeignKey(t => t.PassengerId);
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Train)
            .WithMany(t => t.Tickets)
            .HasForeignKey(t => t.TrainId);

        modelBuilder.Entity<Passenger>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Passenger>()
            .HasMany(p => p.Tickets)
            .WithOne(t => t.Passenger)
            .HasForeignKey(t => t.PassengerId);

        modelBuilder.Entity<Train>()
            .HasKey(t => t.Id);
        modelBuilder.Entity<Train>()
            .HasMany(t => t.Tickets)
            .WithOne(t => t.Train)
            .HasForeignKey(t => t.TrainId);
    }
}