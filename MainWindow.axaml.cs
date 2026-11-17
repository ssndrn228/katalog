
using Avalonia.Controls;
using System;
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

    private void OnAddClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        TitleInput.Text = string.Empty;
        YearInput.Text = string.Empty;
        RatingInput.Text = string.Empty;
        FormError.IsVisible = false;
        ListScreen.IsVisible = false;
        FormScreen.IsVisible = true;
    }

    private void OnSaveClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string title = TitleInput.Text?.Trim() ?? string.Empty;
        string yearText = YearInput.Text?.Trim() ?? string.Empty;
        string ratingText = RatingInput.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(title))
        {
            ShowFormError("Wpisz tytuł.");
            return;
        }

        if (title.Contains(';') || title.Contains('\n') || title.Contains('\r'))
        {
            ShowFormError("Tytuł nie może zawierać średnika ani znaku nowej linii.");
            return;
        }

        if (!int.TryParse(yearText, out int year) || year <= 0)
        {
            ShowFormError("Rok musi być dodatnią liczbą całkowitą.");
            return;
        }

        if (!int.TryParse(ratingText, out int rating) || rating < 1 || rating > 10)
        {
            ShowFormError("Ocena musi być liczbą całkowitą od 1 do 10.");
            return;
        }

        string filePath = "dane/pozycje.txt";
        string existingData = File.ReadAllText(filePath);
        bool needsLineBreak = existingData.Length > 0
            && existingData[existingData.Length - 1] != '\n'
            && existingData[existingData.Length - 1] != '\r';
        string lineBreak = needsLineBreak ? Environment.NewLine : string.Empty;
        File.AppendAllText(filePath, $"{lineBreak}{title};{year};{rating}{Environment.NewLine}");

        LoadItems();
        FormScreen.IsVisible = false;
        ListScreen.IsVisible = true;
    }

    private void OnCancelClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        FormScreen.IsVisible = false;
        ListScreen.IsVisible = true;
    }

    private void ShowFormError(string message)
    {
        FormError.Text = message;
        FormError.IsVisible = true;
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
