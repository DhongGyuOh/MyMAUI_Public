using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
		this.BindingContext = new StartVM();
	}
}

