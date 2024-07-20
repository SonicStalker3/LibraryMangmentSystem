using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using AvaloniaApplication1.Models;
using AvaloniaLibraryManagementSystemModels.Model;

namespace AvaloniaApplication1.Data
{
    public class DatabaseContext
    {
        private readonly string _connectionString;

        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                SELECT
                    k.Код_Книги,
                    k.Заголовок,
                    a.Имя || ' ' || a.Фамилия AS Author,
                    b.Научные_Индекс || ' ' || b.Массовые_Индекс AS BBK,
                    j.Название AS Genre,
                    k.Дата,
                    i.Имя_Издателя AS Publisher,
                    k.Описание
                FROM
                    Книги k
                    INNER JOIN Авторы a ON k.Код_Автор = a.Код_Автор
                    INNER JOIN ББК b ON k.Код_ББК = b.Код_ББК
                    INNER JOIN ЖанрыКниги jk ON k.Код_Книги = jk.Код_Книги
                    INNER JOIN Жанры j ON jk.Код_Жанр = j.Код_Жанр
                    INNER JOIN Издатели i ON k.Код_Издателя = i.Код_Издателя;
            ";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Book
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Author = new Author { FirstName = reader.GetString(2).Split(' ')[0], LastName = reader.GetString(2).Split(' ')[1] },
                                BBK = new BBK { Code = reader.GetString(3), Name = reader.GetString(3) },
                                Genres = new List<Genre> { new Genre { Name = reader.GetString(4) } },
                                PublicationDate = DateOnly.Parse(reader.GetString(5)),
                                Publisher = new Publisher { Name = reader.GetString(6) },
                                Description = reader.IsDBNull(7) ? null : reader.GetString(7)
                            };
                        }
                    }
                }
            }
        }
    }
}