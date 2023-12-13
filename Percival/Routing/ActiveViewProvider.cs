using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Percival.Routing;

public partial class ActiveViewProvider : ObservableObject
{
	[ObservableProperty]
	private Control? _activeView;
}