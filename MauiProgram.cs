using CommunityToolkit.Maui;
using MAUITest.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace MAUITest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Material-Design-Icons.ttf", "MaterialDesignIcons");
            })
            .ConfigureServices();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}


}

