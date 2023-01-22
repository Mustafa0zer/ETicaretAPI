﻿// <auto-generated />
using System;
using ETicaretAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    [DbContext(typeof(ETicaretAPIDbContext))]
    partial class ETicaretAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<TimeSpan>("OrderEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("OrderStart")
                        .HasColumnType("time");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Order", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(36)");

                    b.Property<Guid>("CompanyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Product", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<string>("OrdersID")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ProductsID")
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("OrdersID", "ProductsID");

                    b.HasIndex("ProductsID");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Order", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.Company", "MyCompany")
                        .WithMany("Orders")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MyCompany");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETicaretAPI.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.Company", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
