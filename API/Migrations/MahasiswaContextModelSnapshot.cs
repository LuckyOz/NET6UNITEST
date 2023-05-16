﻿// <auto-generated />
using System;
using API.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MahasiswaContext))]
    partial class MahasiswaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Db.mahasiswa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("alamat")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("alamat");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("nama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nama");

                    b.Property<int>("umur")
                        .HasColumnType("integer")
                        .HasColumnName("umur");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("id");

                    b.ToTable("mahasiswa");
                });
#pragma warning restore 612, 618
        }
    }
}
