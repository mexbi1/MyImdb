﻿using System;
using System.Linq;
using MyIMDB.Data.Entities;

namespace MyIMDB.Data.DataSeeding
{
    public class DataDbInitializer
    {
        private static readonly Genre[] genres = new[]
                {
                    new Genre(){ Title="Action"},
                    new Genre(){ Title="Adventure"},
                    new Genre(){ Title="Animation"},
                    new Genre(){ Title="Biography"},
                    new Genre(){ Title="Comedy"},
                    new Genre(){ Title="Crime"},
                    new Genre(){ Title="Documentary"},
                    new Genre(){ Title="Drama"},
                    new Genre(){ Title="Fantasy"},
                    new Genre(){ Title="Film Noir"},
                    new Genre(){ Title="History"},
                    new Genre(){ Title="Horror"},
                    new Genre(){ Title="Romance"},
                    new Genre(){ Title="Sci - Fi"},
                    new Genre(){ Title="Superhero"},
                    new Genre(){ Title="Thriller"},
                    new Genre(){ Title="War"},
                    new Genre(){ Title="Western"},
                };
        private static readonly Country[] countries = new[]
                {
                    new Country() { Name = "USA"},
                    new Country() { Name = "Germany"},
                    new Country() { Name = "Italy"},
                    new Country() { Name = "Spain" },
                    new Country() { Name = "France" }
    };
        private static readonly Gender[] genders = new[]
                {
                    new Gender() { Title = "Male"},
                    new Gender() { Title = "Female"}
    };
        private static readonly MoviePersonType[] types = new[]
                {
                    new MoviePersonType() { Type = "Star"},
                    new MoviePersonType() { Type = "Directer"}
                };
        private static readonly Movie[] movies = new[]
                {
                    new Movie(){
                    Title = "The Shawshank Redemption", Year = 1994,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    },
                    new Movie(){
                    Title = "The Green Mile", Year = 1999,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Description = "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift."
                    }
                };

