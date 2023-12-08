using RestSharp;

namespace FindPlacesApp.Code.ApiRequests
{
	public class TipsRequest
	{
		public async Task<string> GetTips(string placeId, int limit)
		{
			try
			{
				var options = new RestClientOptions($"https://api.foursquare.com/v3/places/{placeId}/tips");

				var client = new RestClient(options);

				var request = new RestRequest("");

				request.AddQueryParameter("limit", limit);

				request.AddHeader("accept", "application/json");

				request.AddHeader("Authorization", Constants.apiKey);

				var response = await client.GetAsync(request);

				if (!response.IsSuccessStatusCode) await AlertDisplayer.DisplayError($"Unsuccess: {response.StatusCode}");

				return response.Content;
			}
			catch(Exception ex) 
			{
				await AlertDisplayer.DisplayError($"Exception: {ex}");
			}
			return string.Empty;
		}
	}
}