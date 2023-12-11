using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using QuestPDF.Infrastructure;
using WifleTools.Data;
using WifleTools.Extensions;
using WifleTools.Files;
using WifleTools.Infrastructure;
using WifleTools.Pdf;
using WifleTools.State;

namespace WifleTools;

public static class Program
{
	public static async Task Main(string[] args)
	{
		QuestPDF.Settings.License = LicenseType.Community;

		var fileWriter = new FileWriter();
		Initialize(fileWriter);

		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddRazorPages();
		builder.Services.AddServerSideBlazor();

		builder.Services
			.AddMudServices()
			.AddDbContext<AppDbContext>(
				o => o.UseWifleDb(fileWriter),
				ServiceLifetime.Transient)
			.AddSingleton<LayoutState>()
			.AddTransient(typeof(ICrudService<>), typeof(CrudService<>))
			.AddTransient<InvoicePdfGenerator>()
			.AddTransient(typeof(IStatusLogger<>), typeof(StatusLogger<>))
			.AddSingleton<IFileWriter>(fileWriter);

		var app = builder.Build();

		await MigrateDb(app.Services, fileWriter);

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
		}

		app.UseStaticFiles();

		app.UseRouting();

		app.MapBlazorHub();
		app.MapFallbackToPage("/_Host");

		await app.RunAsync();
	}

	private static void Initialize(IFileWriter fileWriter)
	{
		Debug.WriteLine($"Folder is {fileWriter.BaseDirectory}");
		if (!Directory.Exists(fileWriter.BaseDirectory))
		{
			Directory.CreateDirectory(fileWriter.BaseDirectory);
		}
	}
}