using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using AvaloniaApplication1.Models;
using AvaloniaLibraryManagementSystemModels.Model;
using AvaloniaLibraryManagementSystemModels.Systems;

namespace AvaloniaApplication1.Data
{
    public class DatabaseContext
    {
        private readonly string _connectionString;

        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            // Create a command to execute a query
            using var command = new SQLiteCommand(connection);
            
            // Create the Books table
            command.CommandText = SqlRequests.CreateNewDB;
            command.ExecuteNonQuery();
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = SqlRequests.GetBookQuery;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string genresString = reader.GetString(4);
                            List<Genre> genres = genresString.Split(',').Select(g => new Genre { Name = g.Trim() })
                                .ToList();
                            yield return new Book
                            {
                                Id = reader.GetInt32("Код_Книги"),
                                Title = reader.GetString("Заголовок"),
                                Author = new Author
                                {
                                    Id = Int32.Parse(reader.GetString(2).Split(' ')[0]),
                                    FirstName = reader.GetString(2).Split(' ')[1],
                                    LastName = reader.GetString(2).Split(' ')[2]
                                },
                                BBK = new BBK
                                {
                                    Code = reader.GetString(3).Split(' ')[1],
                                    SciIndex = reader.GetString(3).Split(' ')[0],
                                    Name = reader.GetString(3).Split(' ')[2]
                                },
                                Genres = genres,
                                PublicationDate = DateOnly.Parse(reader.GetString(5)),
                                Publisher = new Publisher { Name = reader.GetString(6) },
                                Description = reader.IsDBNull(7) ? null : reader.GetString(7)
                            };
                            //Console.WriteLine(reader.GetString(2).Split(' ')[0]+ ' ' + reader.GetString(2).Split(' ')[1]);
                            //Console.WriteLine(reader.GetString(2).Split(' ')[2]);
                        }
                    }
                }
            }
        }

        public void AddBooks(List<Book> books, string authorFilter = null, string genreFilter = null)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(connection);

                // Insert books into Books table
                var bookQuery = @"
            INSERT INTO Books (Код_Книги, Заголовок, Author, BBK, Дата, Publisher, Описание)
            VALUES (@Код_Книги, @Заголовок, @Author, @BBK, @Дата, @Publisher, @Описание);
        ";

                // Insert genres into ЖанрыКниги table
                var genreQuery = @"
            INSERT INTO ЖанрыКниги (Код_Книги, Код_Жанра)
            VALUES (@Код_Книги, @Код_Жанра);
        ";

                foreach (var book in books)
                {
                    // Insert book into Books table
                    command.Parameters.Clear();
                    command.CommandText = bookQuery;
                    command.Parameters.AddWithValue("@Код_Книги", book.Id);
                    command.Parameters.AddWithValue("@Заголовок", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@BBK", book.BBK);
                    command.Parameters.AddWithValue("@Дата", book.PublicationDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Publisher", book.Publisher);
                    command.Parameters.AddWithValue("@Описание", book.Description ?? string.Empty);
                    command.ExecuteNonQuery();

                    // Insert genres into ЖанрыКниги table
                    foreach (var genre in book.Genres)
                    {
                        command.Parameters.Clear();
                        command.CommandText = genreQuery;
                        command.Parameters.AddWithValue("@Код_Книги", book.Id);
                        command.Parameters.AddWithValue("@Код_Жанра", genre.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public ObservableCollection<Genre> GetGenres()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(connection);

                command.CommandText = @"
                                        SELECT Код_Жанр, Название
                                        FROM Жанры;
                                      ";

                var genres = new ObservableCollection<Genre>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genres.Add(new Genre
                        {
                            Id = reader.GetInt32("Код_Жанр"),
                            Name = reader.GetString("Название")
                        });
                    }
                }

                return genres;
            }
        }
    }
}