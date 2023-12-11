using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace WifleTools;

public class App : Application
{
	private IServiceProvider _services;

	/// <inheritdoc />
	public App(IServiceProvider services)
	{
		_services = services;
	}

	public override void OnFrameworkInitializationCompleted()
	{
		if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
		{
			desktop.MainWindow = _services.GetRequiredService<MainWindow>();
		}

		base.OnFrameworkInitializationCompleted();
	}

	public override void Initialize()
	{
		AvaloniaXamlLoader.Load(this);
	}
}