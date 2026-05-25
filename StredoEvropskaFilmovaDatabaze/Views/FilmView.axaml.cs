using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using StredoEvropskaFilmovaDatabaze.Services;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.Media.Imaging;

namespace StredoEvropskaFilmovaDatabaze.Views;

public partial class FilmView : UserControl
{
    public FilmView()
    {
        InitializeComponent();
    }
    
    public FilmView(Filmy film)
    {
        var centrala = new Centrala();
        centrala.AktualniFilm = film;
        DataContext = centrala;
        InitializeComponent();

        if (film.sprite != null)
        {
            ObrazekB.IsVisible = false;
            Obrazek.Source = new Bitmap(film.sprite);
        }
        else
        {
            
            ObrazekB.IsVisible = true;
        }
    }

    public void Zpet(object? sender, RoutedEventArgs e)
    {
        FilmyDatabaze.Instance.SaveFilmy();
        Content = new HlavniMenu();
    }

    public async void VyberObrazek(object? sender, RoutedEventArgs e)
    {
        var okno = TopLevel.GetTopLevel(this)!;

        var soubory = await okno.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Vyber obrázek",
            AllowMultiple = false,
            FileTypeFilter = new[] { FilePickerFileTypes.ImageAll}
        });

        if (soubory.Count > 0)
        {
            ObrazekB.IsVisible = false;
            ((Centrala)DataContext).AktualniFilm.sprite = soubory[0].Path.LocalPath;
            Obrazek.Source = new Bitmap(((Centrala)DataContext).AktualniFilm.sprite);
        }
    }

    public void ZmenaZanr(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            ((Centrala)DataContext).AktualniFilm.zanr = btn.Content.ToString() switch
            {
                "Fantasy" => "Fantasy",
                "Thriller" => "Thriller",
                "Sci-Fi" => "Sci-Fi",
                "Drama" => "Drama",
                "Detektivka" => "Detektivka",
                "Komedie" => "Komedie",
                "Horror" => "Horror",
                "Erotický" => "Erotický",
                "Dokument" => "Dokument",
                "Akční" => "Akční",
            };
            
            FilmyDatabaze.Instance.SaveFilmy();
            Zanr.Text = ((Centrala)DataContext).AktualniFilm.zanr;
        }
    }

    public void Odstranit(object? sender, RoutedEventArgs e)
    {
        FilmyDatabaze.Instance.FilmySeznamy.Remove(((Centrala)DataContext).AktualniFilm);
        FilmyDatabaze.Instance.SaveFilmy();
        Content = new HlavniMenu();
    }
    
   
}