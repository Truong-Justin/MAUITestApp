using MAUITestApp.Models;


namespace MAUITestApp;

public partial class MainPage : ContentPage
{
	// Object created at the class-level
	// to enable HTTP requests for as long
	// as the application needs it 
	HoroscopeDataAccess Horoscope = new HoroscopeDataAccess();

	public MainPage()
	{
		InitializeComponent();

		// Picker elements populated with List<string> of user options
		HoroscopeSign.ItemsSource = Horoscope.GetHoroscopeSign();
		TimeFrame.ItemsSource = Horoscope.GetTimeFrame();

	}


	// When the button is clicked, the user's horoscope will be outputted
	// to the HoroscopeLabel
	private async void OnHoroscopeBtnClick(object sender, EventArgs e)
	{
		try
		{
            string endpoint = Horoscope.GetEndpoint(TimeFrame.SelectedItem.ToString(), HoroscopeSign.SelectedItem.ToString());
            string horoscope = await Horoscope.GetHoroscope(endpoint);

			await HoroscopeLabel.FadeTo(0, 250, Easing.Linear);
            HoroscopeLabel.Text = horoscope;
            await HoroscopeLabel.FadeTo(1, 250, Easing.Linear);
        }

		catch (NullReferenceException)
		{
            await HoroscopeLabel.FadeTo(0, 250, Easing.Linear);
            HoroscopeLabel.Text = "You must select a {sign} and {timeframe}";
            await HoroscopeLabel.FadeTo(1, 250, Easing.Linear);
        }

		catch (Exception exception)
		{
			HoroscopeLabel.Text = $"Error: {exception}";
		}
        
    }

}


