using System;
using System.Diagnostics;
using System.IO;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using WifleTools.Infrastructure;
using WifleTools.State;

namespace WifleTools;

public static class Program
{
	public static void Main(string[] args)
	{
		Initialize();

		var builder = WebApplication.CreateBuilder(args);

		builder.WebHost.UseElectron(args);

		// Add services to the container.
		builder.Services.AddRazorPages();
		builder.Services.AddServerSideBlazor();
		builder.Services
			.AddMudServices()
			.AddDbContext<AppDbContext>()
			.AddSingleton<NavMenuState>()
			.AddTransient(typeof(IStatusLogger<>), typeof(StatusLogger<>));

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseStaticFiles();

		app.UseRouting();

		app.MapBlazorHub();
		app.MapFallbackToPage("/_Host");

		if (HybridSupport.IsElectronActive)
		{
			CreateElectronWindow();
		}

		app.Run();
	}

	private static async void CreateElectronWindow()
	{
		var screen = await Electron.Screen.GetPrimaryDisplayAsync();
		var options = new BrowserWindowOptions
		{
			Title = "Wifle Tools",
			Height = screen.Size.Height,
			Width = screen.Size.Width
		};
	
		var window = await Electron.WindowManager.CreateWindowAsync(options);
		window.OnClosed += () => Electron.App.Quit();
	}

	private static void Initialize()
	{
		var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WifleTools");
		Debug.WriteLine($"Folder is {folder}");
		if (!Directory.Exists(folder))
		{
			Directory.CreateDirectory(folder);
		}
	}
}