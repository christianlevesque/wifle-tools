using System;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using Percival.Views;

namespace Percival.Routing;

public class NavigationManager : INavigationManager
{
	protected readonly IServiceProvider Services;
	protected readonly IRouteManager RouteManager;
	protected readonly ActiveViewProvider ActiveViewModel;
	protected IServiceScope? ServiceScope;

	public NavigationManager(
		IServiceProvider services,
		IRouteManager routeManager,
		ActiveViewProvider activeViewModel)
	{
		Services = services;
		RouteManager = routeManager;
		ActiveViewModel = activeViewModel;
	}

	public string CurrentRoute { get; private set; } = string.Empty;

	public object? CurrentRouteParams { get; private set; }

	/// <inheritdoc />
	public event EventHandler<NavigationEvent>? OnNavigation;

	/// <inheritdoc />
	public async Task NavigateTo(string route, object? routeParams = null)
	{
		CurrentRoute = route;
		CurrentRouteParams = routeParams;
		ServiceScope?.Dispose();
		ServiceScope = Services.CreateScope();
		await ActivateView(route);
		OnNavigation?.Invoke(this, new NavigationEvent { Route = route });
	}

	protected Task ActivateView(string route)
	{
		var routeType = RouteManager.GetRouteType(route);
		var view = (UserControl)ServiceScope!.ServiceProvider.GetRequiredService(routeType);
		ActiveViewModel.ActiveView = view;

		return ActiveViewModel.ActiveView is PercivalControl pc
			? pc.PercivalInitialized()
			: Task.CompletedTask;
	}
}