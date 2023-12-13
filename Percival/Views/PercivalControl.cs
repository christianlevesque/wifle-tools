using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Percival.Views;

public abstract class PercivalControl : UserControl
{
	protected PercivalControl() {}

	public virtual Task PercivalInitialized()
		=> Task.CompletedTask;
}

public abstract class PercivalControl<TViewModel> : PercivalControl
{
	protected TViewModel Vm;

	// Only use this constructor to enable the XAML previewer
	protected PercivalControl()
	{
		Vm = default!;
	}

	/// <inheritdoc />
	protected PercivalControl(TViewModel vm)
	{
		Vm = vm;
		DataContext = vm;
	}
}