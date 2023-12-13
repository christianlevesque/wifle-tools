using Avalonia;
using System;
using Percival;
using WifleTools.Data;
using WifleTools.Views;
using Microsoft.Extensions.DependencyInjection;
using WifleTools.Extensions;
using WifleTools.Infrastructure;
using WifleTools.Tools;

namespace WifleTools;

public static class Program
{
	private static IServiceProvider ServiceProvider = default!;

    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
	[STAThread]
	public static void Main(string[] args)
	{
		var app = BuildAvaloniaApp();

		ServiceProvider.MigrateDb();

		app.StartWithClassicDesktopLifetime(args);
	}

    // Avalonia configuration, don't remove; also used by visual designer.
	public static AppBuilder BuildAvaloniaApp()
	{
		StartupUtils.EnsureAppdataDirectoryExists();
 
		var builder =  PercivalBuilder.Create()
			.AddApp<App>()
			.AddMainWindow<MainWindow, CustomMainWindowViewModel>();
 
		builder.Services
			.AddDbContext<AppDbContext>(o => o.UseWifleDb())
			.AddScoped(typeof(ICrudService<>), typeof(CrudService<>))
			.AddScoped(typeof(IStatusLogger<>), typeof(StatusLogger<>));
 
		// Percival builds the service container here,
		// but returns the Avalonia app builder
		// So we need to hang onto this for now
		var app = builder
			.Build();

		ServiceProvider = builder.ServiceProvider!;
		
		return app
			.UsePlatformDetect()
			.LogToTrace();
	}
}
