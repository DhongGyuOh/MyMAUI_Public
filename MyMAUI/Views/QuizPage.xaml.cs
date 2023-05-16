using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class QuizPage : ContentPage
{
	public QuizPage()
	{
		InitializeComponent();
		this.BindingContext = new QuizVM();
	}
}