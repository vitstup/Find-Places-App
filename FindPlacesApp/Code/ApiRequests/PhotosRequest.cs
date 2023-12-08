using RestSharp;

namespace FindPlacesApp.Code.ApiRequests
{
	public class PhotosRequest
	{
		public async Task<string> GetPhotos(string placeId, int limit)
		{
			try
			{
				var options = new RestClientOptions($"https://api.foursquare.com/v3/places/{placeId}/photos");

				var client = new RestClient(options);

				var request = new RestRequest("");

				request.AddHeader("accept", "application/json");

				request.AddHeader("Authorization", Constants.apiKey);

				request.AddQueryParameter("limit", limit);

				var response = await client.GetAsync(request);

				if (!response.IsSuccessStatusCode) await AlertDisplayer.DisplayError($"Unsuccess: {response.StatusCode}");

				return response.Content;
			}
			catch (Exception ex)
			{
				await AlertDisplayer.DisplayError($"Exception: {ex}");
			}
			return string.Empty;
		}
	}
}