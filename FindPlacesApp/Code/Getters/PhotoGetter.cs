namespace FindPlacesApp.Code.Getters
{
	public class PhotoGetter
	{
		public string GetPhoto(string prefix, string suffix)
		{
			return GetPhoto(prefix, suffix, "original");
		}

		public string GetPhoto(string prefix, string suffix, int width, int height)
		{
			return GetPhoto(prefix, suffix, $"{width}x{height}");
		}

		private string GetPhoto(string prefix, string suffix, string size)
		{
			return prefix + size + suffix;
		}
	}
}