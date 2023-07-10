using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;


namespace MAUITestApp.ViewModel
{
	public class HoroscopePageViewModel : INotifyPropertyChanged
	{
        HoroscopeViewModel horoscope;
        public ICommand MyCommand { private set; get; }

        public HoroscopePageViewModel()
        {
            MyCommand = new Command(
                execute: async () =>
                {
                    horoscope = new HoroscopeViewModel();
                    string endpoint = GetEndpoint("Today", "Aries");
                    horoscope.data = await GetHoroscope(endpoint);
                    DisplayHoroscope = horoscope.data;
                });
        }

        private string HoroscopeOutput;

        public string DisplayHoroscope
        {
            
            get
            {
                return HoroscopeOutput;
            }

            set
            {
                HoroscopeOutput = value;
                OnPropertyChanged();
            }
        }

        // Send a GET request to API endpoint,
        // read the response as a stream,
        // than deserialize JSON response.
        private readonly HttpClient _client = new HttpClient();
        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions();

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

        // Method takes the sign and timeframe selected by user,
        // uses those two options as a key to return the correct
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

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}

