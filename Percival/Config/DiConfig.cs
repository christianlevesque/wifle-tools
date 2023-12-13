using System;
using Percival.Views;

namespace Percival.Config;

public class DiConfig
{
	/// <summary>
	/// Whether the framework should auto-load routes from the same assembly as the <see cref="Avalonia.Application"/> type
	/// </summary>
	public bool AutoloadRoutes { get; set; } = true;

	/// <summary>
	/// Whether the framework should register view models when it registers routes from an assembly
	/// </summary>
	public bool RegisterViewModels { get; set; } = true;

	/// <summary>
	/// The view model base type used by the framework when registering view models
	/// </summary>
	public Type ViewModelType { get; set; } = typeof(IViewModel);
}