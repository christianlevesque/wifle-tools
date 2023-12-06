using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WifleTools.Shared.Buttons;

public partial class LoadingButton
{
	[Parameter]
	public bool IsLoading { get; set; }

	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	[Parameter]
	public Size Size { get; set; } = Size.Small;

	[Parameter]
	public EventCallback OnClick { get; set; }
}