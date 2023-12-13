using System.Diagnostics;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Percival.Routing;

namespace Percival.Views;

public partial class MainWindowViewModel : ObservableObject
{
	public ActiveViewProvider ActiveViewProvider { get; }

	/// <inheritdoc />
	public MainWindowViewModel(ActiveViewProvider activeViewProvider)
	{
		ActiveViewProvider = activeViewProvider;
	}

	public void HandleMainMenuSelectionChanged(
		object? sender,
		SelectionChangedEventArgs e)
	{
		var tabControl = (TabControl)e.Source!;
		var tab = (TabItem)tabControl.SelectedItem!;
		Debug.WriteLine($"-----Source: {tab.Header}");
	}
}