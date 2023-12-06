using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace WifleTools.Shared.Buttons;

public partial class ToggleButton
{
	[Parameter]
	public bool Active { get; set; }

	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	[Parameter]
	public EventCallback<MouseEventArgs> OnClick { get; set; }

	[Parameter]
	public string? Class { get; set; }

	private string Classes => $"d-flex justify-space-between {Class}";
}