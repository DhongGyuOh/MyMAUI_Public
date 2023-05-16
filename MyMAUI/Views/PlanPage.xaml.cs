using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class PlanPage : ContentPage
{
	public PlanPage()
	{
		InitializeComponent();
		this.BindingContext = new PlanVM();
	}

}