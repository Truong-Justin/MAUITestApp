using System.Net.Http;
using System.Text.Json;

namespace MAUITestApp.Models
{
	public class HoroscopeDataAccess
	{
        readonly HttpClient _client = new HttpClient();
        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions();

        // Method is used to populate a <picker> tag
        // with a collection containing the different
        // zodiac signs avaiable to the user to pick from
		public List<string> GetHoroscopeSign()
		{
            List<string> horoscopeList = new List<string>()
        {
            "Aries",
            "Taurus",
            "Gemini",
            "Cancer",
            "Leo",
            "Virgo",
            "Libra",
            "Scorpio",
            "Sagittarius",
            "Capricorn",
            "Aquarius",
            "Pisces"
        };

			return horoscopeList;
        }

        // Method is used to populate the <picker> tag
        // with a collection containing the different time-frames
        // available to the user to pick from
		public List<string> GetTimeFrame()
		{
			List<string> timeFrameList = new List<string>()
			{
				"Yesterday",
				"Today",
				"Tomorrow",
				"Weekly",
				"Monthly"
			};

			return timeFrameList;
		}

		// Method takes a URI endpoint as an argument and uses
		// it to call the API endpoint to return to the user their horoscope
		public async Task<string> GetHoroscope(string endpoint)
		{
            
			try
			{
				HttpResponseMessage response = await _client.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
                    Stream responseBody = await response.Content.ReadAsStreamAsync();
                    Horoscope horoscopeOutput = await JsonSerializer.DeserializeAsync<Horoscope>(responseBody, _serializerOptions);

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



        // Method will take the two options selected by user,
        // use those two options as a key, use that key to
        // return the correct API endpoint when the method is called
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


    }
}

