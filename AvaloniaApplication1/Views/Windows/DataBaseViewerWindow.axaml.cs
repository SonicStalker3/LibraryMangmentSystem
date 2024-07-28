using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication1.Views.Windows;

public partial class DataBaseViewerWindow : Window
{
    public DataBaseViewerWindow()
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

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine();
    }
}