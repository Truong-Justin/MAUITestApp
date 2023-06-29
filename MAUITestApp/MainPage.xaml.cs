using MAUITestApp.Models;


namespace MAUITestApp;

public partial class MainPage : ContentPage
{
	Horoscope Horoscope = new Horoscope();
	int count = 0;


	public MainPage()
	{
		InitializeComponent();
	}

	// Method changes the label text when LoadHoroscopeBtn
	// is clicked;
	// This method will eventually be used to output the user's
	// horoscope to the HoroscopeLabel label
	private async void OnHoroscopeBtnClick(object sender, EventArgs e)
	{

		Label horoscopeLabel = (Label)FindByName("HoroscopeLabel");
		var horoscope = await Horoscope.GetHoroscope();
		horoscopeLabel.Text = horoscope;
    }

}


