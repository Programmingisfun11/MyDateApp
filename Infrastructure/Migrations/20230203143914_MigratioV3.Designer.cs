﻿// <auto-generated />
using System;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230203143914_MigratioV3")]
    partial class MigratioV3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api.Entities.TransactionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Expires")
                        .HasColumnType("bit");

                    b.Property<bool>("Failed")
                        .HasColumnType("bit");

                    b.Property<bool>("PendingConfirm")
                        .HasColumnType("bit");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<int>("TransactionRef")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionRef")
                        .IsUnique();

                    b.ToTable("TransactionStatus");
                });

            modelBuilder.Entity("Api.Entities.UserLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ToUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ByUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("UserLikes");
                });

            modelBuilder.Entity("Api.Entities.UserMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ByUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("UserMessages");
                });

            modelBuilder.Entity("Api.Entities.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Api.Entities.UserVipPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DaysCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserVipPayments");
                });

            modelBuilder.Entity("DateApp.Entities.TransactionConfirmed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionConfirmed");
                });

            modelBuilder.Entity("Api.Entities.TransactionStatus", b =>
                {
                    b.HasOne("DateApp.Entities.TransactionConfirmed", "transactionConfirmed")
                        .WithOne("status")
                        .HasForeignKey("Api.Entities.TransactionStatus", "TransactionRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("transactionConfirmed");
                });

            modelBuilder.Entity("Api.Entities.UserLike", b =>
                {
                    b.HasOne("Api.Entities.UserProfile", "ByUser")
                        .WithMany("SendedLikes")
                        .HasForeignKey("ByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Entities.UserProfile", "ToUser")
                        .WithMany("ReceivedLikes")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ByUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("Api.Entities.UserMessage", b =>
                {
                    b.HasOne("Api.Entities.UserProfile", "ByUser")
                        .WithMany("SendedMessages")
                        .HasForeignKey("ByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Entities.UserProfile", "ToUser")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ByUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("Api.Entities.UserProfile", b =>
                {
                    b.Navigation("ReceivedLikes");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("SendedLikes");

                    b.Navigation("SendedMessages");
                });

            modelBuilder.Entity("DateApp.Entities.TransactionConfirmed", b =>
                {
                    b.Navigation("status");
                });
#pragma warning restore 612, 618
        }
    }
}
