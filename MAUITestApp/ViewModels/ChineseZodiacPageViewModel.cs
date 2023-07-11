using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;

namespace MAUITestApp.ViewModels
{
	public class ChineseZodiacPageViewModel : INotifyPropertyChanged
	{
		
		public ICommand GenerateFortuneCommand { private set; get; }


        // Executes chinese zodiac data-access methods when the
        // GenerateFortuneCommand button is pressed and outputs fortune to user
		public ChineseZodiacPageViewModel()
		{
			GenerateFortuneCommand = new Command(
				execute: async () =>
				{
					try
					{
						ChineseZodiacViewModel chineseZodiac = new ChineseZodiacViewModel();
                        string endpoint = GetEndpoint(SelectedTimeFrame, SelectedZodiacAnimal);
						chineseZodiac.data = await GetChineseZodiac(endpoint);
						DisplayChineseZodiac = chineseZodiac.data;
					}

					catch (KeyNotFoundException)
					{
                        DisplayChineseZodiac = "A {timeframe} and {animal} must be selected";
					}
				});
		}


		private string _selectedZodiac;


        // Used to store and retrieve
        // the zodiac animal chosen by user
		public string SelectedZodiacAnimal
		{
			get
			{
				return _selectedZodiac;
			}

			set
			{
				_selectedZodiac = value;
			}
		}


		private string _selectedTimeFrame;


        // Used to store and retrieve
        // the timeframe chosen by user
		public string SelectedTimeFrame
		{
			get
			{
				return _selectedTimeFrame;
			}

			set
			{
				_selectedTimeFrame = value;
			}
		}


        private string _chineseZodiacText;


        // Used to store and retrieve zodiac
        // fortune data when an API endpoint is
        // accessed
        public string DisplayChineseZodiac
        {
            get
            {
                return _chineseZodiacText;
            }

            set
            {
                _chineseZodiacText = value;
                OnPropertyChanged();
            }
        }


		private readonly HttpClient _client = new HttpClient();
		private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions();


		public async Task<string> GetChineseZodiac(string endpoint)
		{
			try
			{
				HttpResponseMessage response = await _client.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
					Stream responseBody = await response.Content.ReadAsStreamAsync();
					ChineseZodiacViewModel chineseZodiacOutput = await JsonSerializer.DeserializeAsync<ChineseZodiacViewModel>(responseBody, _serializerOptions);

					return chineseZodiacOutput.data;
				}

				else
				{
					return $"Error, API status code: {response.StatusCode}";
				}
			}

			catch (Exception exception)
			{
				return exception.ToString();
			}
		}


