using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Percival.Views;

public abstract class PercivalControl : UserControl
{
	public virtual Task PercivalInitialized()
		=> Task.CompletedTask;
}

public abstract class PercivalControl<TViewModel> : PercivalControl
{
	protected readonly TViewModel Vm;

	/// <inheritdoc />
	protected PercivalControl(TViewModel vm)
	{
		Vm = vm;
		DataContext = vm;
	}
}