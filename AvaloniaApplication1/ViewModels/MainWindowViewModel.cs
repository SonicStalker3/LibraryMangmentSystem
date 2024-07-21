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

        private DatabaseContext _databaseContext = new DatabaseContext($"Data Source=Library.db");

        public ColumnCountConverter ColumnCountConverter = new ColumnCountConverter();
        public ObservableCollection<Book> Books { get; }

        public ObservableCollection<Genre> Genres { get; }
        public ObservableCollection<string> GenresNames { get; }
        
        public Vector ScrollPosition { get; set; }
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedBook, value);
                Console.WriteLine(_selectedBook.Id);
            }
        }
        
        
        

        public MainWindowViewModel()
        {
            Books = new ObservableCollection<Book>(_databaseContext.GetBooks());
            Genres = _databaseContext.GetGenres();
            GenresNames = new ObservableCollection<string>(Genres.Select(x => x.Name));
            //Application.Current.Exit += (sender, e) => { };
        }
    }
}