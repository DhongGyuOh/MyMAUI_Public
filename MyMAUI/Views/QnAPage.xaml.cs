using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class QnAPage : ContentPage
{
	public QnAPage()
	{
		InitializeComponent();
		this.BindingContext = new QnAVM();
	}
}