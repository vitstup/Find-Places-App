namespace FindPlacesApp.Code
{
	public class AlertDisplayer
	{
		public static async Task DisplayError(string alert)
		{
			await App.Current.MainPage.DisplayAlert("Error", alert, "Ok");
		}
	}
}