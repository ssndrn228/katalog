
using Avalonia.Controls;
using System.IO;

namespace katalog;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadItems();
    }

    private void LoadItems()
    {
        ItemsList.Items.Clear();

        string[] lines = File.ReadAllLines("dane/pozycje.txt");

        foreach (string line in lines)
        {
            ItemsList.Items.Add(line.Replace(';', ' '));
        }
    }

    private void OnRefreshClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        LoadItems();
    }
}
