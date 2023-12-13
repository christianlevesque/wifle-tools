using System;

namespace Percival.Routing;

public class NavigationEvent : EventArgs
{
	public required string Route { get; set; }
}