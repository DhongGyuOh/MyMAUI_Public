using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class BlankQuizPage : ContentPage
{
	public BlankQuizPage()
	{
		InitializeComponent();
		this.BindingContext = new BlankVM();
	}
}