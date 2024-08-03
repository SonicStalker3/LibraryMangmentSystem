using System.Collections.ObjectModel;
using System;
using Avalonia;
using ReactiveUI;
using System.Linq;
using AvaloniaLibraryManagementSystemModels.Model;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Book _selectedBook;
        public string Greeting => "Welcome to Library Managment System!";

        private DatabaseContext _databaseContext = new DatabaseContext();

        public ColumnCountConverter ColumnCountConverter = new ColumnCountConverter();
        public ObservableCollection<Book> Books { get; }

        public ObservableCollection<Genre>? Genres { get; }

        private ObservableCollection<string> _genresNames;
        public ObservableCollection<string> GenresNames
        {
            get
            {
                //Console.WriteLine(_genresNames[0]);
                return _genresNames;
            }
        }

        public Vector ScrollPosition { get; set; }
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedBook, value);
                Console.WriteLine(_selectedBook.Id);
            }
        }
        
        public MainWindowViewModel()
        {
            using (var context = new DatabaseContext())
            {
                if (context.Database.EnsureCreated())
                {
                    context.Database.Migrate();
                    context.CreateDebugDatabase();
                }
            }
            
            Books = new ObservableCollection<Book>(_databaseContext.GetBooks().ToList());
            Genres = new ObservableCollection<Genre>(_databaseContext.GetGenres().ToList());
            Console.WriteLine(Books[0].BookGenres.Count);
            if (Genres != null) _genresNames = new ObservableCollection<string>(Genres.ToList().Select(x => x.Name));
        }
    }
}