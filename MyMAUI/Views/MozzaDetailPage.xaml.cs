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

    //    //Event�� ����� Page���� �ٸ� Page�� Ŭ�� ��, �Ѿ�� ���� �ߵ�
    //    //���� ��ȯ ȭ���� MozzaPage�� �ƴ϶�� BackButtonPressed()�� �����
    //    //await App.Current.MainPage.DisplayAlert("NavigatingFrom", "sender.GetType().Name = " + sender.GetType().Name, "OK");

    //}

    //private async void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    //{
    //    //Event�� ����� Page���� �ٸ� Page�� Ŭ�� ��, �Ѿ ������ �ߵ�

    //}

    //private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    //{
    //    //Event�� ����� Page�� �Ѿ �� �ߵ�
    //}

}