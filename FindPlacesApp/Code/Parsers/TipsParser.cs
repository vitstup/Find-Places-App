using Newtonsoft.Json;

namespace FindPlacesApp.Code.Parsers
{
	public class TipsParser
	{
		private class Tip
		{
			public string id { get; set; }
			public DateTime created_at { get; set; }
			public string text { get; set; }
		}

		private List<Tip> ParseTips(string jsonString)
		{
			try
			{
				List<Tip> tips = JsonConvert.DeserializeObject<List<Tip>>(jsonString);
				return tips;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception while parsing JSON: " + ex.Message);
				return null;
			}
		}

		public string[] GetTips(string jsonString)
		{
			var results = ParseTips(jsonString);

			if (results == null || results.Count == 0) return null;

			string[] tips = new string[results.Count];

			for (int i = 0; i < tips.Length; i++)
			{
				tips[i] = results[i].text;
			}

			return tips;
		}
	}
}