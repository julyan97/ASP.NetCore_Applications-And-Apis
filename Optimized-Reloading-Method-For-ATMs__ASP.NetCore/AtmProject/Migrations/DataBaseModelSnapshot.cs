﻿// <auto-generated />
using System;
using AtmProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AtmProject.Migrations
{
    [DbContext(typeof(DataBase))]
    partial class DataBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtmProject.Models.Atm", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Atms");
                });

            modelBuilder.Entity("AtmProject.Models.HistoricData", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AtmId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Deposit")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeriodID")
                        .HasColumnType("int");

                    b.Property<int>("PreviousDeposit")
                        .HasColumnType("int");

                    b.Property<DateTime>("PreviousLoad")
                        .HasColumnType("datetime2");

                    b.Property<int>("PreviousPeriodID")
                        .HasColumnType("int");

                    b.Property<int>("PreviousTransactionCount")
                        .HasColumnType("int");

                    b.Property<int>("PreviousWithdraw")
                        .HasColumnType("int");

                    b.Property<string>("TID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionCount")
                        .HasColumnType("int");

                    b.Property<int>("Withdraw")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AtmId");

                    b.ToTable("HistoricData");
                });

            modelBuilder.Entity("AtmProject.Models.Prices", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("AlternativePrice")
                        .HasColumnType("float");

                    b.Property<string>("AtmId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("LoadingAndCounting")
                        .HasColumnType("float");

                    b.Property<double>("Risk")
                        .HasColumnType("float");

                    b.Property<double>("Transport")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("AtmId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("AtmProject.Models.HistoricData", b =>
                {
                    b.HasOne("AtmProject.Models.Atm", "Atm")
                        .WithMany("HD")
                        .HasForeignKey("AtmId");
                });

            modelBuilder.Entity("AtmProject.Models.Prices", b =>
                {
                    b.HasOne("AtmProject.Models.Atm", "Atm")
                        .WithMany("Prices")
                        .HasForeignKey("AtmId");
                });
#pragma warning restore 612, 618
        }
    }
}
