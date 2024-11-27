﻿// <auto-generated />
using BookstoreA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookstoreA.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    [Migration("20241104181306_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BookGenre", b =>
            {
                b.Property<int>("BooksId")
                    .HasColumnType("int");

                b.Property<int>("GenresId")
                    .HasColumnType("int");

                b.HasKey("BooksId", "GenresId");

                b.HasIndex("GenresId");

                b.ToTable("BookGenre");
            });

            modelBuilder.Entity("Bookstore.Models.Book", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Author")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<double>("Price")
                    .HasColumnType("double");

                b.Property<int>("ReleaseYear")
                    .HasColumnType("int");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.HasKey("Id");

                b.ToTable("Books");
            });

            modelBuilder.Entity("Bookstore.Models.Genre", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.HasKey("Id");

                b.ToTable("Genres");
            });

            modelBuilder.Entity("BookGenre", b =>
            {
                b.HasOne("Bookstore.Models.Book", null)
                    .WithMany()
                    .HasForeignKey("BooksId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Bookstore.Models.Genre", null)
                    .WithMany()
                    .HasForeignKey("GenresId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
