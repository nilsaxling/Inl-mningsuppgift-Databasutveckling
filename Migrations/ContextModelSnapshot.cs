﻿// <auto-generated />
using System;
using Inlämningsuppgift_Databasutveckling.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inlämningsuppgift_Databasutveckling.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inlämningsuppgift_Databasutveckling.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfLoan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfReturn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRented")
                        .HasColumnType("bit");

                    b.Property<int>("Isbn")
                        .HasColumnType("int");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LibraryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Inlämningsuppgift_Databasutveckling.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("CardPin")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("LibraryId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Inlämningsuppgift_Databasutveckling.Models.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("Inlämningsuppgift_Databasutveckling.Models.Book", b =>
                {
                    b.HasOne("Inlämningsuppgift_Databasutveckling.Models.Customer", null)
                        .WithMany("BooksBorrowed")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Inlämningsuppgift_Databasutveckling.Models.Library", null)
                        .WithMany("Books")
                        .HasForeignKey("LibraryId");
                });

            modelBuilder.Entity("Inlämningsuppgift_Databasutveckling.Models.Customer", b =>
                {
                    b.HasOne("Inlämningsuppgift_Databasutveckling.Models.Library", null)
                        .WithMany("Customers")
                        .HasForeignKey("LibraryId");
                });

            modelBuilder.Entity("Inlämningsuppgift_Databasutveckling.Models.Customer", b =>
                {
                    b.Navigation("BooksBorrowed");
                });

            modelBuilder.Entity("Inlämningsuppgift_Databasutveckling.Models.Library", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
