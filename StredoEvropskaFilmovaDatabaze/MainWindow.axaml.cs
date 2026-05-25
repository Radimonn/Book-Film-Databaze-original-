using Avalonia.Controls;
using StredoEvropskaFilmovaDatabaze.Views;

namespace StredoEvropskaFilmovaDatabaze;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Content = new HlavniMenu();
    }
}