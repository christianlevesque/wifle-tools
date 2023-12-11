using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using WifleTools.State;

namespace WifleTools.Shared;

public abstract class CustomLayoutBase : LayoutComponentBase
{
	[Inject]
	protected LayoutState LayoutState { get; set; } = default!;

	[Inject]
	private ILogger<CustomLayoutBase> Logger { get; set; } = default!;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		Logger.LogInformation("Base layout initialized");
		base.OnInitialized();
		LayoutState.Freeze();
		LayoutState.Reset();
		SetupNav();
		LayoutState.Unfreeze();
	}

	/// <summary>
	/// Performs any necessary setup of the global navigation.
	/// </summary>
	/// <remarks>
	/// <see cref="OnInitialized"/> in <see cref="CustomLayoutBase"/> calls the <see cref="StateManagerBase"/> <c>Freeze()</c> and <c>UnFreeze()</c> methods, so as long as <see cref="OnInitialized"/> is called, you don't need to call these methods manually in your implementation.
	/// </remarks>
	protected abstract void SetupNav();
}