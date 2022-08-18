using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace interaction_bdd_crud.Models
{
    public partial class disquaireContext : DbContext
    {
        public disquaireContext()
        {
        }

        public disquaireContext(DbContextOptions<disquaireContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<AlbumArtist> AlbumArtists { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=root;database=disquaire", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("album");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedYear)
                    .HasColumnType("year")
                    .HasColumnName("created_year");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<AlbumArtist>(entity =>
            {
                entity.ToTable("album_artist");

                entity.HasIndex(e => e.IdArtist, "fk_album_artist_artist");

                entity.HasIndex(e => new { e.IdAlbum, e.IdArtist }, "uni_id_album_id_artist")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAlbum).HasColumnName("id_album");

                entity.Property(e => e.IdArtist).HasColumnName("id_artist");

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.AlbumArtists)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_album_artist_album");

                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany(p => p.AlbumArtists)
                    .HasForeignKey(d => d.IdArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_album_artist_artist");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.HasIndex(e => e.IdContact, "fk_reser_contact");

                entity.HasIndex(e => e.IdAlbum, "uni_id_album")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("booked_at");

                entity.Property(e => e.IdAlbum).HasColumnName("id_album");

                entity.Property(e => e.IdContact).HasColumnName("id_contact");

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithOne(p => p.Booking)
                    .HasForeignKey<Booking>(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_booking_album");

                entity.HasOne(d => d.IdContactNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.IdContact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reser_contact");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .HasColumnName("last_name");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .HasColumnName("mail");

                entity.Property(e => e.Password)
                    .HasMaxLength(40)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
