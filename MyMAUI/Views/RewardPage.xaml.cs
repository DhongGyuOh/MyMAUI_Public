using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class RewardPage : ContentPage
{
	public RewardPage()
	{
		InitializeComponent();
		this.BindingContext = new RewardVM();
	}
}