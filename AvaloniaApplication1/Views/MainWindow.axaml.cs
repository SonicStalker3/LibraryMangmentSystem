using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Views.Windows;

namespace AvaloniaApplication1.Views
{
    public partial class MainWindow : Window
    {
        //public Book SelectedBook { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewBookButton_Click(object? sender, RoutedEventArgs e)
        {
            NewBookWindow newBookWindow = new NewBookWindow();
            newBookWindow.Show(this);
        }

        private void SearchBookButton_Click(object? sender, RoutedEventArgs e)
        {
            SearchBookWindow searchBookWindow = new SearchBookWindow();
            searchBookWindow.Show(this);
        }

        private void AboutButton_Click(object? sender, RoutedEventArgs e)
        {
            AboutApplicationWindow aboutApplicationWindow = new AboutApplicationWindow();
            aboutApplicationWindow.Show(this);
        }

        private void BookSelected(object? sender, SelectionChangedEventArgs e)
        {
            ;
        }
    }
}