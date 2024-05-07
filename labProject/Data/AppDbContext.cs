using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : 
    base(options) { 

    }
    public DbSet<Room> rooms{ get; set; }

    public DbSet<Reservation> reservations{ get; set; } 

    public DbSet<LogRecord> logRecords{ get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<LogRecord>()
        .HasOne(lr => lr.Reservation)
        .WithMany()
        .HasForeignKey(lr => lr.ReservationId)
        .OnDelete(DeleteBehavior.Cascade); 
    
     modelBuilder.Entity<LogRecord>()
        .HasOne(lr => lr.Room)
        .WithMany()
        .HasForeignKey(lr => lr.RoomId)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Reservation>()
        .HasOne(r => r.Room)
        .WithMany()
        .HasForeignKey(r => r.RoomId)
        .OnDelete(DeleteBehavior.SetNull);
}


}