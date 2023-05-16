using MyMAUI.Views;
namespace MyMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(StartPage), typeof(StartPage));
        Routing.RegisterRoute(nameof(RewardPage), typeof(RewardPage));
        Routing.RegisterRoute(nameof(MozzaPage), typeof(MozzaPage));
        Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage));
        Routing.RegisterRoute(nameof(FoodQuizPage), typeof(FoodQuizPage));
        Routing.RegisterRoute(nameof(RewardDetailPage), typeof(RewardDetailPage));
        Routing.RegisterRoute(nameof(MozzaDetailPage), typeof(MozzaDetailPage));
        Routing.RegisterRoute(nameof(QnAPage), typeof(QnAPage));
        Routing.RegisterRoute(nameof(PriorityQuizPage), typeof(PriorityQuizPage));
        Routing.RegisterRoute(nameof(PhotoPage), typeof(PhotoPage));
        Routing.RegisterRoute(nameof(PhotoDetailPage), typeof(PhotoDetailPage));
        Routing.RegisterRoute(nameof(AlbumPage), typeof(AlbumPage));
        Routing.RegisterRoute(nameof(BalancePage), typeof(BalancePage));
        Routing.RegisterRoute(nameof(YesNoPage), typeof(YesNoPage));
        Routing.RegisterRoute(nameof(BlankQuizPage), typeof(BlankQuizPage));
        Routing.RegisterRoute(nameof(PlanPage),typeof(PlanPage));
        Routing.RegisterRoute(nameof(VideoPage), typeof(VideoPage));
    }

    
}
