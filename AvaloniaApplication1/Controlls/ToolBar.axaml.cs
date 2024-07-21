using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Views.Windows;

namespace AvaloniaApplication1.Controlls;

public partial class ToolBar : UserControl
{
    public ToolBar()
    {
        InitializeComponent();
    }
    
    private void NewBookButton_Click(object? sender, RoutedEventArgs e)
    {
        Window window = (Window)this.VisualRoot;
        NewBookWindow newBookWindow = new NewBookWindow();
        newBookWindow.Show(window);
    }

    private void SearchBookButton_Click(object? sender, RoutedEventArgs e)
    {
        Window window = (Window)this.VisualRoot;
        SearchBookWindow searchBookWindow = new SearchBookWindow();
        searchBookWindow.Show(window);
    }

    private void AboutButton_Click(object? sender, RoutedEventArgs e)
    {
        Window window = (Window)this.VisualRoot;
        AboutApplicationWindow aboutApplicationWindow = new AboutApplicationWindow();
        aboutApplicationWindow.Show(window);
    }
    
}