    public static void Seed(ImdbContext context)
        {
            var france = countries.FirstOrDefault(x => x.Name == "France");
            var usa = countries.FirstOrDefault(x => x.Name == "USA");

            var male = genders.FirstOrDefault(x => x.Title == "Male");
            var female = genders.FirstOrDefault(x => x.Title == "Female");

            var directerType = types.FirstOrDefault(x => x.Type == "Directer");
            var starType = types.FirstOrDefault(x => x.Type == "Star");

            var shawshank = movies.FirstOrDefault(x => x.Title == "The Shawshank Redemption");
            var greenMile = movies.FirstOrDefault(x => x.Title == "The Green Mile");

            if (!context.Countries.Any())
                context.Countries.AddRange(countries);

            if (!context.Genders.Any())
                context.Genders.AddRange(genders);

            if (!context.Genres.Any())
                context.Genres.AddRange(genres);

            if (!context.MoviePersonsType.Any())
                context.MoviePersonsType.AddRange(types);

            if (!context.Movies.Any())
                context.Movies.AddRange(movies);
            
            if (!context.MoviePersons.Any())
            {
                var persons = new[]
                {
                    new MoviePerson() { FullName="Frank Darabont",
                        Biography ="Three-time Oscar nominee Frank Darabont was born in a refugee camp in 1959 in Montbeliard, France, the son of Hungarian parents who had fled Budapest during the failed 1956 Hungarian revolution. Brought to America as an infant, he settled with his family in Los Angeles and attended Hollywood High School. His first job in movies was as a production",
                        GenderId = male.Id,
                        CountryId=france.Id,
                        ImageUrl ="https://m.media-amazon.com/images/M/MV5BNjk0MTkxNzQwOF5BMl5BanBnXkFtZTcwODM5OTMwNA@@._V1_UY317_CR20,0,214,317_AL_.jpg",
                        DateOfBirth = new DateTime(1959,1,29) },
                    new MoviePerson() { FullName="Tim Robbins",
                        Biography ="Born in West Covina, California, but raised in New York City, Tim Robbins is the son of former The Highwaymen singer Gil Robbins and actress Mary Robbins (née Bledsoe). Robbins studied drama at UCLA, where he graduated with honors in 1981. That same year, he formed the Actors' Gang theater group, an experimental ensemble that expressed radical ...",
                        GenderId = male.Id,
                        CountryId=usa.Id,
                        ImageUrl ="https://m.media-amazon.com/images/M/MV5BMTI1OTYxNzAxOF5BMl5BanBnXkFtZTYwNTE5ODI4._V1_UY317_CR16,0,214,317_AL_.jpg",
                        DateOfBirth = new DateTime(1959,1,29) },
                    new MoviePerson() { FullName="Morgan Freeman",
                        Biography ="With an authoritative voice and calm demeanor, this ever popular American actor has grown into one of the most respected figures in modern US cinema. Morgan was born on June 1, 1937 in Memphis, Tennessee, to Mayme Edna (Revere), a teacher, and Morgan Porterfield Freeman, a barber. The young Freeman attended Los Angeles City College before serving ...",
                        GenderId = male.Id,
                        CountryId=usa.Id,
                        ImageUrl ="https://m.media-amazon.com/images/M/MV5BMTc0MDMyMzI2OF5BMl5BanBnXkFtZTcwMzM2OTk1MQ@@._V1_UX214_CR0,0,214,317_AL_.jpg",
                        DateOfBirth = new DateTime(1937,5,1) },

                    new MoviePerson() { FullName="Tom Hanks",
                        Biography ="Thomas Jeffrey Hanks was born in Concord, California, to Janet Marylyn (Frager), a hospital worker, and Amos Mefford Hanks, an itinerant cook. His mother's family, originally surnamed Fraga, was entirely Portuguese, while his father was of mostly English ancestry. Tom grew up in what he has called a fractured family. He moved around a great ... ",
                        GenderId = male.Id,
                        CountryId = usa.Id,
                        ImageUrl ="https://m.media-amazon.com/images/M/MV5BMTQ2MjMwNDA3Nl5BMl5BanBnXkFtZTcwMTA2NDY3NQ@@._V1_UY317_CR2,0,214,317_AL_.jpg",
                        DateOfBirth = new DateTime(1956,5,9) },
                    new MoviePerson() { FullName="Michael Clarke Duncan",
                        Biography ="Michael Clarke Duncan was born on December 10, 1957 in Chicago, Illinois. Raised by his single mother, Jean, a house cleaner, on Chicago's South Side, Duncan grew up resisting drugs and alcohol, instead concentrating on school. He wanted to play football in high school, but his mother wouldn't let him, afraid that he would get hurt. He then turned...",
                        GenderId = male.Id,
                        CountryId = usa.Id,
                        ImageUrl ="https://m.media-amazon.com/images/M/MV5BMTI3NDY2ODk5OV5BMl5BanBnXkFtZTYwMjQ0NzE0._V1_.jpg",
                        DateOfBirth = new DateTime(1957,12,10) },
                    new MoviePerson() { FullName="David Morse",
                        Biography = "David Morse, a 6' 4 tall blue-eyed blond who performed on stage for 10 years before breaking into film, has become established as a respected supporting, character actor and second lead.He was born the first of four children of Charles, a sales manager, and Jacquelyn Morse, a schoolteacher, on October 11, 1953, in Beverly, Massachusetts.He grew...",
                        GenderId = male.Id,
                        CountryId = usa.Id,
                        ImageUrl ="https://m.media-amazon.com/images/M/MV5BMTgwNjUzOTE1N15BMl5BanBnXkFtZTYwNTU4NDQ0._V1_UY317_CR1,0,214,317_AL_.jpg",
                        DateOfBirth = new DateTime(1953,10,11) },

                };
                context.MoviePersons.AddRange(persons);
                context.SaveChanges();
            }
            
            if (!context.MoviePersonsMovies.Any())
            {
                var freeman = context.MoviePersons.FirstOrDefault(x=>x.FullName== "Morgan Freeman");
                var darabont = context.MoviePersons.FirstOrDefault(x => x.FullName == "Frank Darabont");
                var robins = context.MoviePersons.FirstOrDefault(x => x.FullName == "Tim Robbins");

                var hanks = context.MoviePersons.FirstOrDefault(x => x.FullName == "Tom Hanks");
                var duncan = context.MoviePersons.FirstOrDefault(x => x.FullName == "Michael Clarke Duncan");
                var morse = context.MoviePersons.FirstOrDefault(x => x.FullName == "David Morse");

                var mpm = new[]
                {
                    new MoviePersonsMovies(){ MovieId=shawshank.Id,MoviePersonId=freeman.Id,MoviePersonTypeId=starType.Id},
                    new MoviePersonsMovies(){ MovieId=shawshank.Id,MoviePersonId=darabont.Id,MoviePersonTypeId=directerType.Id},
                    new MoviePersonsMovies(){ MovieId=shawshank.Id,MoviePersonId=robins.Id,MoviePersonTypeId=starType.Id},

                    new MoviePersonsMovies(){ MovieId=greenMile.Id,MoviePersonId=darabont.Id,MoviePersonTypeId=directerType.Id},
                    new MoviePersonsMovies(){ MovieId=greenMile.Id,MoviePersonId=hanks.Id,MoviePersonTypeId=starType.Id},
                    new MoviePersonsMovies(){ MovieId=greenMile.Id,MoviePersonId=duncan.Id,MoviePersonTypeId=starType.Id},
                    new MoviePersonsMovies(){ MovieId=greenMile.Id,MoviePersonId=morse.Id,MoviePersonTypeId=starType.Id},
                };

                context.MoviePersonsMovies.AddRange(mpm);
            }
            if (!context.MoviesCountries.Any())
            {
                var mc = new[] {
                    new MoviesCountries(){CountryId=usa.Id, MovieId=shawshank.Id  },
                    new MoviesCountries(){CountryId=usa.Id, MovieId=greenMile.Id  },
                    new MoviesCountries(){CountryId=france.Id, MovieId=greenMile.Id  },
                };
                context.MoviesCountries.AddRange(mc);
            }
            if (!context.MoviesGenres.Any())
            {
                var drama = context.Genres.FirstOrDefault(x=>x.Title=="Drama");
                var crime = context.Genres.FirstOrDefault(x => x.Title == "Crime");
                var fantasy = context.Genres.FirstOrDefault(x => x.Title == "Fantasy");
                var mg = new[]
                {
                    new MoviesGenres(){ MovieId=shawshank.Id, GenreId= drama.Id},
                    new MoviesGenres(){ MovieId=greenMile.Id, GenreId= drama.Id},
                    new MoviesGenres(){ MovieId=greenMile.Id, GenreId= crime.Id},
                    new MoviesGenres(){ MovieId=greenMile.Id, GenreId= fantasy.Id},
                };
                context.MoviesGenres.AddRange(mg);
            }
            context.SaveChanges();
        }
    }
}
