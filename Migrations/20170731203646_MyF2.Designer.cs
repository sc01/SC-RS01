using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Sign.Models.Business;

namespace SCRS01.Migrations
{
    [DbContext(typeof(RealStateDatabase))]
    [Migration("20170731203646_MyF2")]
    partial class MyF2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Sign.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Sign.Models.Business.Apartment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApartmentPlace");

                    b.Property<string>("ApartmentType");

                    b.Property<string>("AqarState");

                    b.Property<string>("Area");

                    b.Property<int>("BathRoomCount");

                    b.Property<int>("BuildingId");

                    b.Property<long?>("CustomerId");

                    b.Property<string>("ElectricBill");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("date");

                    b.Property<string>("FloorNumber");

                    b.Property<string>("GateState");

                    b.Property<int>("HallCount");

                    b.Property<int>("HeaterCount");

                    b.Property<string>("KitchinIsFound");

                    b.Property<string>("Name");

                    b.Property<int>("RoomCount");

                    b.Property<string>("ShowType");

                    b.Property<int>("SplitCount");

                    b.Property<int>("WallTypeCount");

                    b.Property<string>("WaterBill");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("Sign.Models.Business.AttachmentForApartment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ApartmentId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("AttachmentForApartments");
                });

            modelBuilder.Entity("Sign.Models.Business.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<long>("CustomerId");

                    b.Property<string>("Gada");

                    b.Property<string>("Name");

                    b.Property<string>("Services");

                    b.Property<string>("StreetName");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Sign.Models.Business.Contract", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ApartmentDetilsId");

                    b.Property<DateTime>("ContractDate")
                        .HasColumnType("date");

                    b.Property<string>("ContractPlace");

                    b.Property<string>("ContractType");

                    b.Property<long>("CustomerId");

                    b.Property<decimal>("ElectricBillValue");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<decimal>("InsuranceValue");

                    b.Property<decimal>("OfficeFees");

                    b.Property<string>("PeriodType");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<decimal>("TotoalContratValue");

                    b.Property<decimal>("WaterBillValue");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentDetilsId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Sign.Models.Business.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CustomerId");

                    b.Property<string>("CustomerType");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("WorkPalce");

                    b.Property<string>("WorkPhone");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sign.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sign.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sign.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sign.Models.Business.Apartment", b =>
                {
                    b.HasOne("Sign.Models.Business.Building", "Building")
                        .WithMany("Apartments")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sign.Models.Business.Customer")
                        .WithMany("Apartments")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Sign.Models.Business.AttachmentForApartment", b =>
                {
                    b.HasOne("Sign.Models.Business.Apartment", "Apartment")
                        .WithMany("AttachmentForApartments")
                        .HasForeignKey("ApartmentId");
                });

            modelBuilder.Entity("Sign.Models.Business.Building", b =>
                {
                    b.HasOne("Sign.Models.Business.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sign.Models.Business.Contract", b =>
                {
                    b.HasOne("Sign.Models.Business.Apartment", "ApartmentDetils")
                        .WithMany("Contracts")
                        .HasForeignKey("ApartmentDetilsId");

                    b.HasOne("Sign.Models.Business.Customer", "CustomerName")
                        .WithMany("Contracts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
