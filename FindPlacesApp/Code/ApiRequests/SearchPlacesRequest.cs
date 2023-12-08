namespace FindPlacesApp.Code.ApiRequests
{
	public class SearchPlacesRequest
	{
		public async Task<string> GetPlaces(double latitude, double longitude, int radius)
		{
			try
			{
				string formattedLatitude = latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
				string formattedLongitude = longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

				var client = new HttpClient();
				var request = new HttpRequestMessage()
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://api.foursquare.com/v3/places/search?ll={formattedLatitude}%2C{formattedLongitude}&radius={radius}"),
					Headers =
					{
						{ "accept", "application/json" },
					}
				};

				client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", Constants.apiKey);

				var response = await client.SendAsync(request);	

				response.EnsureSuccessStatusCode();

				var contentString = await response.Content.ReadAsStringAsync();

				return contentString;

			}
			catch (Exception ex)
			{
				await AlertDisplayer.DisplayError($"Exception: {ex}");
			}
			return string.Empty;
		}
	}
}