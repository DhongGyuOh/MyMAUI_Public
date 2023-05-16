using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class PriorityQuizPage : ContentPage
{
	public PriorityQuizPage()
	{
		InitializeComponent();
		this.BindingContext = new PriorityQuizVM();
	}
}