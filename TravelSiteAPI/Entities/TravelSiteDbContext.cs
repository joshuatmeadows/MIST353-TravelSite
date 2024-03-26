using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TravelSiteAPI.Entities;

public partial class TravelSiteDbContext : DbContext
{
    public TravelSiteDbContext()
    {
    }

    public TravelSiteDbContext(DbContextOptions<TravelSiteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartLine> CartLines { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelRating> HotelRatings { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationLine> ReservationLines { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomAvailiability> RoomAvailiabilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD797759A1470");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CartID");
            entity.Property(e => e.GuestId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("guestID");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("userID");
        });

        modelBuilder.Entity<CartLine>(entity =>
        {
            entity.HasKey(e => e.CartLineId).HasName("PK__CartLine__5D1C7139DBDDB43C");

            entity.Property(e => e.Adults).HasColumnName("adults");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.Children).HasColumnName("children");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.RoomAvailiabilityId).HasColumnName("RoomAvailiabilityID");

            entity.HasOne(d => d.Cart).WithMany()
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartLines__CartI__756D6ECB");

            entity.HasOne(d => d.RoomAvailiability).WithMany()
                .HasForeignKey(d => d.RoomAvailiabilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartLines__RoomA__76619304");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotel__46023BBF4BC469D0");

            entity.ToTable("Hotel");

            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Latitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("longitude");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Zipcode).HasMaxLength(20);
        });

        modelBuilder.Entity<HotelRating>(entity =>
        {
            entity.HasKey(e => e.HotelRatingsId).HasName("PK__HotelRat__02B371BDEDFF3049");

            entity.Property(e => e.HotelRatingsId).HasColumnName("HotelRatingsID");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("userID");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelRatings)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HotelRati__Hotel__4BAC3F29");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.HotelPhotoId).HasName("PK__Photo__7F50D38C4551682A");

            entity.ToTable("Photo");

            entity.Property(e => e.HotelPhotoId).HasColumnName("HotelPhotoID");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Photo1).HasColumnName("Photo");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Photos)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Photo__HotelID__503BEA1C");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F04713CB7B2");

            entity.ToTable("Reservation");

            entity.Property(e => e.ReservationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ReservationID");
            entity.Property(e => e.Fees)
                .HasColumnType("money")
                .HasColumnName("fees");
            entity.Property(e => e.GuestId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("guestID");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Subtotal)
                .HasColumnType("money")
                .HasColumnName("subtotal");
            entity.Property(e => e.Tax)
                .HasColumnType("money")
                .HasColumnName("tax");
            entity.Property(e => e.Total)
                .HasColumnType("money")
                .HasColumnName("total");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("userID");
        });

        modelBuilder.Entity<ReservationLine>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Adults).HasColumnName("adults");
            entity.Property(e => e.Children).HasColumnName("children");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.ReservationStatus).HasMaxLength(100);
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(d => d.Reservation).WithMany()
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Reser__571DF1D5");

            entity.HasOne(d => d.Room).WithMany()
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__RoomI__5812160E");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__32863919FD7FFF0B");

            entity.ToTable("Room");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.NumberNum).HasColumnName("numberNum");
            entity.Property(e => e.RoomType)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Room__HotelID__398D8EEE");
        });

        modelBuilder.Entity<RoomAvailiability>(entity =>
        {
            entity.HasKey(e => e.RoomAvailiabilityId).HasName("PK__RoomAvai__642359A2CD8EE794");

            entity.ToTable("RoomAvailiability");

            entity.HasIndex(e => new { e.RoomId, e.AvDate }, "RoomDateUnique").IsUnique();

            entity.Property(e => e.RoomAvailiabilityId).HasColumnName("RoomAvailiabilityID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAvailiabilities)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoomAvail__RoomI__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
