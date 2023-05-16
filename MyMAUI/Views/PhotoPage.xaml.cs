using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class PhotoPage : ContentPage
{
	public PhotoPage()
	{
		InitializeComponent();
		this.BindingContext = new PhotoVM();
	}
}