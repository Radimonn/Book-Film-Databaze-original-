using System;
using System.IO;
using System.Text.Json;
using Avalonia;
using System.Text.Json.Nodes;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using StredoEvropskaFilmovaDatabaze;

namespace StredoEvropskaFilmovaDatabaze.Services;

public class Settings
{
    public static Settings Instance = new Settings();
    
    public int Hlasitost { get; set; } = 50;
    public string Jazyk { get; set; } = "CZ";

    public void SaveSettings()
    {
        var cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StredoEvropskaFilmovaDatabaze");
        var cestaF = Path.Combine(cesta, "Settings.json");
        
        File.WriteAllText(cestaF, JsonSerializer.Serialize(this));
    }

    public void LoadSettings()
    {
        var cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StredoEvropskaFilmovaDatabaze");
        var cestaF = Path.Combine(cesta, "Settings.json");
        
        Settings.Instance = JsonSerializer.Deserialize<Settings>(File.ReadAllText(cestaF));
    }
}