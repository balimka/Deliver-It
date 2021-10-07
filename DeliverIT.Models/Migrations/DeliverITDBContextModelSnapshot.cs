﻿// <auto-generated />
using System;
using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeliverIT.Models.Migrations
{
    [DbContext(typeof(DeliverITDBContext))]
    partial class DeliverITDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CityId" }, "IX_Addresses_CityId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            IsDeleted = false,
                            StreetName = "Vasil Levski 14"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            IsDeleted = false,
                            StreetName = "blv. Iztochen 23"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            IsDeleted = false,
                            StreetName = "blv. Halic 12"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 4,
                            IsDeleted = false,
                            StreetName = "blv. Zeus 12"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 5,
                            IsDeleted = false,
                            StreetName = "blv. Romunska Morava 1"
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("AppUser");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.AppUserRole", b =>
                {
                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.HasKey("AppRoleId", "AppUserId");

                    b.HasIndex("AppUserId");

                    b.ToTable("AppUserRoles");

                    b.HasData(
                        new
                        {
                            AppRoleId = 2,
                            AppUserId = 1
                        },
                        new
                        {
                            AppRoleId = 2,
                            AppUserId = 2
                        },
                        new
                        {
                            AppRoleId = 2,
                            AppUserId = 3
                        },
                        new
                        {
                            AppRoleId = 2,
                            AppUserId = 4
                        },
                        new
                        {
                            AppRoleId = 1,
                            AppUserId = 5
                        },
                        new
                        {
                            AppRoleId = 1,
                            AppUserId = 6
                        },
                        new
                        {
                            AppRoleId = 1,
                            AppUserId = 7
                        },
                        new
                        {
                            AppRoleId = 1,
                            AppUserId = 8
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Shoes"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Medical supplies"
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name", "CountryId")
                        .IsUnique();

                    b.HasIndex(new[] { "CountryId" }, "IX_Cities_CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            IsDeleted = false,
                            Name = "Sofia"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            IsDeleted = false,
                            Name = "Plovdiv"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            IsDeleted = false,
                            Name = "Istanbul"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 3,
                            IsDeleted = false,
                            Name = "Athenes"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 4,
                            IsDeleted = false,
                            Name = "Yash"
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Turkey"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Greece"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Romania"
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeliverToAddress")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("WareHouseId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CategoryId" }, "IX_Parcels_CategoryId");

                    b.HasIndex(new[] { "CustomerId" }, "IX_Parcels_CustomerId");

                    b.HasIndex(new[] { "ShipmentId" }, "IX_Parcels_ShipmentId");

                    b.HasIndex(new[] { "WareHouseId" }, "IX_Parcels_WareHouseId");

                    b.ToTable("Parcels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CustomerId = 1,
                            DeliverToAddress = true,
                            IsDeleted = false,
                            ShipmentId = 1,
                            WareHouseId = 1,
                            Weight = 1234.5599999999999
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("date");

                    b.Property<int>("DestinationWareHouseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OriginWareHouseId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DestinationWareHouseId" }, "IX_Shipments_DestinationWareHouseId");

                    b.HasIndex(new[] { "OriginWareHouseId" }, "IX_Shipments_OriginWareHouseId");

                    b.HasIndex(new[] { "StatusId" }, "IX_Shipments_StatusId");

                    b.ToTable("Shipments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalDate = new DateTime(2021, 10, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartureDate = new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            DestinationWareHouseId = 2,
                            IsDeleted = false,
                            OriginWareHouseId = 1,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArrivalDate = new DateTime(2021, 10, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartureDate = new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            DestinationWareHouseId = 2,
                            IsDeleted = false,
                            OriginWareHouseId = 1,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Preparing"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "On the way"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.WareHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AddressId" }, "IX_WareHouses_AddressId")
                        .IsUnique();

                    b.ToTable("WareHouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Customer", b =>
                {
                    b.HasBaseType("DeliverIT.Models.DatabaseModels.AppUser");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.HasIndex(new[] { "AddressId" }, "IX_Customers_AddressId");

                    b.HasDiscriminator().HasValue("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "mishkov@misho.com",
                            FirstName = "Misho",
                            IsDeleted = false,
                            LastName = "Mishkov",
                            AddressId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "petio@mvc.net",
                            FirstName = "Peter",
                            IsDeleted = false,
                            LastName = "Petrov",
                            AddressId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "koksal@asd.tr",
                            FirstName = "Koksal",
                            IsDeleted = false,
                            LastName = "Baba",
                            AddressId = 3
                        },
                        new
                        {
                            Id = 4,
                            Email = "indebt@greece.gov",
                            FirstName = "Nikolaos",
                            IsDeleted = false,
                            LastName = "Tsitsibaris",
                            AddressId = 4
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Employee", b =>
                {
                    b.HasBaseType("DeliverIT.Models.DatabaseModels.AppUser");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("Employee_AddressId");

                    b.HasIndex(new[] { "AddressId" }, "IX_Employees_AddressId");

                    b.HasDiscriminator().HasValue("Employee");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Email = "djoro@ekont.com",
                            FirstName = "Djoro",
                            IsDeleted = false,
                            LastName = "Emploev",
                            AddressId = 1
                        },
                        new
                        {
                            Id = 6,
                            Email = "gonzales@speedy.net",
                            FirstName = "Speedy",
                            IsDeleted = false,
                            LastName = "Gonzales"
                        },
                        new
                        {
                            Id = 7,
                            Email = "dormut@dhl.tr",
                            FirstName = "Dormut",
                            IsDeleted = false,
                            LastName = "Baba"
                        },
                        new
                        {
                            Id = 8,
                            Email = "ontime@fedex.us",
                            FirstName = "Stafanakis",
                            IsDeleted = false,
                            LastName = "Kurierakis"
                        });
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Address", b =>
                {
                    b.HasOne("DeliverIT.Models.DatabaseModels.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.AppUserRole", b =>
                {
                    b.HasOne("DeliverIT.Models.DatabaseModels.AppRole", "AppRole")
                        .WithMany()
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliverIT.Models.DatabaseModels.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.City", b =>
                {
                    b.HasOne("DeliverIT.Models.DatabaseModels.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Parcel", b =>
                {
                    b.HasOne("DeliverIT.Models.DatabaseModels.Category", "Category")
                        .WithMany("Parcels")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliverIT.Models.DatabaseModels.Customer", "Customer")
                        .WithMany("Parcels")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliverIT.Models.DatabaseModels.Shipment", "Shipment")
                        .WithMany("Parcels")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliverIT.Models.DatabaseModels.WareHouse", "WareHouse")
                        .WithMany("Parcels")
                        .HasForeignKey("WareHouseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Category");

                    b.Navigation("Customer");

                    b.Navigation("Shipment");

                    b.Navigation("WareHouse");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Shipment", b =>
                {
                    b.HasOne("DeliverIT.Models.DatabaseModels.WareHouse", "DestinationWareHouse")
                        .WithMany("ShipmentDestinationWareHouses")
                        .HasForeignKey("DestinationWareHouseId")
                        .IsRequired();

                    b.HasOne("DeliverIT.Models.DatabaseModels.WareHouse", "OriginWareHouse")
                        .WithMany("ShipmentOriginWareHouses")
                        .HasForeignKey("OriginWareHouseId")
                        .IsRequired();

                    b.HasOne("DeliverIT.Models.DatabaseModels.Status", "Status")
                        .WithMany("Shipments")
                        .HasForeignKey("StatusId")
                        .IsRequired();

                    b.Navigation("DestinationWareHouse");

                    b.Navigation("OriginWareHouse");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.WareHouse", b =>
                {
                    b.HasOne("DeliverIT.Models.DatabaseModels.Address", "Address")
                        .WithMany("WareHouses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Customer", b =>
                {
                    b.HasOne("DeliverIT.Models.DatabaseModels.Address", "Address")
                        .WithMany("Customers")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Employee", b =>
                {
                    b.HasOne("DeliverIT.Models.DatabaseModels.Address", "Address")
                        .WithMany("Employees")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Address", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Employees");

                    b.Navigation("WareHouses");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Category", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Shipment", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Status", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.WareHouse", b =>
                {
                    b.Navigation("Parcels");

                    b.Navigation("ShipmentDestinationWareHouses");

                    b.Navigation("ShipmentOriginWareHouses");
                });

            modelBuilder.Entity("DeliverIT.Models.DatabaseModels.Customer", b =>
                {
                    b.Navigation("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
