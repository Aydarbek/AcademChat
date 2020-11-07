﻿// <auto-generated />
using System;
using AcademChatAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AcademChatAPI.Migrations
{
    [DbContext(typeof(ChatContext))]
    [Migration("20201107201659_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AcademChatAPI.Entities.Message", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("text")
                        .HasColumnType("text");

                    b.Property<DateTime>("time_stamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("to_user_id")
                        .HasColumnType("bigint");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("to_user_id");

                    b.HasIndex("user_id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("AcademChatAPI.Entities.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("position")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("secret")
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("status")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            name = "VitalyV",
                            position = "CEO",
                            secret = "B/9HOf6JVnY+eHf4bLqarA=="
                        },
                        new
                        {
                            id = 2L,
                            name = "ValeryM",
                            position = "CTO",
                            secret = "B/9HOf6JVnY+eHf4bLqarA=="
                        },
                        new
                        {
                            id = 3L,
                            name = "MatveyF",
                            position = "Lead",
                            secret = "B/9HOf6JVnY+eHf4bLqarA=="
                        },
                        new
                        {
                            id = 4L,
                            name = "NatalyaN",
                            position = "CFO",
                            secret = "B/9HOf6JVnY+eHf4bLqarA=="
                        },
                        new
                        {
                            id = 5L,
                            name = "AydarA",
                            position = "SWE",
                            secret = "B/9HOf6JVnY+eHf4bLqarA=="
                        });
                });

            modelBuilder.Entity("AcademChatAPI.Entities.Message", b =>
                {
                    b.HasOne("AcademChatAPI.Entities.User", "To_User")
                        .WithMany()
                        .HasForeignKey("to_user_id");

                    b.HasOne("AcademChatAPI.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}