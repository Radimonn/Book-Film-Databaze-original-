using System.Collections.ObjectModel;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace StredoEvropskaFilmovaDatabaze.Services;

public class FilmyDatabaze
{
    public static FilmyDatabaze Instance = new FilmyDatabaze();

    public ObservableCollection<Filmy> FilmySeznamy { get; set; } = new();
    public ObservableCollection<Filmy> FiltrovaneFilmy { get; set; } = new();

    public void SaveFilmy()
    {
        var cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StredoEvropskaFilmovaDatabaze");
        var cestaF = Path.Combine(cesta, "Filmy.json");
        
        File.WriteAllText(cestaF, JsonSerializer.Serialize(FilmySeznamy));
    }

    public void LoadFilmy()
    {
        var cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StredoEvropskaFilmovaDatabaze");
        var cestaF = Path.Combine(cesta, "Filmy.json");
        
        FilmySeznamy = JsonSerializer.Deserialize<ObservableCollection<Filmy>>(File.ReadAllText(cestaF));
        
        Filtrace("");
    }

    public void PridatFilm(string nazev)
    {
        FilmySeznamy.Add(new Filmy(nazev, null, null, null, null, false, null, null));
        FiltrovaneFilmy.Add(new Filmy(nazev, null, null, null, null, false, null, null));
    }

    public void Filtrace(string nazev)
    {
        FiltrovaneFilmy.Clear();

        if (string.IsNullOrEmpty(nazev))
        {
            foreach (var filmy in FilmySeznamy)
            {
                FiltrovaneFilmy.Add(filmy);
            }
        }

        else
        {
            foreach (var filmy in FilmySeznamy)
            {
                if (filmy.nazev != null && filmy.nazev.Contains(nazev))
                {
                    FiltrovaneFilmy.Add(filmy);
                }
            }
        }
    }
}