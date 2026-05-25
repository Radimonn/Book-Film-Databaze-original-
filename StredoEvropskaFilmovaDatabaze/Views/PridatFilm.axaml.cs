using System.Runtime.CompilerServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using StredoEvropskaFilmovaDatabaze.Services;

namespace StredoEvropskaFilmovaDatabaze.Views;

public partial class PridatFilm : UserControl
{
    public PridatFilm()
    {
        DataContext = new Centrala();
        InitializeComponent();
        chyba.IsVisible = false;
    }
    
    public void Zpet(object? sender, RoutedEventArgs e)
    {
        Content = new HlavniMenu();
    }

    public void Pridat(object? sender, RoutedEventArgs e)
    {
        if (Nazev.Text != null)
        {
            FilmyDatabaze.Instance.PridatFilm(Nazev.Text);
            FilmyDatabaze.Instance.SaveFilmy();
            Content = new HlavniMenu();
        }
        else
        {
            chyba.IsVisible = true;
        }
    }
}