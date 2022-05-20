﻿using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace hotel.Models.dbModels
{
    public partial class hotelContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public hotelContext()
        {

        }

        public hotelContext(DbContextOptions<hotelContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Habitacione> Habitaciones { get; set; }
        public virtual DbSet<MetodoPago> MetodoPagos { get; set; }
        public virtual DbSet<ReservacionHabitacion> ReservacionHabitacions { get; set; }
        public virtual DbSet<Reservacione> Reservaciones { get; set; }
        public virtual DbSet<Reseña> Reseñas { get; set; }
        public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Habitacione>(entity =>
            {
                entity.Property(e => e.IdHabitacion).ValueGeneratedNever();

                entity.HasOne(d => d.TipoHabitacionNavigation)
                    .WithMany(p => p.Habitaciones)
                    .HasForeignKey(d => d.TipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_habitaciones_tipoHabitacion");
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<ReservacionHabitacion>(entity =>
            {
                entity.HasKey(e => new { e.IdReservacion, e.IdHabitacion });

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.ReservacionHabitacions)
                    .HasForeignKey(d => d.IdHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservacion_habitacion_habitaciones");

                entity.HasOne(d => d.IdReservacionNavigation)
                    .WithMany(p => p.ReservacionHabitacions)
                    .HasForeignKey(d => d.IdReservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservacion_habitacion_reservaciones");
            });

            modelBuilder.Entity<Reservacione>(entity =>
            {
                entity.Property(e => e.Detalles).IsUnicode(false);

                entity.HasOne(d => d.MetodoPagoNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.MetodoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservaciones_metodoPago");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservaciones_usuarios");
            });

            modelBuilder.Entity<Reseña>(entity =>
            {
                entity.Property(e => e.Reseña1).IsUnicode(false);

                entity.HasOne(d => d.TipoHabitacionNavigation)
                    .WithMany(p => p.Reseñas)
                    .HasForeignKey(d => d.TipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reseñas_tipoHabitacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reseñas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reseñas_usuarios");
            });

            modelBuilder.Entity<TipoHabitacion>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.RutaImg).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
