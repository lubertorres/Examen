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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,2526;Initial Catalog=BaseEntity;Persist Security Info=False;User ID=sa;Password=root1992*;MultipleActiveResultSets=False;Encrypt=false;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillboardEntity>(entity =>
        {
            entity.HasKey(e => e.BillboardId).HasName("PK__Billboar__C79AA5BA9A04B354");

            entity.HasIndex(e => e.BillboardId, "UQ__Billboar__C79AA5BB68E70B0E").IsUnique();

            entity.Property(e => e.BillboardId).ValueGeneratedNever();
            entity.Property(e => e.DateB)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Movie).WithMany(p => p.BillboardEntity)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Billboard__Movie__55F4C372");

            entity.HasOne(d => d.Room).WithMany(p => p.BillboardEntity)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Billboard__RoomI__56E8E7AB");
        });

        modelBuilder.Entity<BookingEntity>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__BookingE__73951AED2B5BEEB6");

            entity.HasIndex(e => e.BookingId, "UQ__BookingE__73951AEC16EE4FE6").IsUnique();

            entity.Property(e => e.BookingId).ValueGeneratedNever();
            entity.Property(e => e.DateB)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Billboard).WithMany(p => p.BookingEntity)
                .HasForeignKey(d => d.BillboardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingEn__Billb__5CA1C101");

            entity.HasOne(d => d.Customer).WithMany(p => p.BookingEntity)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingEn__Custo__5D95E53A");

            entity.HasOne(d => d.Seat).WithMany(p => p.BookingEntity)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingEn__SeatI__5BAD9CC8");
        });

        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.HasKey(e => e.DocumentNumber).HasName("PK__customer__B50EB8A727B98592");

            entity.ToTable("customerEntity");

            entity.HasIndex(e => e.DocumentNumber, "UQ__customer__B50EB8A64B224B2F").IsUnique();

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
            entity.HasKey(e => e.MovieId).HasName("PK__MovieEnt__4BD2941AD5F4B1DC");

            entity.HasIndex(e => e.MovieId, "UQ__MovieEnt__4BD2941BA15E5B1E").IsUnique();

            entity.Property(e => e.MovieId).ValueGeneratedNever();
            entity.Property(e => e.DateB)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Genero)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoomEntity>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__RoomEnti__328639398F37C1E0");

            entity.HasIndex(e => e.RoomId, "UQ__RoomEnti__328639384F20DED4").IsUnique();

            entity.Property(e => e.RoomId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SeatEntity>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__SeatEnti__311713F3137F4DC2");

            entity.HasIndex(e => e.SeatId, "UQ__SeatEnti__311713F2CECA0AAE").IsUnique();

            entity.Property(e => e.SeatId).ValueGeneratedNever();

            entity.HasOne(d => d.Room).WithMany(p => p.SeatEntity)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SeatEntit__RoomI__51300E55");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
