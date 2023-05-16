using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class YesNoPage : ContentPage
{
	public YesNoPage()
	{
		InitializeComponent();
		this.BindingContext = new YesNoVM();
	}
}