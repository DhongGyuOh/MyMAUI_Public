using MyMAUI.ViewModels;
namespace MyMAUI.Views;

public partial class MozzaDetailPage : ContentPage
{
	public MozzaDetailPage()
	{
        
        InitializeComponent();
        this.BindingContext = new MozzaDetailVM();
        
	}

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        if(sender.GetType().GUID != null)
        {
            this.MozzaDetailPg.SendBackButtonPressed();
        }
        
    }

    //protected override void OnDisappearing()
    //{
    //    App.Current.MainPage.DisplayAlert("NavigatingFrom", "sender.GetType().Name = ", "OK");

    //}

    //private async void ContentPage_NavigatingFrom(object sender, NavigatingFromEventArgs e)
    //{

    //    //Event가 선언된 Page에서 다른 Page로 클릭 시, 넘어가기 전에 발동
    //    //다음 전환 화면이 MozzaPage가 아니라면 BackButtonPressed()를 줘야함
    //    //await App.Current.MainPage.DisplayAlert("NavigatingFrom", "sender.GetType().Name = " + sender.GetType().Name, "OK");

    //}

    //private async void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    //{
    //    //Event가 선언된 Page에서 다른 Page로 클릭 시, 넘어간 다음에 발동

    //}

    //private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    //{
    //    //Event가 선언된 Page로 넘어갈 때 발동
    //}

}