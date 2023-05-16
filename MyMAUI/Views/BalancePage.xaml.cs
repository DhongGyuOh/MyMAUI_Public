using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class BalancePage : ContentPage
{
	public BalancePage()
	{
		InitializeComponent();
		this.BindingContext = new BalanceVM();
	}
}