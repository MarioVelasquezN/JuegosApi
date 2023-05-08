﻿// <auto-generated />
using System;
using Juegos.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Juegos.Api.Migrations
{
    [DbContext(typeof(JuegosContext))]
    [Migration("20230508043736_InicialMigration")]
    partial class InicialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ClienteVideojuego", b =>
                {
                    b.Property<int>("ClientesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("videojuegosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClientesId", "videojuegosId");

                    b.HasIndex("videojuegosId");

                    b.ToTable("ClienteVideojuego");
                });

            modelBuilder.Entity("Juegos.Api.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Codigo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombrecategoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Juegos.Api.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Renta")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Juegos.Api.Models.Videojuego", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CopiasDisponibles")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModoJuego")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombrejuego")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("VideoJuegos");
                });

            modelBuilder.Entity("ClienteVideojuego", b =>
                {
                    b.HasOne("Juegos.Api.Models.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juegos.Api.Models.Videojuego", null)
                        .WithMany()
                        .HasForeignKey("videojuegosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Juegos.Api.Models.Cliente", b =>
                {
                    b.HasOne("Juegos.Api.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Juegos.Api.Models.Videojuego", b =>
                {
                    b.HasOne("Juegos.Api.Models.Categoria", "Categoria")
                        .WithMany("Juegos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Juegos.Api.Models.Categoria", b =>
                {
                    b.Navigation("Juegos");
                });
#pragma warning restore 612, 618
        }
    }
}
