using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using StredoEvropskaFilmovaDatabaze.Services;

namespace StredoEvropskaFilmovaDatabaze.Views;

public partial class HlavniMenu : UserControl
{
    public HlavniMenu()
    {
        DataContext = new Centrala();
        InitializeComponent();

        if (Centrala.hudba == true && !Design.IsDesignMode)
        {
            Centrala.hudba = false;
            Audio.Instance.Play("Assets/Hudba/Elevator Music & Elevator Jazz_ 3 HOURS of Jazzy Elevator Music and Elevator Jazz Music [xNjyG8S4_kI].mp3");
        }
    }
    
    protected override void OnDataContextChanged(EventArgs e)
    {
        base.OnDataContextChanged(e);
    
        if (DataContext is Centrala centrala)
        {
            centrala.FilmyDatabaze.Filtrace("");
        }
    }

    public void Nastaveni(object? sender, RoutedEventArgs e)
    {
        Content = new Nastaveni();
    }
    public void Konec(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    public void Vyhledat(object? sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        var dotaz = textBox?.Text ?? "";
        
        var centrala = DataContext as Centrala;
        centrala?.FilmyDatabaze.Filtrace(dotaz);
    }

    public void FilmView(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.DataContext is Filmy filmy)
            {
                ((Centrala)DataContext).AktualniFilm = filmy;
                Content = new FilmView(filmy);
            }
        }
    }
    
    public void PridatFilm(object? sender, RoutedEventArgs e)
    {
        Content = new PridatFilm();
    }
}