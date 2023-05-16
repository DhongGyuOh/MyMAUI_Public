using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui.MediaElement;

namespace MyMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{

		try
		{
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });



            return builder.Build();
        }
		catch (Exception)
		{

            return null;
			throw;
		}
		
	}
}
