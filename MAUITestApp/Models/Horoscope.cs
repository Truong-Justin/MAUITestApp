using System.Net.Http;

namespace MAUITestApp.Models
{
	public class Horoscope
	{
		readonly HttpClient client = new HttpClient();

		// Method will take the two options selected by user and return the correct API endpoint
		public string MakeKey(string sign, string timeFrame)
		{
			Dictionary<(string, string), string> mappedEndpoints = new Dictionary<(string, string), string>()
			{
				//Where (sign, timeFrame) will be mapped to correct URI endpoint
			};

			return mappedEndpoints[(sign, timeFrame)];
		}

		// Method will take URI endpoint as an argument to
		// be used to return the user's horoscope
		public async Task<string> GetHoroscope()
		{
			try
			{
				// An example API endpoint for testing
				HttpResponseMessage response = await client.GetAsync("https://horoscopeapi-v6vga.ondigitalocean.app/api/get-horoscope/monthly?sign=aries");

				// If Http response returns 200-299, return the response body
				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					return responseBody;
				}

				// If Http response != 200-299, return the response code only 
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

		
	}
}

