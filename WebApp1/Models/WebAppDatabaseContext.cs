using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models;

public partial class WebAppDatabaseContext : DbContext
{
    public WebAppDatabaseContext()
    {
    }

    public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LogRecord> logRecords { get; set; }

    public virtual DbSet<Reservation> reservations { get; set; }

    public virtual DbSet<Room> rooms { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = WebApplication.CreateBuilder();
        var connectionString = builder.Configuration.GetConnectionString ("MyConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogRecord>(entity =>
        {
            entity.ToTable("logRecords");

            entity.HasIndex(e => e.ReservationId, "IX_logRecords_ReservationId");

            entity.HasIndex(e => e.RoomId, "IX_logRecords_RoomId");

            entity.HasOne(d => d.Reservation).WithMany(p => p.LogRecords)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Room).WithMany(p => p.LogRecords)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.ToTable("reservations");

            entity.HasIndex(e => e.RoomId, "IX_reservations_RoomId");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("rooms");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
