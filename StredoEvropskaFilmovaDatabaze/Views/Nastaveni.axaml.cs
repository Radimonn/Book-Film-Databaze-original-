using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using StredoEvropskaFilmovaDatabaze.Services;

namespace StredoEvropskaFilmovaDatabaze.Views;

public partial class Nastaveni : UserControl
{
    public Nastaveni()
    {
        DataContext = new Centrala();
        InitializeComponent();
        
        SliderHudba.Value = Settings.Instance.Hlasitost;
    }

    public void ZmenaHlasitosti(object? sender, RangeBaseValueChangedEventArgs e)
    {
        Settings.Instance.Hlasitost = (int)SliderHudba.Value;
        Audio.Instance.NastavHlasitost();
        Settings.Instance.SaveSettings();
    }

    public void Zpet(object? sender, RoutedEventArgs e)
    {
        SliderHudba.ValueChanged -= ZmenaHlasitosti;
        Content = new HlavniMenu();
        Settings.Instance.SaveSettings();
    }

    public void ZmenaJazyka(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            Settings.Instance.Jazyk = btn.Content.ToString() switch
            {
                "Čeština" => "CZ",
                "Slovenština" => "SK",
                "Polština" => "PL",
                "Němčina" => "DE",
                "Maďarština" => "MGR",
                "Chorvatština" => "CHO",
                "Ukrajinština" => "UKR",
                "Rumunština" => "RO",
                "Bulharština" => "BUL",
                "Řečtina" => "GR",
                "Srbština" => "SRB",
                "Litevština" => "LT",
                "Italština" => "IT",
                "Běloruština" => "BEL",
                "Bosenština" => "BOS",
                "Albánština" => "AL",
            };
            Settings.Instance.SaveSettings();
            DataContext = new Centrala();
        }
    }
}