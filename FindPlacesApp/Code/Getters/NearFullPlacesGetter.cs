using FindPlacesApp.Code.Models;
using FindPlacesApp.Code.ApiRequests;
using FindPlacesApp.Code.Parsers;

namespace FindPlacesApp.Code.Getters
{
	public class NearFullPlacesGetter
	{
		public async Task<FullPlace[]> GetNearPlaces(double latitude, double longitude, int radius, int maxPhotos, int maxTips)
		{
			try
			{
				FullPlace[] places = null;

				SearchPlacesRequest placesRequest = new SearchPlacesRequest();
				PlacesParser placesParser = new PlacesParser();

				var placesResult = await placesRequest.GetPlaces(latitude, longitude, radius);
				var gettedPlaces = placesParser.GetPlaces(placesResult);

				if (gettedPlaces == null || gettedPlaces.Length == 0) return null;

				places = new FullPlace[gettedPlaces.Length];

				for (int i = 0; i < places.Length; i++)
				{
					var selectedPlace = gettedPlaces[i];

					var fullPlace = new FullPlace() { place = selectedPlace };

					PhotosRequest photosRequest = new PhotosRequest();
					PhotosParser photosParser = new PhotosParser();

					TipsRequest tipsRequest = new TipsRequest();
					TipsParser tipsParser = new TipsParser();

					var photosResult = await photosRequest.GetPhotos(selectedPlace.fsq_id, maxPhotos);
					var gettedPhotos = photosParser.GetPhotos(photosResult);

					if (gettedPhotos != null && gettedPhotos.Length > 0)
					{
						PhotoGetter photoGetter = new PhotoGetter();
						string[] photos = new string[gettedPhotos.GetLength(0)];
						for(int p = 0; p < photos.Length; p++)
						{
							photos[p] = photoGetter.GetPhoto(gettedPhotos[p, 0], gettedPhotos[p, 1], 920, 420);
						}
						fullPlace.photos = photos;
					}

					var tipsResult = await tipsRequest.GetTips(selectedPlace.fsq_id, maxTips);
					var gettedTips = tipsParser.GetTips(tipsResult);

					fullPlace.tips = gettedTips;

					places[i] = fullPlace;
				}

				return places;
			}
			catch (Exception e)
			{
				await AlertDisplayer.DisplayError($"Exception: {e}");
			}
			return null;
		}
	}
}
