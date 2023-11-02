﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TaskApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231102075739_ModifySomePropVer2")]
    partial class ModifySomePropVer2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Brunch", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrunchLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrunchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsItMainBrunch")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Brunches");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyActivity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConstructionYear")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.DistributionLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainBrunchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryBrunchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DistributionLogs");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.ProductionLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("BrunchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfCreate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrunchId");

                    b.ToTable("ProductionLogs");
                });

            modelBuilder.Entity("Domain.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrunchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DistributionLogId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NewAmountInThisBrunch")
                        .HasColumnType("int");

                    b.Property<int>("TransAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrunchId");

                    b.HasIndex("DistributionLogId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Domain.Brunch", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("Brunches")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.ProductionLog", b =>
                {
                    b.HasOne("Domain.Brunch", "Brunch")
                        .WithMany()
                        .HasForeignKey("BrunchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brunch");
                });

            modelBuilder.Entity("Domain.Transaction", b =>
                {
                    b.HasOne("Domain.Brunch", "Brunch")
                        .WithMany()
                        .HasForeignKey("BrunchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.DistributionLog", "DistributionLog")
                        .WithMany()
                        .HasForeignKey("DistributionLogId");

                    b.Navigation("Brunch");

                    b.Navigation("DistributionLog");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Navigation("Brunches");
                });
#pragma warning restore 612, 618
        }
    }
}
