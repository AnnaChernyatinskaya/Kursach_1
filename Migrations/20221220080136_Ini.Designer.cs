﻿// <auto-generated />
using System;
using Kursach_1.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kursach_1.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221220080136_Ini")]
    partial class Ini
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Kursach_1.Classes.Requests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("TemaId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("date_finish")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("date_start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("TemaId");

                    b.HasIndex("UsersId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Kursach_1.Classes.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name_role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Kursach_1.Classes.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name_status")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Kursach_1.Classes.Tema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name_tema")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tema");
                });

            modelBuilder.Entity("Kursach_1.Classes.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("login")
                        .HasColumnType("text");

                    b.Property<string>("middlename")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("surname")
                        .HasColumnType("text");

                    b.Property<string>("teltphone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Kursach_1.Classes.Requests", b =>
                {
                    b.HasOne("Kursach_1.Classes.Status", "Status")
                        .WithMany("Requests")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kursach_1.Classes.Tema", "Tema")
                        .WithMany("Requests")
                        .HasForeignKey("TemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kursach_1.Classes.Users", "Users")
                        .WithMany("Requests")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kursach_1.Classes.Users", b =>
                {
                    b.HasOne("Kursach_1.Classes.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}