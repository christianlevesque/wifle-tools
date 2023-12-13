using Percival.Routing;
using Percival.Views;

namespace WifleTools.Views;

[Route(Urls.About)]
public partial class About : PercivalControl<AboutViewModel>
{
	public About(AboutViewModel vm) : base(vm)
	{
		InitializeComponent();
	}
}