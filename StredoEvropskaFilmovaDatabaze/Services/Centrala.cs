namespace StredoEvropskaFilmovaDatabaze.Services;

public class Centrala
{
    public Prekladac Prekladac { get; set; } =  new Prekladac();
    public Settings Settings { get; set; } = Settings.Instance;
    public Audio Audio { get; set; } = new Audio();
    public FilmyDatabaze FilmyDatabaze { get; set; } = FilmyDatabaze.Instance;
    public Filmy? AktualniFilm { get; set; }
    public static bool hudba { get; set; } = true;
}