using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class RewardDetailPage : ContentPage
{
	public RewardDetailPage()
	{
		InitializeComponent();
		this.BindingContext = new RewardDetailVM();
	}
}