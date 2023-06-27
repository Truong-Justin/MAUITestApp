namespace MAUITestApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	// Method changes the label text when LoadHoroscopeBtn
	// is clicked;
	// This method will eventually be used to output the user's
	// horoscope to the HoroscopeLabel label
	private void OnHoroscopeBtnClick(object sender, EventArgs e)
	{

		Label horoscopeLabel = (Label)FindByName("HoroscopeLabel");
		horoscopeLabel.Text = "The label text has been changed";
    }

}


