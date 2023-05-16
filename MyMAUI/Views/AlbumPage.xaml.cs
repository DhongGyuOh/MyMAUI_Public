using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class AlbumPage : ContentPage
{
	public AlbumPage()
	{
		InitializeComponent();
		this.BindingContext = new AlbumVM();
	}
}