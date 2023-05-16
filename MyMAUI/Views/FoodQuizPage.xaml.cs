using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class FoodQuizPage : ContentPage
{
	public FoodQuizPage()
	{
		InitializeComponent();
		this.BindingContext = new FoodQuizVM();
	}

}