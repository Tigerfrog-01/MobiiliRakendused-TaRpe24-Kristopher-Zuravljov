using Microsoft.Maui.Accessibility;
using Microsoft.Maui.Controls;

namespace TaRpe24_Kristopher_Zuravljov
{
    public partial class MainPage : ContentPage
{
    int count = 0;


    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        count++;

        // Loogika 1: Muuda teksti vastavalt arvule


        if (count == 1)
            CounterBtn.Text = $"Vajutatud {count} kord";

        else if (count >= 11)
        {
            BotImage.IsVisible = false; // Peidab pildi
            CounterLabel.Text = "Pilt kadus ära! Vajuta Reset.";
        }
        else if (count >= 5)
        {
            CounterBtn.BackgroundColor = Colors.Red;
            CounterBtn.TextColor = Colors.White;
        }

        else
        {
            CounterBtn.Text = $"Vajutatud {count} korda";
            BotImage.Rotation += 15;
        }





        var random = new Random();
        var randomColor = Color.FromRgb(
            random.Next(0, 256), // Red
            random.Next(0, 256), // Green
            random.Next(0, 256)  // Blue
                );



        // Loogika 2: Pööra pilti iga vajutusega 15 kraadi


        // Loogika 3: Muuda Labeli teksti

        ResetBtn.BackgroundColor = randomColor;

        SemanticScreenReader.Announce(CounterBtn.Text);
    }



    // UUS MEETOD: Reset nupu jaoks
    private void OnResetClicked(object? sender, EventArgs e)
    {
        count = 0;
        CounterBtn.Text = "Vajuta mind";
        CounterLabel.Text = "Alustame uuesti!";
        BotImage.Rotation = 0; // Pilt läheb otseks tagasi
        BotImage.IsVisible = true;
    }
}
}
