﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyIMDB.Data;

namespace MyIMDB.Data.Migrations
{
    [DbContext(typeof(ImdbContext))]
    [Migration("20190603140550_Fix MoviesCountries")]
    partial class FixMoviesCountries
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyIMDB.Data.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.Gender", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AverageRate");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.MoviePerson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography");

                    b.Property<long?>("CountryId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FullName");

                    b.Property<long?>("GenderId");

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("GenderId");

                    b.ToTable("MoviePerson");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.MoviePersonType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("MoviePersonType");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.MoviePersonsMovies", b =>
                {
                    b.Property<long>("MovieId");

                    b.Property<long>("MoviePersonId");

                    b.Property<long>("MoviePersonTypeId");

                    b.HasKey("MovieId", "MoviePersonId", "MoviePersonTypeId");

                    b.HasIndex("MoviePersonId");

                    b.HasIndex("MoviePersonTypeId");

                    b.ToTable("MoviePersonMovie");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.MoviesCountries", b =>
                {
                    b.Property<long>("MovieId");

                    b.Property<long>("CountryId");

                    b.HasKey("MovieId", "CountryId");

                    b.HasIndex("CountryId");

                    b.ToTable("MovieCountry");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.MoviesGenres", b =>
                {
                    b.Property<long>("MovieId");

                    b.Property<long>("GenreId");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.Rate", b =>
                {
                    b.Property<long>("MovieId");

                    b.Property<long>("ProfileId");

                    b.Property<int>("Value");

                    b.HasKey("MovieId", "ProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography");

                    b.Property<long?>("CountryId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("EMail");

                    b.Property<string>("FullName");

                    b.Property<long?>("GenderId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Login");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("GenderId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.WatchLaterMovies", b =>
                {
                    b.Property<long>("UsereId");

                    b.Property<long>("MovieId");

                    b.HasKey("UsereId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("WatchLaterMovie");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.MoviePerson", b =>
                {
                    b.HasOne("MyIMDB.Data.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("MyIMDB.Data.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.MoviePersonsMovies", b =>
                {
                    b.HasOne("MyIMDB.Data.Entities.Movie", "Movie")
                        .WithMany("MoviePersonsMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyIMDB.Data.Entities.MoviePerson", "Person")
                        .WithMany("MoviePersonsMovies")
                        .HasForeignKey("MoviePersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyIMDB.Data.Entities.MoviePersonType", "MoviePersonType")
                        .WithMany("MoviePersonsMovies")
                        .HasForeignKey("MoviePersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.MoviesCountries", b =>
                {
                    b.HasOne("MyIMDB.Data.Entities.Country", "Country")
                        .WithMany("MoviesCountries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyIMDB.Data.Entities.Movie", "Movie")
                        .WithMany("MoviesCountries")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.MoviesGenres", b =>
                {
                    b.HasOne("MyIMDB.Data.Entities.Genre", "Genre")
                        .WithMany("MoviesGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyIMDB.Data.Entities.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.Rate", b =>
                {
                    b.HasOne("MyIMDB.Data.Entities.Movie", "Movie")
                        .WithMany("Rates")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyIMDB.Data.Entities.User", "Profile")
                        .WithMany("Rates")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.User", b =>
                {
                    b.HasOne("MyIMDB.Data.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("MyIMDB.Data.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");
                });

            modelBuilder.Entity("MyIMDB.Data.Entities.WatchLaterMovies", b =>
                {
                    b.HasOne("MyIMDB.Data.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyIMDB.Data.Entities.User", "User")
                        .WithMany("WatchLaterList")
                        .HasForeignKey("UsereId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
