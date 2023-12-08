using FindPlacesApp.Code.Localization;

namespace FindPlacesApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			Localization.InitLocalization();

			MainPage = new MainPage();
		}
	}
}