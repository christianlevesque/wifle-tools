using Avalonia;
using System;
using AvaloniaDi;
using WifleTools.Data;
using WifleTools.Views;
using Microsoft.Extensions.DependencyInjection;
using WifleTools.Extensions;
using WifleTools.Infrastructure;
using WifleTools.Tools;

namespace WifleTools;

public static class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
	public static AppBuilder BuildAvaloniaApp()
	{
		StartupUtils.EnsureAppdataDirectoryExists();
 
		var builder =  DiAppBuilder.Create()
			.AddApp<App>()
			.AddMainWindow<MainWindow, CustomMainWindowViewModel>();
 
		builder.Services
			.AddDbContext<AppDbContext>(o => o.UseWifleDb())
			.AddScoped(typeof(ICrudService<>), typeof(CrudService<>))
			.AddScoped(typeof(IStatusLogger<>), typeof(StatusLogger<>));
 
		// AvaloniaDi builds the service container here,
		// but returns the Avalonia app builder
		// So we need to hang onto this for now
		var avaloniaBuilder = builder.Build();
 
		builder.ServiceProvider!.MigrateDb();
 
		return avaloniaBuilder
			.UsePlatformDetect()
			.LogToTrace();
	}
}
