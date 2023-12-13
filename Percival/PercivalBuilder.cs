using System;
using System.Linq;
using System.Reflection;
using Avalonia;
using Percival.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Percival.Routing;
using Percival.Views;

namespace Percival;

public class PercivalBuilder
{
	protected bool AppRegistered;
	protected bool WindowRegistered;
	protected Type? AppType;
	protected DiConfig Config;

	public IServiceCollection Services { get; }

	public IServiceProvider? ServiceProvider { get; private set; }

	public IRouteManager RouteManager { get; }

	protected PercivalBuilder() : this(new()) {}

	protected PercivalBuilder(DiConfig config)
	{
		Config = config;
		Services = new ServiceCollection();
		RouteManager = new RouteManager();
	}

	public static PercivalBuilder Create()
		=> new();

	public static PercivalBuilder Create(DiConfig config)
		=> new(config);

	public static PercivalBuilder Create(Action<DiConfig> configurer)
	{
		var config = new DiConfig();
		configurer(config);
		return new(config);
	}

	public AppBuilder Build()
	{
		if (!WindowRegistered)
		{
			throw new InvalidOperationException($"You must register your Main Window instance using the {nameof(AddMainWindow)} method");
		}

		if (!AppRegistered)
		{
			throw new InvalidOperationException($"You must register your Application instance using the {nameof(AddApp)} method");
		}

		AddServices();

		if (Config.AutoloadRoutes)
		{
			RegisterRoutesFromAssembly(AppType!.Assembly);
		}

		ServiceProvider = Services.BuildServiceProvider();
		return AppBuilder.Configure(() => (Application)ServiceProvider.GetRequiredService(AppType!));
	}

	public PercivalBuilder AddApp<TApp>()
		where TApp : Application
	{
		Services.AddSingleton<TApp>();
		AppType = typeof(TApp);
		AppRegistered = true;
		return this;
	}

	public PercivalBuilder AddMainWindow<TWindow>()
		where TWindow : SiteveyorMainWindow<MainWindowViewModel>
		=> AddMainWindow<TWindow, MainWindowViewModel>();

	public PercivalBuilder AddMainWindow<TWindow, TViewModel>()
		where TWindow : SiteveyorMainWindow<TViewModel>
		where TViewModel : MainWindowViewModel
	{
		Services.AddSingleton<TWindow>();

		Services.AddSingleton<TViewModel>();
		if (typeof(TViewModel) != typeof(MainWindowViewModel))
		{
			Services.AddSingleton<MainWindowViewModel>(sp => sp.GetRequiredService<TViewModel>());
		}

		WindowRegistered = true;

		return this;
	}

	protected void AddServices()
	{
		Services.TryAddSingleton<INavigationManager, NavigationManager>();
		Services.AddSingleton(RouteManager);

		Services.AddSingleton<ActiveViewProvider>();
	}

	public PercivalBuilder RegisterRoutesFromAssembly(Assembly targetAssembly)
	{
		var types = targetAssembly.GetExportedTypes();

		var routableViews = types.Where(t => t.IsDefined(typeof(RouteAttribute)));
		foreach (var view in routableViews)
		{
			var attribute = (Attribute.GetCustomAttribute(view, typeof(RouteAttribute)) as RouteAttribute)!;
			RouteManager.AddRoute(attribute.Route, view);
			Services.AddScoped(view);
		}

		var viewModels = types.Where(
			t => t.IsAssignableTo(Config.ViewModelType) && t != Config.ViewModelType);
		foreach (var viewModel in viewModels)
		{
			Services.AddScoped(viewModel);
		}

		return this;
	}
}