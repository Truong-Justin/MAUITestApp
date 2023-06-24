namespace MAUITestApp;

public partial class MainPage : ContentPage
{
	int count = 0;
	int counter = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
		{
			CounterBtn.Text = $"You clicked the button {count} times";
		}
		else
		{
			CounterBtn.Text = $"You clicked the button {count} times";
		}

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

}


