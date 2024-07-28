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

        private void SearchField_OnTextChanged(object? sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}