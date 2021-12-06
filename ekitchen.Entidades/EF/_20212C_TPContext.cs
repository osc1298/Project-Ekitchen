﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ekitchen.Entidades.EF
{
    public partial class _20212C_TPContext : DbContext
    {
        public _20212C_TPContext()
        {
        }

        public _20212C_TPContext(DbContextOptions<_20212C_TPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacione> Calificaciones { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<EventosReceta> EventosRecetas { get; set; }
        public virtual DbSet<Receta> Recetas { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<TipoReceta> TipoRecetas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

 
            //    optionsBuilder.UseSqlServer("Server=LENOVO\\SQLEXPRESS;Database=20212C_TP;Trusted_Connection=True;");

               


               optionsBuilder.UseSqlServer("");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion);

                entity.Property(e => e.Comentarios).IsRequired();

                entity.HasOne(d => d.IdComensalNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdComensal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_Usuarios");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_Eventos");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCocineroNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdCocinero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eventos_Usuarios");
            });

            modelBuilder.Entity<EventosReceta>(entity =>
            {
                entity.HasKey(e => e.IdEventoReceta);

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.EventosReceta)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventosRecetas_Eventos");

                entity.HasOne(d => d.IdRecetaNavigation)
                    .WithMany(p => p.EventosReceta)
                    .HasForeignKey(d => d.IdReceta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventosRecetas_Recetas");
            });

            modelBuilder.Entity<Receta>(entity =>
            {
                entity.HasKey(e => e.IdReceta);

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Ingredientes).IsRequired();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdTipoRecetaNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.IdTipoReceta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recetas_TipoRecetas");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdComensalNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdComensal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservas_Usuarios");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservas_Eventos");

                entity.HasOne(d => d.IdRecetaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdReceta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservas_Recetas");
            });

            modelBuilder.Entity<TipoReceta>(entity =>
            {
                entity.HasKey(e => e.IdTipoReceta);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaRegistracion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
