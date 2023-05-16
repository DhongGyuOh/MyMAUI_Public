using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class PhotoDetailPage : ContentPage
{
	public PhotoDetailPage()
	{
		InitializeComponent();
		this.BindingContext = new PhotoDetailVM();
	}
}