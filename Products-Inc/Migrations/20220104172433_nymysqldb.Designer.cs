﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Products_Inc.Data;

#nullable disable

namespace Products_Inc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220104172433_nymysqldb")]
    partial class nymysqldb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "438db5c8-0513-43a0-a84c-cd416c4e3a54",
                            ConcurrencyStamp = "7283cf31-50c5-44b8-ac9e-a9cdeb01852e",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
                            ConcurrencyStamp = "71f0cd20-6229-4c29-a595-0c4654b5b6f4",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85)
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85)
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "c565ba40-a27a-4818-99f0-5940da6cc2ae",
                            RoleId = "438db5c8-0513-43a0-a84c-cd416c4e3a54"
                        },
                        new
                        {
                            UserId = "c565ba40-a27a-4818-99f0-5940da6cc2ae",
                            RoleId = "0948bea6-fb82-49c9-8cd8-fec213fe8e8a"
                        },
                        new
                        {
                            UserId = "6487e82e-1b04-45a9-ac21-9c0db84b6f80",
                            RoleId = "0948bea6-fb82-49c9-8cd8-fec213fe8e8a"
                        },
                        new
                        {
                            UserId = "5e3ec0ae-5d84-4492-af99-2fe7349c0470",
                            RoleId = "0948bea6-fb82-49c9-8cd8-fec213fe8e8a"
                        },
                        new
                        {
                            UserId = "8b4f163f-342b-47dc-8a03-c7f40fe88543",
                            RoleId = "0948bea6-fb82-49c9-8cd8-fec213fe8e8a"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("Name")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("Value")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Products_Inc.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(85)");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            UserId = "8b4f163f-342b-47dc-8a03-c7f40fe88543"
                        },
                        new
                        {
                            OrderId = 2,
                            UserId = "6487e82e-1b04-45a9-ac21-9c0db84b6f80"
                        },
                        new
                        {
                            OrderId = 3,
                            UserId = "5e3ec0ae-5d84-4492-af99-2fe7349c0470"
                        },
                        new
                        {
                            OrderId = 4,
                            UserId = "5e3ec0ae-5d84-4492-af99-2fe7349c0470"
                        });
                });

            modelBuilder.Entity("Products_Inc.Models.OrderProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            ProductId = 50,
                            OrderId = 1,
                            Amount = 4,
                            OrderProductId = 1
                        },
                        new
                        {
                            ProductId = 52,
                            OrderId = 1,
                            Amount = 2,
                            OrderProductId = 2
                        },
                        new
                        {
                            ProductId = 57,
                            OrderId = 1,
                            Amount = 1,
                            OrderProductId = 3
                        },
                        new
                        {
                            ProductId = 52,
                            OrderId = 2,
                            Amount = 6,
                            OrderProductId = 4
                        },
                        new
                        {
                            ProductId = 54,
                            OrderId = 2,
                            Amount = 1,
                            OrderProductId = 5
                        },
                        new
                        {
                            ProductId = 56,
                            OrderId = 2,
                            Amount = 2,
                            OrderProductId = 6
                        },
                        new
                        {
                            ProductId = 55,
                            OrderId = 3,
                            Amount = 9,
                            OrderProductId = 7
                        },
                        new
                        {
                            ProductId = 57,
                            OrderId = 3,
                            Amount = 1,
                            OrderProductId = 8
                        },
                        new
                        {
                            ProductId = 51,
                            OrderId = 3,
                            Amount = 3,
                            OrderProductId = 9
                        },
                        new
                        {
                            ProductId = 52,
                            OrderId = 4,
                            Amount = 5,
                            OrderProductId = 10
                        },
                        new
                        {
                            ProductId = 53,
                            OrderId = 4,
                            Amount = 3,
                            OrderProductId = 11
                        },
                        new
                        {
                            ProductId = 55,
                            OrderId = 4,
                            Amount = 1,
                            OrderProductId = 12
                        });
                });

            modelBuilder.Entity("Products_Inc.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImgPath")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 50,
                            ImgPath = "./img/img4.jpg",
                            ProductDescription = "Nice for your health",
                            ProductName = "Orange",
                            ProductPrice = 30
                        },
                        new
                        {
                            ProductId = 51,
                            ImgPath = "./img/img6.jpg",
                            ProductDescription = "Good to drink",
                            ProductName = "Coca Cola",
                            ProductPrice = 16
                        },
                        new
                        {
                            ProductId = 52,
                            ImgPath = "./img/img7.jpg",
                            ProductDescription = "Good for health",
                            ProductName = "Oreo",
                            ProductPrice = 10
                        },
                        new
                        {
                            ProductId = 53,
                            ImgPath = "./img/img8.jpg",
                            ProductDescription = "Healthy breakfast",
                            ProductName = "Corn Flakes",
                            ProductPrice = 25
                        },
                        new
                        {
                            ProductId = 54,
                            ImgPath = "./img/img9.jpg",
                            ProductDescription = "Nice to make food",
                            ProductName = "Salt",
                            ProductPrice = 9
                        },
                        new
                        {
                            ProductId = 55,
                            ImgPath = "./img/img12.jpg",
                            ProductDescription = "Good for health",
                            ProductName = "Avocado",
                            ProductPrice = 18
                        },
                        new
                        {
                            ProductId = 56,
                            ImgPath = "./img/img14.jpg",
                            ProductDescription = "Nice to eat",
                            ProductName = "Eggo",
                            ProductPrice = 30
                        },
                        new
                        {
                            ProductId = 57,
                            ImgPath = "./img/img16.png",
                            ProductDescription = "Creamy sun butter",
                            ProductName = "SunButter",
                            ProductPrice = 35
                        });
                });

            modelBuilder.Entity("Products_Inc.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TransactionComplete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(85)");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Products_Inc.Models.ShoppingCartProduct", b =>
                {
                    b.Property<int>("ShoppingCartProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartProducts");
                });

            modelBuilder.Entity("Products_Inc.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c565ba40-a27a-4818-99f0-5940da6cc2ae",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "40b62c28-49e8-455b-bde6-c5f0962b727f",
                            Email = "customer1@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CUSTOMER1@EMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEBS4beZJZRR8R/Ph4NCMf3p4I29SSITXSNaO4QuY5uHxIU0MO32M8tIv3wIavkfo9A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8e18a28b-850c-4def-8b6a-161354c8d3d7",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "6487e82e-1b04-45a9-ac21-9c0db84b6f80",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f822b075-90dd-484a-9dd4-aff1b7350c38",
                            Email = "customer1@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CUSTOMER1@EMAIL.COM",
                            NormalizedUserName = "CUSTOMER1",
                            PasswordHash = "AQAAAAEAACcQAAAAEJuYVe89crJDARayxVjnNEd1EWuOIH+HdOguxyzP/f6owxTehZ8IMAfE6sv1wJx2fQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dd999702-e6ab-4fa2-b40f-95da36212b53",
                            TwoFactorEnabled = false,
                            UserName = "customer1"
                        },
                        new
                        {
                            Id = "5e3ec0ae-5d84-4492-af99-2fe7349c0470",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "900884b2-905d-4b0d-b4b1-4fc97aad9caf",
                            Email = "customer2@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CUSTOMER2@EMAIL.COM",
                            NormalizedUserName = "CUSTOMER2",
                            PasswordHash = "AQAAAAEAACcQAAAAEF5DolojEjjOqfEgBPoppG1L2mABdfTDOS2fc7nIJYxJNzs7szAN8sFCXzSfAYEllA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "41c1ea88-b5a0-4fec-9816-8afe7ec42b43",
                            TwoFactorEnabled = false,
                            UserName = "customer2"
                        },
                        new
                        {
                            Id = "8b4f163f-342b-47dc-8a03-c7f40fe88543",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8d886e46-5a17-4134-b866-07d956a61acc",
                            Email = "customer3@email.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CUSTOMER3@EMAIL.COM",
                            NormalizedUserName = "CUSTOMER3",
                            PasswordHash = "AQAAAAEAACcQAAAAEPkmOax8uVUReFvDNvPhMoXJuFF6FW20HnjbmHnxuwD9x0pj8/76Yt28Cy5pFo6IPA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "51e14a6a-2e86-4707-8b23-aa185f905245",
                            TwoFactorEnabled = false,
                            UserName = "customer3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Products_Inc.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Products_Inc.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Products_Inc.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Products_Inc.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Products_Inc.Models.Order", b =>
                {
                    b.HasOne("Products_Inc.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Products_Inc.Models.OrderProduct", b =>
                {
                    b.HasOne("Products_Inc.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Products_Inc.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Products_Inc.Models.ShoppingCart", b =>
                {
                    b.HasOne("Products_Inc.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Products_Inc.Models.ShoppingCartProduct", b =>
                {
                    b.HasOne("Products_Inc.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Products_Inc.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("Products")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Products_Inc.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Products_Inc.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Products_Inc.Models.ShoppingCart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Products_Inc.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}