using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TaskManagerX.Infra.Data.Repositories;
using TaskManagerX.ViewModels;
using TaskManagerX.Views;

namespace TaskManagerX;

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
			});

        builder.Services.AddSingleton<ITodoItemRepository, TodoItemRepository>();
        builder.Services.AddScoped<MainView>();
        builder.Services.AddScoped<TodoItemsViewModel>();
        builder.Services.AddTransient<RegisterItemView>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<ITodoItemRepository, TodoItemRepository>();
        mauiAppBuilder.Services.AddScoped<TodoItemsViewModel>();
		return mauiAppBuilder;
	}
}
