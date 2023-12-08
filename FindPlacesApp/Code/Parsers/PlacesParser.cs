using FindPlacesApp.Code.Models;
using Newtonsoft.Json;

namespace FindPlacesApp.Code.Parsers
{
	public class PlacesParser
	{
		private class Icon
		{
			public string prefix { get; set; }
			public string suffix { get; set; }
		}

		private class Category
		{
			public int id { get; set; }
			public string name { get; set; }
			public string short_name { get; set; }
			public string plural_name { get; set; }
			public Icon icon { get; set; }
		}

		private class Geocodes
		{
			public Main main { get; set; }
			public Roof roof { get; set; }
		}

		private class Main
		{
			public double latitude { get; set; }
			public double longitude { get; set; }
		}

		private class Roof
		{
			public double latitude { get; set; }
			public double longitude { get; set; }
		}

		private class Location
		{
			public string address { get; set; }
			public string census_block { get; set; }
			public string country { get; set; }
			public string cross_street { get; set; }
			public string dma { get; set; }
			public string formatted_address { get; set; }
			public string locality { get; set; }
			public string postcode { get; set; }
			public string region { get; set; }
		}

		private class Chains
		{
			public string id { get; set; }
			public string name { get; set; }
		}

		private class RelatedPlaces
		{
			public Parent parent { get; set; }
		}

		private class Parent
		{
			public string fsq_id { get; set; }
			public List<Category> categories { get; set; }
			public string name { get; set; }
		}

		private class Result
		{
			public string fsq_id { get; set; }
			public List<Category> categories { get; set; }
			public List<Chains> chains { get; set; }
			public string closed_bucket { get; set; }
			public int distance { get; set; }
			public Geocodes geocodes { get; set; }
			public string link { get; set; }
			public Location location { get; set; }
			public string name { get; set; }
			public RelatedPlaces related_places { get; set; }
			public string timezone { get; set; }
		}

		private class GeoBounds
		{
			public Circle circle { get; set; }
		}

		private class Circle
		{
			public Center center { get; set; }
			public int radius { get; set; }
		}

		private class Center
		{
			public double latitude { get; set; }
			public double longitude { get; set; }
		}

		private class Root
		{
			public List<Result> results { get; set; }
			public Context context { get; set; }
		}

		private class Context
		{
			public GeoBounds geo_bounds { get; set; }
		}

		private Root GetData(string jsonString)
		{
			try
			{
				Root root = JsonConvert.DeserializeObject<Root>(jsonString);
				return root;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception while parsing JSON: " + ex.Message);
				return null;
			}
		}

		public Place[] GetPlaces(string jsonString)
		{
			var results = GetData(jsonString).results;

			if (results == null || results.Count == 0) return null;

			Place[] places = new Place[results.Count];

			for (int i = 0; i < places.Length; i++)
			{
				places[i] = new Place() {
					fsq_id = results[i].fsq_id,
					placeName = results[i].name,
					categoryName = results[i].categories[0]?.name,
					categoryIcon = $"{results[i].categories[0]?.icon.prefix}120{results[i].categories[0]?.icon.suffix}",
					currentDistance = results[i].distance,
					adress = results[i].location.address,
					city = results[i].location.locality,
					latitude = results[i].geocodes.main.latitude,
					longitude = results[i].geocodes.main.longitude,
				};
			}

			return places;
		}
	}
}