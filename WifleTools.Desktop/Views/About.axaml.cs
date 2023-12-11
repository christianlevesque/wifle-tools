using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaDi.Routing;

namespace WifleTools.Views;

[Route(Urls.About)]
public partial class About : UserControl
{
	public About(AboutViewModel vm)
	{
		DataContext = vm;
		InitializeComponent();
	}
}