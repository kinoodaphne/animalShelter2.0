﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shelter.MVC.Context;

namespace Shelter.MVC.Migrations
{
    [DbContext(typeof(ShelterContext))]
    partial class ShelterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Shelter.Shared.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("KidFriendly")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Race")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShelterId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Since")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId");

                    b.ToTable("Animals");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Animal");
                });

            modelBuilder.Entity("Shelter.Shared.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EmployeedSince")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Shelter.Shared.Shelter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Shelters");
                });

            modelBuilder.Entity("Shelter.Shared.Cat", b =>
                {
                    b.HasBaseType("Shelter.Shared.Animal");

                    b.Property<bool>("Declawed")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Cat");
                });

            modelBuilder.Entity("Shelter.Shared.Dog", b =>
                {
                    b.HasBaseType("Shelter.Shared.Animal");

                    b.Property<bool>("Barker")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Dog");
                });

            modelBuilder.Entity("Shelter.Shared.Other", b =>
                {
                    b.HasBaseType("Shelter.Shared.Animal");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Other");
                });

            modelBuilder.Entity("Shelter.Shared.Animal", b =>
                {
                    b.HasOne("Shelter.Shared.Shelter", null)
                        .WithMany("Animals")
                        .HasForeignKey("ShelterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
