namespace FindPlacesApp.Code.Models
{
	public class Place
	{
		public string fsq_id { get; set; }
		public string placeName { get; set; }
		public string categoryName { get; set; }
		public string categoryIcon { get; set; }
		public int currentDistance { get; set; }
		public string adress { get; set; }
		public string city { get; set; }
		public double latitude { get; set; }
		public double longitude { get; set; }
	}
}