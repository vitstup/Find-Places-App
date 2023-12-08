using Newtonsoft.Json;

namespace FindPlacesApp.Code.Parsers
{
	public class PhotosParser
	{
		private class Photo
		{
			public string id { get; set; }
			public DateTime created_at { get; set; }
			public string prefix { get; set; }
			public string suffix { get; set; }
			public int width { get; set; }
			public int height { get; set; }
			public List<string> classifications { get; set; }
		}

		private List<Photo> ParsePhotos(string jsonString)
		{
			try
			{
				List<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(jsonString);
				return photos;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception while parsing JSON: " + ex.Message);
				return null;
			}
		}

		public string[,] GetPhotos(string jsonString)
		{
			var results = ParsePhotos(jsonString);

			if (results == null || results.Count == 0) return null;

			string[,] photos = new string[results.Count, 2];

			for (int i = 0; i < results.Count; i++)
			{
				photos[i, 0] = results[i].prefix;
				photos[i, 1] = results[i].suffix;
			}

			return photos;
		}
	}
}