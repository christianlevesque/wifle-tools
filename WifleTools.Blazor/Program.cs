using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

		app.Run();
	}
}