using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Percival.Routing;

namespace WifleTools.Views;

[Route(Urls.Home)]
public partial class Home : UserControl
{
	public Home(HomeViewModel vm)
	{
		DataContext = vm;
		AvaloniaXamlLoader.Load(this);
	}
}