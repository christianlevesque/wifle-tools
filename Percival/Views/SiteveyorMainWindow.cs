﻿using Avalonia.Controls;

namespace Percival.Views;

public class SiteveyorMainWindow<TViewModel> : Window
	where TViewModel : MainWindowViewModel
{
	public SiteveyorMainWindow(TViewModel viewModel)
	{
		DataContext = viewModel;
	}
}

public class SiteveyorMainWindow : SiteveyorMainWindow<MainWindowViewModel>
{
	/// <inheritdoc />
	public SiteveyorMainWindow(MainWindowViewModel viewModel) : base(viewModel) {}
}