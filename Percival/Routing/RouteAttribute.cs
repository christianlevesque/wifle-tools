using System;

namespace Percival.Routing;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute : Attribute
{
	public string Route { get; }

	public RouteAttribute(string route)
	{
		Route = route;
	}
}