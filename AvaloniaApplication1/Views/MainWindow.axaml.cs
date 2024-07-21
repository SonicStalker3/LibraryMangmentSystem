using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.ViewModels;
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

        private void MainView_ScrollChanged(object? sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            var viewModel = DataContext as MainWindowViewModel;
            viewModel.ScrollPosition = scrollViewer.Offset;
        }
        
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            var viewModel = DataContext as MainWindowViewModel;
            scrollViewer.Offset = viewModel.ScrollPosition;
        }

        private void BookElement_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            Border border = sender as Border;
            Book book = border.DataContext as Book;
            
            
            if (book != null)
            {
                Console.WriteLine(book.Author.FullName);
                // Create a new window and pass the Book instance as a parameter
                /*BookDetailsWindow window = new BookDetailsWindow(book);
                window.ShowDialog();*/
            }
        }
    }
}