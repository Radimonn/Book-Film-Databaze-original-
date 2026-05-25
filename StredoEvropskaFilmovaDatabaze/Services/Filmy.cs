using Avalonia.Controls;
using System;
using System.IO;
using System.Text.Json;
using Avalonia;
using System.Text.Json.Nodes;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using StredoEvropskaFilmovaDatabaze;

namespace StredoEvropskaFilmovaDatabaze.Services;

public class Filmy
{
    public string? nazev { get; set; }
    public DateTimeOffset? rok { get; set; }
    public string? hodnoceni { get; set; }
    public string? zanr  { get; set; }
    public string? popis  { get; set; }
    public TimeSpan? delka { get; set; }
    public bool? videl { get; set; }
    public string? sprite { get; set; }
    
    public Filmy(){}

    public Filmy(string? nazev, DateTimeOffset? rok, string? hodnoceni, string? zanr, string? popis, bool? videl, TimeSpan? delka, string? sprite)
    {
        this.nazev = nazev;
        this.rok = rok;
        this.hodnoceni = hodnoceni;
        this.zanr = zanr;
        this.popis = popis;
        this.videl = videl;
        this.delka = delka;
        this.sprite = sprite;
    }
}