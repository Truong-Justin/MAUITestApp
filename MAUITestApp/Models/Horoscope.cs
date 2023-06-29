using System.Net.Http;

namespace MAUITestApp.Models
{
	public class Horoscope
	{
		// Method will take the two options selected by user to create a key
		public string MakeKey()
		{
			return "";
		}

		// Method will access a specific API endpoint and return the user's horoscope
		public async Task<string> GetHoroscope()
		{

			using (HttpClient client = new HttpClient())
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
}