        // Method take the timeframe and animal selected by user,
        // and uses those two options as a key to return the correct
        // API endpoint when the method is called
        public string GetEndpoint(string day, string animal)
        {
            string daily = "https://horoscopeapi-v6vga.ondigitalocean.app/api/get-chineseHoroscope/daily?animal={0}&day={1}";
            string weekly = "https://horoscopeapi-v6vga.ondigitalocean.app/api/get-chineseHoroscope/weekly?animal={0}";
            string monthly = "https://horoscopeapi-v6vga.ondigitalocean.app/api/get-chineseHoroscope/monthly?animal={0}";

            Dictionary<(string, string), string> mappedEndpoints = new Dictionary<(string, string), string>()
            {
                {("Yesterday", "Rat"), String.Format(daily, animal, day)},
                {("Today", "Rat"), String.Format(daily, animal, day)},
                {("Tomorrow", "Rat"), String.Format(daily, animal, day)},
                {("Weekly", "Rat"), String.Format(weekly, animal)},
                {("Monthly", "Rat"), String.Format(monthly, animal)},

                {("Yesterday", "Ox"), String.Format(daily, animal, day)},
                {("Today", "Ox"), String.Format(daily, animal, day)},
                {("Tomorrow", "Ox"), String.Format(daily, animal, day)},
                {("Weekly", "Ox"), String.Format(weekly, animal)},
                {("Monthly", "Ox"), String.Format(monthly, animal)},

                {("Yesterday", "Tiger"), String.Format(daily, animal, day)},
                {("Today", "Tiger"), String.Format(daily, animal, day)},
                {("Tomorrow", "Tiger"), String.Format(daily, animal, day)},
                {("Weekly", "Tiger"), String.Format(weekly, animal)},
                {("Monthly", "Tiger"), String.Format(monthly, animal)},

                {("Yesterday", "Rabbit"), String.Format(daily, animal, day)},
                {("Today", "Rabbit"), String.Format(daily, animal, day)},
                {("Tomorrow", "Rabbit"), String.Format(daily, animal, day)},
                {("Weekly", "Rabbit"), String.Format(weekly, animal)},
                {("Monthly", "Rabbit"), String.Format(monthly, animal)},

                {("Yesterday", "Dragon"), String.Format(daily, animal, day)},
                {("Today", "Dragon"), String.Format(daily, animal, day)},
                {("Tomorrow", "Dragon"), String.Format(daily, animal, day)},
                {("Weekly", "Dragon"), String.Format(weekly, animal)},
                {("Monthly", "Dragon"), String.Format(monthly, animal)},

                {("Yesterday", "Snake"), String.Format(daily, animal, day)},
                {("Today", "Snake"), String.Format(daily, animal, day)},
                {("Tomorrow", "Snake"), String.Format(daily, animal, day)},
                {("Weekly", "Snake"), String.Format(weekly, animal)},
                {("Monthly", "Snake"), String.Format(monthly, animal)},

                {("Yesterday", "Horse"), String.Format(daily, animal, day)},
                {("Today", "Horse"), String.Format(daily, animal, day)},
                {("Tomorrow", "Horse"), String.Format(daily, animal, day)},
                {("Weekly", "Horse"), String.Format(weekly, animal)},
                {("Monthly", "Horse"), String.Format(monthly, animal)},

                {("Yesterday", "Sheep"), String.Format(daily, animal, day)},
                {("Today", "Sheep"), String.Format(daily, animal, day)},
                {("Tomorrow", "Sheep"), String.Format(daily, animal, day)},
                {("Weekly", "Sheep"), String.Format(weekly, animal)},
                {("Monthly", "Sheep"), String.Format(monthly, animal)},

                {("Yesterday", "Monkey"), String.Format(daily, animal, day)},
                {("Today", "Monkey"), String.Format(daily, animal, day)},
                {("Tomorrow", "Monkey"), String.Format(daily, animal, day)},
                {("Weekly", "Monkey"), String.Format(weekly, animal)},
                {("Monthly", "Monkey"), String.Format(monthly, animal)},

                {("Yesterday", "Rooster"), String.Format(daily, animal, day)},
                {("Today", "Rooster"), String.Format(daily, animal, day)},
                {("Tomorrow", "Rooster"), String.Format(daily, animal, day)},
                {("Weekly", "Rooster"), String.Format(weekly, animal)},
                {("Monthly", "Rooster"), String.Format(monthly, animal)},

                {("Yesterday", "Dog"), String.Format(daily, animal, day)},
                {("Today", "Dog"), String.Format(daily, animal, day)},
                {("Tomorrow", "Dog"), String.Format(daily, animal, day)},
                {("Weekly", "Dog"), String.Format(weekly, animal)},
                {("Monthly", "Dog"), String.Format(monthly, animal)},

                {("Yesterday", "Pig"), String.Format(daily, animal, day)},
                {("Today", "Pig"), String.Format(daily, animal, day)},
                {("Tomorrow", "Pig"), String.Format(daily, animal, day)},
                {("Weekly", "Pig"), String.Format(weekly, animal)},
                {("Monthly", "Pig"), String.Format(monthly, animal)},

            };

            return mappedEndpoints[(day, animal)];
        }


        public event PropertyChangedEventHandler PropertyChanged;


        // Raises a 'PropertyChanged' event when a property value is changed,
        // which in this view-model is when the DisplayChineseZodiac value is changed
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

