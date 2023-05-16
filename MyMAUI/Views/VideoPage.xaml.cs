using MyMAUI.ViewModels;

namespace MyMAUI.Views;

public partial class VideoPage : ContentPage
{
	public VideoPage()
	{
		InitializeComponent();
		this.BindingContext = new VideoVM();
	}
}