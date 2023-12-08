namespace FindPlacesApp.Code.Getters
{
	public class LocationGetter
	{
		private DateTime lastTimeLocationChecked;

		public async Task<Location> GetLocation()
		{
			try
			{
				TimeSpan span = DateTime.Now - lastTimeLocationChecked;
				if (span.TotalSeconds > 0 && span.TotalSeconds <= 60)
				{
					return await Geolocation.Default.GetLastKnownLocationAsync();
				}

				PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

				if (status != PermissionStatus.Granted)
				{
					status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
				}

				GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));

				var location = await Geolocation.Default.GetLocationAsync(request);

				lastTimeLocationChecked = DateTime.Now;

				return location;
			}
			catch (Exception ex)
			{
				await AlertDisplayer.DisplayError($"Exception: {ex}");
			}
			return null;
		}
	}
}