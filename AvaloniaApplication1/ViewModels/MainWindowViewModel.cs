using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using Avalonia;
using AvaloniaApplication1.Models;
using AvaloniaLibraryManagementSystemModels.Systems;
using ReactiveUI;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using AvaloniaApplication1.Data;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Book _selectedBook;
        public string Greeting => "Welcome to Library Managment System!";
        public DataBase Db;

        private DatabaseContext _databaseContext;
        public ObservableCollection<Book> Books { get; }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedBook, value);
                Console.WriteLine(_selectedBook.Title);
            }
        }

        public MainWindowViewModel()
        {
            Serializer serializer = new Serializer();

            var books = new List<Book>
            {
                new Book(1, "To Kill a Mockingbird", "Harper Lee",
                    "9780061120084",
                    DateOnly.FromDateTime(new DateTime(1960, 7, 11)),
                    "J.B. Lippincott & Co.",
                    "A classic novel about racial injustice in the Deep South",
                    true,
                    Genres: new List<Genre>
                    {
                        new Genre(1, "Classic"),
                        new Genre(2, "Fiction")
                    }),
                new Book(2, "The Hitchhiker's Guide to the Galaxy", "Douglas Adams",
                    "9780345391806",
                    DateOnly.FromDateTime(new DateTime(1979, 10, 12)), "Pan Books",
                    "A comedic science fiction series about an unwitting human and his alien friend", false,
                    Genres: new List<Genre> { new Genre(3, "Science Fiction"), new Genre(4, "Comedy") }),
                new Book(3, "1984", "George Orwell", "9780451524935", DateOnly.FromDateTime(new DateTime(1949, 6, 8)),
                    "Secker and Warburg", "A dystopian novel about a totalitarian future society", true,
                    Genres: new List<Genre> { new Genre(5, "Dystopian"), new Genre(6, "Classic") }),
                new Book(4, "The Lord of the Rings", "J.R.R. Tolkien", "9780618260589",
                    DateOnly.FromDateTime(new DateTime(1954, 7, 29)), "Allen & Unwin",
                    "A high fantasy novel about a hobbit's quest to destroy the One Ring", false,
                    Genres: new List<Genre> { new Genre(7, "Fantasy"), new Genre(8, "Adventure") }),
                new Book(5, "Pride and Prejudice", "Jane Austen", "9780486280511",
                    DateOnly.FromDateTime(new DateTime(1813, 1, 28)), "T. Egerton",
                    "A romantic novel about the lives of the Bennett sisters in 19th-century England", true,
                    Genres: new List<Genre> { new Genre(9, "Romance"), new Genre(10, "Classic") }),
                new Book(6, "The Catcher in the Rye", "J.D. Salinger", "9780316769174",
                    DateOnly.FromDateTime(new DateTime(1951, 7, 16)), "Little, Brown and Company",
                    "A coming-of-age novel about teenage angst and alienation", true,
                    Genres: new List<Genre> { new Genre(11, "Young Adult"), new Genre(12, "Classic") }),
                new Book(7, "The Great Gatsby", "F. Scott Fitzgerald", "9780451520771",
                    DateOnly.FromDateTime(new DateTime(1925, 4, 10)), "Charles Scribner's Sons",
                    "A novel about the American Dream and the excesses of the Roaring Twenties", false,
                    Genres: new List<Genre> { new Genre(13, "Classic"), new Genre(14, "Historical Fiction") }),
                new Book(8, "War and Peace", "Leo Tolstoy", "9780679734774",
                    DateOnly.FromDateTime(new DateTime(1865, 1, 1)), "The Russian Messenger",
                    "A historical novel about the Napoleonic Wars and their impact on Russian society", true,
                    Genres: new List<Genre> { new Genre(15, "Historical Fiction"), new Genre(16, "Classic") }),
                new Book(9, "Moby-Dick", "Herman Melville", "9780451526995",
                    DateOnly.FromDateTime(new DateTime(1851, 11, 14)), "Harper & Brothers",
                    "An epic novel about the obsessive hunt for a white whale", false,
                    Genres: new List<Genre> { new Genre(17, "Adventure"), new Genre(18, "Classic") }),
                new Book(10, "The Picture of Dorian Gray", "Oscar Wilde", "9780486280542",
                    DateOnly.FromDateTime(new DateTime(1890, 7, 20)), "Lippincott's Monthly Magazine",
                    "A philosophical novel about the nature of beauty and morality", true,
                    Genres: new List<Genre> { new Genre(19, "Philosophical"), new Genre(20, "Classic") }),
                new Book(11, "Wuthering Heights", "Emily Brontë", "9780486280559",
                    DateOnly.FromDateTime(new DateTime(1847, 12, 1)), "Thomas Cautley Newby",
                    "A classic romance novel about the tumultuous relationship between Catherine and Heathcliff", false,
                    Genres: new List<Genre> { new Genre(21, "Romance"), new Genre(22, "Classic") }),
                new Book(12, "Jane Eyre", "Charlotte Brontë", "9780486280566",
                    DateOnly.FromDateTime(new DateTime(1847, 10, 16)), "Smith, Elder & Co.",
                    "A gothic romance novel about a young woman's journey to independence", true,
                    Genres: new List<Genre> { new Genre(23, "Gothic"), new Genre(24, "Classic") }),
                new Book(13, "The Count of Monte Cristo", "Alexandre Dumas", "9780451527015",
                    DateOnly.FromDateTime(new DateTime(1844, 8, 18)), "Le Journal des Débats",
                    "An adventure novel about betrayal, revenge, and redemption", false,
                    Genres: new List<Genre> { new Genre(25, "Adventure"), new Genre(26, "Classic") }),
                new Book(14, "The Adventures of Huckleberry Finn", "Mark Twain", "9780486280573",
                    DateOnly.FromDateTime(new DateTime(1885, 2, 18)), "Charles L. Webster and Company",
                    "A classic American novel about a young boy's journey down the Mississippi River", true,
                    Genres: new List<Genre> { new Genre(27, "Classic"), new Genre(28, "Adventure") }),
                new Book(15, "The Scarlet Letter", "Nathaniel Hawthorne", "9780486280580",
                    DateOnly.FromDateTime(new DateTime(1850, 3, 16)), "Ticknor, Reed, and Fields",
                    "A novel about sin, guilt, and redemption in 17th-century Puritan Massachusetts", false,
                    Genres: new List<Genre> { new Genre(29, "Classic"), new Genre(30, "Historical Fiction") })
            };
            /*Db = new SqlLiteDB("Library.db");
            Db.OpenConnection();*/

            //Db.PrepareDB();
            /*Db = new MssqlBase("ARSENIY-DESKTOP", "Library", true);
            Db.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "use Library;\n\nSELECT \n  MAX(Книги.Заголовок) AS Заголовок,\n  MAX(Книги.Описание) AS Описание,\n  MAX(Авторы.Фамилия) AS Фамилия,\n  MAX(Авторы.Имя) AS Имя,\n  MAX(Авторы.Отчество) AS Отчество,\n  MAX(Авторы.Псевдоним) AS Псевдоним,\n  MAX(ББК.Массовые_Индекс) AS Номер_ББК,\n  MAX(ББК.Название_раздела) AS Название_ББК,\n  MAX(Книги.Дата) AS Дата,\n  MAX(Издатели.Имя_Издателя) AS Имя_Издателя,\n  STRING_AGG(Жанры.Название, \', \') AS Жанры\nFROM \n  Книги\n  INNER JOIN Авторы ON Книги.Код_Автор = Авторы.Код_Автор\n  INNER JOIN ББК ON Книги.Код_ББК = ББК.Код_ББК\n  INNER JOIN Издатели ON Книги.Код_Издателя = Издатели.Код_Издателя\n  INNER JOIN Жанры_Книги ON Книги.Код_Книги = Жанры_Книги.Код_Книги\n  INNER JOIN Жанры ON Жанры_Книги.Код_Жанр = Жанры.Код_Жанр\nGROUP BY \n  Книги.Код_Книги\nORDER BY \n  Книги.Код_Книги;";
            command.Connection = Db.GetConnection();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                reader.Read();
                object val = reader.GetValue(3);
                Console.WriteLine(val);
            }*/

            Books = new ObservableCollection<Book>(books);

            /*string filePath = "people.xml"; // adjust the file path as needed
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    Books = (ObservableCollection<Person>)serializer.DeserializeFromXmlStream(fileStream, typeof(ObservableCollection<Person>));
                }
            }
            else
            {
                // Create a new instance of Books if it doesn't exist
                var people = new List<Person>
                {
                    new Person("Neil", "Armstrong"),
                    new Person("Buzz", "Lightyear"),
                    new Person("James", "Kirk")
                };
                Books = new ObservableCollection<Person>(people);
            }*/

            //Application.Current.Exit += (sender, e) => { };
        }

        private async void LoadBooks()
        {
            var books = await Task.Run(() => _databaseContext.GetBooks());
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }
    }
}