using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;


namespace MAUITestApp.ViewModel
{
	public class HoroscopePageViewModel : INotifyPropertyChanged
	{
        public ICommand GenerateFortuneCommand { private set; get; }


        // Executes horoscope data-access methods when the
        // MyCommand button is pressed and outputs fortune to user
        public HoroscopePageViewModel()
        {
            GenerateFortuneCommand = new Command(
                execute: async () =>
                {
                    try
                    {
                        HoroscopeViewModel horoscope = new HoroscopeViewModel();
                        string endpoint = GetEndpoint(SelectedHoroscopeTimeFrame, SelectedHoroscopeSign);
                        horoscope.data = await GetHoroscope(endpoint);
                        DisplayHoroscope = horoscope.data;
                    }

                    catch (KeyNotFoundException)
                    {
                        DisplayHoroscope = "A {timeframe} and {sign} must be selected";
                    }
                });
        }


        private string _selectedSign;


        // Used to store and retrieve
        // the horoscope sign chosen by user
        public string SelectedHoroscopeSign
        {
            get
            {
                return _selectedSign;
            }

            set
            {
                _selectedSign = value;
            }
        }


        private string _selectedTimeFrame;


        // Used to store and retrieve
        // the timeframe chosen by user
        public string SelectedHoroscopeTimeFrame
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


        private string _horoscopeText;


        // Used to store and retrieve horoscope
        // fortune data when an API endpoint is
        // accessed
        public string DisplayHoroscope
        {
            
            get
            {
                return _horoscopeText;
            }

            set
            {
                _horoscopeText = value;
                OnPropertyChanged();
            }
        }

    
        private readonly HttpClient _client = new HttpClient();
        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions();


        // Send a GET request to API endpoint,
        // read the response as a stream,
        // than deserialize JSON response.
        public async Task<string> GetHoroscope(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    Stream responseBody = await response.Content.ReadAsStreamAsync();
                    HoroscopeViewModel horoscopeOutput = await JsonSerializer.DeserializeAsync<HoroscopeViewModel>(responseBody, _serializerOptions);

                    return horoscopeOutput.data;
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


        // Method takes the timeframe and sign selected by user,
        // and uses those two options as a key to return the correct
        // API endpoint when the method is called.
        public string GetEndpoint(string day, string sign)
        {
            string daily = "https://horoscopeapi-v6vga.ondigitalocean.app/api/get-horoscope/daily?sign={0}&day={1}";
            string weekly = "https://horoscopeapi-v6vga.ondigitalocean.app/api/get-horoscope/weekly?sign={0}";
            string monthly = "https://horoscopeapi-v6vga.ondigitalocean.app/api/get-horoscope/monthly?sign={0}";

            Dictionary<(string, string), string> mappedEndpoints = new Dictionary<(string, string), string>()
            {
                {("Yesterday", "Aries"), String.Format(daily, sign, day)},
                {("Today", "Aries"), String.Format(daily, sign, day)},
                {("Tomorrow", "Aries"), String.Format(daily, sign, day)},
                {("Weekly", "Aries"), String.Format(weekly, sign)},
                {("Monthly", "Aries"), String.Format(monthly, sign)},

                {("Yesterday", "Taurus"), String.Format(daily, sign, day)},
                {("Today", "Taurus"), String.Format(daily, sign, day)},
                {("Tomorrow", "Taurus"), String.Format(daily, sign, day)},
                {("Weekly", "Taurus"), String.Format(weekly, sign)},
                {("Monthly", "Taurus"), String.Format(monthly, sign)},

                {("Yesterday", "Gemini"), String.Format(daily, sign, day)},
                {("Today", "Gemini"), String.Format(daily, sign, day)},
                {("Tomorrow", "Gemini"), String.Format(daily, sign, day)},
                {("Weekly", "Gemini"), String.Format(weekly, sign)},
                {("Monthly", "Gemini"), String.Format(monthly, sign)},

                {("Yesterday", "Cancer"), String.Format(daily, sign, day)},
                {("Today", "Cancer"), String.Format(daily, sign, day)},
                {("Tomorrow", "Cancer"), String.Format(daily, sign, day)},
                {("Weekly", "Cancer"), String.Format(weekly, sign)},
                {("Monthly", "Cancer"), String.Format(monthly, sign)},

                {("Yesterday", "Leo"), String.Format(daily, sign, day)},
                {("Today", "Leo"), String.Format(daily, sign, day)},
                {("Tomorrow", "Leo"), String.Format(daily, sign, day)},
                {("Weekly", "Leo"), String.Format(weekly, sign)},
                {("Monthly", "Leo"), String.Format(monthly, sign)},

                {("Yesterday", "Virgo"), String.Format(daily, sign, day)},
                {("Today", "Virgo"), String.Format(daily, sign, day)},
                {("Tomorrow", "Virgo"), String.Format(daily, sign, day)},
                {("Weekly", "Virgo"), String.Format(weekly, sign)},
                {("Monthly", "Virgo"), String.Format(monthly, sign)},

                {("Yesterday", "Libra"), String.Format(daily, sign, day)},
                {("Today", "Libra"), String.Format(daily, sign, day)},
                {("Tomorrow", "Libra"), String.Format(daily, sign, day)},
                {("Weekly", "Libra"), String.Format(weekly, sign)},
                {("Monthly", "Libra"), String.Format(monthly, sign)},

                {("Yesterday", "Scorpio"), String.Format(daily, sign, day)},
                {("Today", "Scorpio"), String.Format(daily, sign, day)},
                {("Tomorrow", "Scorpio"), String.Format(daily, sign, day)},
                {("Weekly", "Scorpio"), String.Format(weekly, sign)},
                {("Monthly", "Scorpio"), String.Format(monthly, sign)},

                {("Yesterday", "Sagittarius"), String.Format(daily, sign, day)},
                {("Today", "Sagittarius"), String.Format(daily, sign, day)},
                {("Tomorrow", "Sagittarius"), String.Format(daily, sign, day)},
                {("Weekly", "Sagittarius"), String.Format(weekly, sign)},
                {("Monthly", "Sagittarius"), String.Format(monthly, sign)},

                {("Yesterday", "Capricorn"), String.Format(daily, sign, day)},
                {("Today", "Capricorn"), String.Format(daily, sign, day)},
                {("Tomorrow", "Capricorn"), String.Format(daily, sign, day)},
                {("Weekly", "Capricorn"), String.Format(weekly, sign)},
                {("Monthly", "Capricorn"), String.Format(monthly, sign)},

                {("Yesterday", "Aquarius"), String.Format(daily, sign, day)},
                {("Today", "Aquarius"), String.Format(daily, sign, day)},
                {("Tomorrow", "Aquarius"), String.Format(daily, sign, day)},
                {("Weekly", "Aquarius"), String.Format(weekly, sign)},
                {("Monthly", "Aquarius"), String.Format(monthly, sign)},

                {("Yesterday", "Pisces"), String.Format(daily, sign, day)},
                {("Today", "Pisces"), String.Format(daily, sign, day)},
                {("Tomorrow", "Pisces"), String.Format(daily, sign, day)},
                {("Weekly", "Pisces"), String.Format(weekly, sign)},
                {("Monthly", "Pisces"), String.Format(monthly, sign)}

            };

            return mappedEndpoints[(day, sign)];
        }


        public event PropertyChangedEventHandler PropertyChanged;


        // Raises a 'PropertyChanged' event when a property value is changed,
        // which in this view-model is when the horoscopeText value is changed
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}

