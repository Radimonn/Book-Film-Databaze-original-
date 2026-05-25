using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using StredoEvropskaFilmovaDatabaze;
using StredoEvropskaFilmovaDatabaze.Services;

namespace StredoEvropskaFilmovaDatabaze;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StredoEvropskaFilmovaDatabaze");
        var cestaFSettings = Path.Combine(cesta, "Settings.json");
        var cestaFFilmy = Path.Combine(cesta, "Filmy.json");

        if (Directory.Exists(cesta))
        {
            if (File.Exists(cestaFSettings))
            {
                Settings.Instance.LoadSettings();
            }
            else
            {
                File.WriteAllText(cestaFSettings, "{}");
            }

            if (File.Exists(cestaFFilmy))
            {
                FilmyDatabaze.Instance.LoadFilmy();
            }
            else
            {
                File.WriteAllText(cestaFFilmy, "[]");
            }
        }
        else
        {
            Directory.CreateDirectory(cesta);
            File.WriteAllText(cestaFSettings, "{}");
            File.WriteAllText(cestaFFilmy, "[]");
        }
        
        Settings.Instance.SaveSettings();
        FilmyDatabaze.Instance.SaveFilmy();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //FilmyDatabaze.Instance.FilmySeznamy.Add(new Filmy("Titanic", new DateTime(2001,12,2), "80", "Fantasy", null, false, TimeSpan.FromMinutes(200), null));
           // FilmyDatabaze.Instance.SaveFilmy();
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}