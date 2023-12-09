using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Examen.Models;

public partial class BaseEntityContext : DbContext
{
    public BaseEntityContext()
    {
    }

    public BaseEntityContext(DbContextOptions<BaseEntityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillboardEntity> BillboardEntity { get; set; }

    public virtual DbSet<BookingEntity> BookingEntity { get; set; }

    public virtual DbSet<CustomerEntity> CustomerEntity { get; set; }

    public virtual DbSet<MovieEntity> MovieEntity { get; set; }

    public virtual DbSet<RoomEntity> RoomEntity { get; set; }

    public virtual DbSet<SeatEntity> SeatEntity { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillboardEntity>(entity =>
        {
            entity.HasKey(e => e.BillboardId).HasName("PK__Billboar__C79AA5BAE6F3F152");

            entity.HasIndex(e => e.BillboardId, "UQ__Billboar__C79AA5BB7B5BD85A").IsUnique();

            entity.Property(e => e.BillboardId).ValueGeneratedNever();
            entity.Property(e => e.DateB)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Movie).WithMany(p => p.BillboardEntity)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Billboard__Movie__51300E55");

            entity.HasOne(d => d.Room).WithMany(p => p.BillboardEntity)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Billboard__RoomI__5224328E");
        });

        modelBuilder.Entity<BookingEntity>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__BookingE__73951AED27102FA3");

            entity.HasIndex(e => e.BookingId, "UQ__BookingE__73951AEC3262AF37").IsUnique();

            entity.Property(e => e.BookingId).ValueGeneratedNever();
            entity.Property(e => e.DateB)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Billboard).WithMany(p => p.BookingEntity)
                .HasForeignKey(d => d.BillboardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingEn__Billb__57DD0BE4");

            entity.HasOne(d => d.Seat).WithMany(p => p.BookingEntity)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingEn__SeatI__56E8E7AB");
        });

        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.HasKey(e => e.DocumentNumber).HasName("PK__customer__B50EB8A77BE8C436");

            entity.ToTable("customerEntity");

            entity.Property(e => e.DocumentNumber)
                .ValueGeneratedNever()
                .HasColumnName("Document_number");
            entity.Property(e => e.DateC)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Phone_number");
        });

        modelBuilder.Entity<MovieEntity>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__MovieEnt__4BD2941AE3125185");

            entity.HasIndex(e => e.MovieId, "UQ__MovieEnt__4BD2941BCAB00575").IsUnique();

            entity.Property(e => e.MovieId).ValueGeneratedNever();
            entity.Property(e => e.DateB)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Genero)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoomEntity>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__RoomEnti__32863939C9ED7DBC");

            entity.HasIndex(e => e.RoomId, "UQ__RoomEnti__328639380BB5E314").IsUnique();

            entity.Property(e => e.RoomId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SeatEntity>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__SeatEnti__311713F3A1145971");

            entity.Property(e => e.SeatId).ValueGeneratedNever();

            entity.HasOne(d => d.Room).WithMany(p => p.SeatEntity)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SeatEntit__RoomI__4C6B5938");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
