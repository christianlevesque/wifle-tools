using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaDi.Routing;

namespace WifleTools.Views;

[Route(Urls.Other)]
public partial class SomeRoute : UserControl
{
	public SomeRoute()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		AvaloniaXamlLoader.Load(this);
	}
}