﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Novin.FoodApp.Infrastructure.Data;

#nullable disable

namespace Novin.FoodApp.Infrastructure.Migrations
{
    [DbContext(typeof(NovinFoodAppDB))]
    [Migration("20230719213357_AddRestaurant")]
    partial class AddRestaurant
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Novin.FoodApp.Core.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Username");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Novin.FoodApp.Core.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ApprovedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApproverUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApproverUsername");

                    b.HasIndex("OwnerUsername");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Novin.FoodApp.Core.Entities.Restaurant", b =>
                {
                    b.HasOne("Novin.FoodApp.Core.Entities.ApplicationUser", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverUsername");

                    b.HasOne("Novin.FoodApp.Core.Entities.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("Owner");
                });
#pragma warning restore 612, 618
        }
    }
}
