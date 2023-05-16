using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class MozzaPage : ContentPage
{
	public MozzaPage()
	{
		InitializeComponent();
		this.BindingContext = new MozzaVM();
	}
}