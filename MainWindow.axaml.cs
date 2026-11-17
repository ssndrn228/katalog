
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
            string[] parts = line.Split(';');
            if (parts.Length != 3)
            {
                throw new InvalidDataException($"Nieprawidłowy format pozycji: {line}");
            }

            ItemsList.Items.Add(new CatalogItem(parts[0], parts[1], parts[2]));
        }
    }

    private void OnItemSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (ItemsList.SelectedItem is CatalogItem item)
        {
            TitleText.Text = item.Title;
            YearText.Text = item.Year;
            RatingText.Text = item.Rating;
            ListScreen.IsVisible = false;
            DetailsScreen.IsVisible = true;
        }
    }

    private void OnBackClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DetailsScreen.IsVisible = false;
        ListScreen.IsVisible = true;
        ItemsList.SelectedItem = null;
    }

    private void OnRefreshClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        LoadItems();
    }

    private class CatalogItem
    {
        public string Title { get; }
        public string Year { get; }
        public string Rating { get; }

        public CatalogItem(string title, string year, string rating)
        {
            Title = title;
            Year = year;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"{Title} {Year} {Rating}";
        }
    }
}
