using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication1.Views.Windows;

public partial class NewBookWindow : Window
{
    public NewBookWindow()
    {
        InitializeComponent();
        //genreTagsListBox.ItemsSource = Genres;
    }

    private void AddBookButton_Click(object? sender, RoutedEventArgs e)
    {
        //var book = new Book { Title = Title, Author = Author, GenreTags = GenreTags.ToList() };
        throw new System.NotImplementedException();
    }

    private void Cover_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
}