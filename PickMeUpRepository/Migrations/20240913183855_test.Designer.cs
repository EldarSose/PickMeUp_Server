﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PickMeUp.Repository;

#nullable disable

namespace PickMeUp.Repository.Migrations
{
    [DbContext(typeof(PickMeUpDbContext))]
    [Migration("20240913183855_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PickMeUp.Core.Entities.Car", b =>
                {
                    b.Property<int>("carId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("carId"));

                    b.Property<string>("carModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("plateNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("taxiID")
                        .HasColumnType("int");

                    b.Property<string>("taxiNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("carId");

                    b.HasIndex("taxiID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Contact", b =>
                {
                    b.Property<int>("contactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("contactId"));

                    b.Property<string>("contactInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("contactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.DriverRatings", b =>
                {
                    b.Property<int>("driverRatingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("driverRatingsId"));

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("driverId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<float?>("rating")
                        .HasColumnType("real");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("driverRatingsId");

                    b.HasIndex("driverId");

                    b.HasIndex("userId");

                    b.ToTable("DriverRatings");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Gender", b =>
                {
                    b.Property<int>("genderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("genderId"));

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("genderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderId"));

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("orderStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("taxiDriverId")
                        .HasColumnType("int");

                    b.Property<int?>("taxiId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("timeUntilArrival")
                        .HasColumnType("datetime2");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("orderStatusId");

                    b.HasIndex("taxiDriverId");

                    b.HasIndex("taxiId");

                    b.HasIndex("userId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.OrderStatus", b =>
                {
                    b.Property<int>("ordedStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ordedStatusId"));

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("orderStatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("orderStatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ordedStatusId");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Report", b =>
                {
                    b.Property<int>("reportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reportId"));

                    b.Property<int?>("adminId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("answeredAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("madeAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("reportAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reportDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("reportTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("reportId");

                    b.HasIndex("adminId");

                    b.HasIndex("reportTypeId");

                    b.HasIndex("userId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.ReportType", b =>
                {
                    b.Property<int>("reportTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reportTypeId"));

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("reportName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("reportTypeId");

                    b.ToTable("ReportTypes");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Reviews", b =>
                {
                    b.Property<int>("reviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reviewId"));

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<float?>("rating")
                        .HasColumnType("real");

                    b.Property<int?>("taxiId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("reviewId");

                    b.HasIndex("taxiId");

                    b.HasIndex("userId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.RoleUser", b =>
                {
                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.Property<int?>("roleId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("userId", "roleId");

                    b.HasIndex("roleId");

                    b.ToTable("RoleUsers");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Roles", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleId"));

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("roleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Shift", b =>
                {
                    b.Property<int>("shiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("shiftId"));

                    b.Property<DateTime?>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("taxiCompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("taxiDriverId")
                        .HasColumnType("int");

                    b.Property<bool?>("tookABreak")
                        .HasColumnType("bit");

                    b.HasKey("shiftId");

                    b.HasIndex("taxiCompanyId");

                    b.HasIndex("taxiDriverId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Taxi", b =>
                {
                    b.Property<int>("taxiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("taxiId"));

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<float?>("pricePerKilometer")
                        .HasColumnType("real");

                    b.Property<float?>("startingPrice")
                        .HasColumnType("real");

                    b.Property<string>("taxiName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("taxiId");

                    b.HasIndex("userId");

                    b.ToTable("Taxis");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.TaxiContact", b =>
                {
                    b.Property<int?>("contactId")
                        .HasColumnType("int");

                    b.Property<int?>("taxiId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("contactId", "taxiId");

                    b.HasIndex("taxiId");

                    b.ToTable("TaxiContacts");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.TaxiDriverCar", b =>
                {
                    b.Property<int?>("carId")
                        .HasColumnType("int");

                    b.Property<int?>("taxiDriverId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("carId", "taxiDriverId");

                    b.HasIndex("taxiDriverId");

                    b.ToTable("taxiDriverCars");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<DateTime?>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("genderID")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("taxiCompanyID")
                        .HasColumnType("int");

                    b.Property<int?>("userAccountID")
                        .HasColumnType("int");

                    b.HasKey("userId");

                    b.HasIndex("genderID");

                    b.HasIndex("taxiCompanyID");

                    b.HasIndex("userAccountID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.UserAccount", b =>
                {
                    b.Property<int>("userAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userAccountId"));

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("userAccountId");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Car", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.Taxi", "taxi")
                        .WithMany()
                        .HasForeignKey("taxiID");

                    b.Navigation("taxi");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.DriverRatings", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.User", "driver")
                        .WithMany()
                        .HasForeignKey("driverId");

                    b.HasOne("PickMeUp.Core.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("driver");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Order", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.OrderStatus", "orderStatus")
                        .WithMany()
                        .HasForeignKey("orderStatusId");

                    b.HasOne("PickMeUp.Core.Entities.User", "taxiDriver")
                        .WithMany()
                        .HasForeignKey("taxiDriverId");

                    b.HasOne("PickMeUp.Core.Entities.Taxi", "taxi")
                        .WithMany()
                        .HasForeignKey("taxiId");

                    b.HasOne("PickMeUp.Core.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("orderStatus");

                    b.Navigation("taxi");

                    b.Navigation("taxiDriver");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Report", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.User", "admin")
                        .WithMany()
                        .HasForeignKey("adminId");

                    b.HasOne("PickMeUp.Core.Entities.ReportType", "reportType")
                        .WithMany()
                        .HasForeignKey("reportTypeId");

                    b.HasOne("PickMeUp.Core.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("admin");

                    b.Navigation("reportType");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Reviews", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.Taxi", "taxi")
                        .WithMany()
                        .HasForeignKey("taxiId");

                    b.HasOne("PickMeUp.Core.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("taxi");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.RoleUser", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.Roles", "role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PickMeUp.Core.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Shift", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.Taxi", "taxiCompany")
                        .WithMany()
                        .HasForeignKey("taxiCompanyId");

                    b.HasOne("PickMeUp.Core.Entities.User", "taxiDriver")
                        .WithMany()
                        .HasForeignKey("taxiDriverId");

                    b.Navigation("taxiCompany");

                    b.Navigation("taxiDriver");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.Taxi", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.TaxiContact", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.Contact", "contact")
                        .WithMany()
                        .HasForeignKey("contactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PickMeUp.Core.Entities.Taxi", "taxi")
                        .WithMany()
                        .HasForeignKey("taxiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("contact");

                    b.Navigation("taxi");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.TaxiDriverCar", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.Car", "car")
                        .WithMany()
                        .HasForeignKey("carId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PickMeUp.Core.Entities.User", "taxiDriver")
                        .WithMany()
                        .HasForeignKey("taxiDriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");

                    b.Navigation("taxiDriver");
                });

            modelBuilder.Entity("PickMeUp.Core.Entities.User", b =>
                {
                    b.HasOne("PickMeUp.Core.Entities.Gender", "gender")
                        .WithMany()
                        .HasForeignKey("genderID");

                    b.HasOne("PickMeUp.Core.Entities.Taxi", "taxiCompany")
                        .WithMany()
                        .HasForeignKey("taxiCompanyID");

                    b.HasOne("PickMeUp.Core.Entities.UserAccount", "userAccount")
                        .WithMany()
                        .HasForeignKey("userAccountID");

                    b.Navigation("gender");

                    b.Navigation("taxiCompany");

                    b.Navigation("userAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
