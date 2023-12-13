using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace Percival.Routing;

public interface INavigationManager
{
	string CurrentRoute { get; }
	object? CurrentRouteParams { get; }
	event EventHandler<NavigationEvent>? OnNavigation; 
	Task NavigateTo(string route, object? routeParams = null);
}