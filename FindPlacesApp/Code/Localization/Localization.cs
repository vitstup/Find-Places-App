namespace FindPlacesApp.Code.Localization
{
	public static class Localization
	{
		public static int language { get; private set;}

		private static Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>()
		{
			{"distText", new string[] { "Max distance from you, in meters", "Макс дистанция от вас, в метрах" } },
			{"finded", new string[] { "Finded", "Найдено" } },
			{"interestingPlacesText", new string[] { "interesting places near you in distance of", "интересных мест рядом с вами на расстоянии" } },
			{"metrs", new string[] { "meters", "метров" } },
			{"startFinding", new string[] { "Start finding", "Начнинте поиск" } },
			{"openInMaps", new string[] { "Open in the maps", "Открыть в картах" } },
			{"buildRoute", new string[] { "Build walking route", "Посроить пеший маршрут" } },
			{"reviews", new string[] { "Reviews", "Отзывы" } },
			{"noReviews", new string[] { "It looks like theare still no reviews", "Судя по всему отзывов ещё нет" } },
			{"language", new string[] { "Language", "Язык" } },
		};

		public static string Localize(string key)
		{
			if (dictionary.TryGetValue(key, out string[] value))
			{
				return value[language];
			}
			else throw new Exception("Theare is no such key");
		}

		public static async Task ChangeLanguage(int id)
		{
			language = id;

			await SecureStorage.Default.SetAsync("language", id.ToString());

		}

		public static async Task InitLocalization()
		{
			string result = await SecureStorage.Default.GetAsync("language");
			if (string.IsNullOrWhiteSpace(result))
			{
				await SecureStorage.Default.SetAsync("language", "0");
			}
			if (int.TryParse(result, out int id))
			{
				language = id;
			}
		}
	}
}