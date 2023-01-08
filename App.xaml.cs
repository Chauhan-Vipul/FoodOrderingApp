using FoodOrderingApp.View;
namespace FoodOrderingApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();

		MainPage = new NavigationPage(new SignUpView());

		//MainPage = new NavigationPage(new SignInView());
	}
}

