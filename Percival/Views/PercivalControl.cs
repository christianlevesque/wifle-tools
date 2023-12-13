using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Percival.Views;

public abstract class PercivalControl : UserControl
{
	public virtual Task PercivalInitialized() => Task.CompletedTask;
}