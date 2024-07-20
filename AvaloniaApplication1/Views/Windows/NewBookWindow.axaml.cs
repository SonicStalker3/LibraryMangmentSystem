using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Views.Windows;

public partial class NewBookWindow : Window
{
    public NewBookWindow()
    {
        InitializeComponent();
    }

    private void AddBookButton_Click(object? sender, RoutedEventArgs e)
    {
        //var book = new Book { Title = Title, Author = Author, GenreTags = GenreTags.ToList() };
        throw new System.NotImplementedException();
    }
}