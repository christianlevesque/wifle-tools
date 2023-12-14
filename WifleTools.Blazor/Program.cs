using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using QuestPDF.Infrastructure;
using WifleTools.Data;
using WifleTools.Extensions;
using WifleTools.Infrastructure;
using WifleTools.Pdf;
using WifleTools.State;
using WifleTools.Tools;

namespace WifleTools;

public static class Program
{
	public static void Main(string[] args)
	{
		QuestPDF.Settings.License = LicenseType.Community;

		StartupUtils.EnsureAppdataDirectoryExists();

		var builder = WebApplication.CreateBuilder(args);

		builder.WebHost.UseElectron(args);

		// Add services to the container.
		builder.Services.AddRazorPages();
		builder.Services.AddServerSideBlazor();

		builder.Services
			.AddMudServices()
			.AddDbContext<AppDbContext>(
				o => o.UseWifleDb(),
				ServiceLifetime.Transient)
			.AddSingleton<LayoutState>()
			.AddTransient(typeof(ICrudService<>), typeof(CrudService<>))
			.AddTransient<InvoicePdfGenerator>()
			.AddTransient(typeof(IStatusLogger<>), typeof(StatusLogger<>));

		var app = builder.Build();

		app.Services.MigrateDb();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
		}

		app.UseStaticFiles();

		app.UseRouting();

		app.MapBlazorHub();
		app.MapFallbackToPage("/_Host");

		var logger = app.Services.GetRequiredService<ILogger<CrudService<Invoice>>>();
		logger.LogInformation("Logger created");
		if (HybridSupport.IsElectronActive)
		{
			logger.LogInformation("Electron active");
			CreateElectronWindow(logger);
		}

		app.Run();
	}

	private static async void CreateElectronWindow(ILogger<CrudService<Invoice>> logger)
	{
		logger.LogInformation("Attempting to fetch primary display");
		var screen = await Electron.Screen.GetPrimaryDisplayAsync();
		logger.LogInformation("Primary display retrieved");
		var options = new BrowserWindowOptions
		{
			Title = "Wifle Tools",
			Height = screen.Size.Height,
			Width = screen.Size.Width
		};

		logger.LogInformation("Attempting to create Electron window");
		var window = await Electron.WindowManager.CreateWindowAsync(options);
		logger.LogInformation("Electron window created");
		window.OnClosed += () => Electron.App.Quit();
		logger.LogInformation("CreateElectronWindow() returning");
	}
}