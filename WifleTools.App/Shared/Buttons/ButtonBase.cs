using MudBlazor;

namespace WifleTools.Shared.Buttons;

public abstract class ButtonBase : MudButton
{
	protected ButtonBase()
	{
		ButtonType = ButtonType.Button;
		Variant = Variant.Filled;
	}
}