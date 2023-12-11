using MudBlazor;
using WifleTools.Shared;
using WifleTools.Tools;

namespace WifleTools.Pages.Clients;

public class ClientsLayout : MainLayout
{
	protected override void SetupNav()
	{
		LayoutState.Subtext = "Clients";
		LayoutState.MaxWidth = MaxWidth.Large;
		LayoutState.FixedWidth = false;
		LayoutState.BackUrl = Urls.Home;
		LayoutState.Add((Urls.Clients.Index, "Listing", Icons.Material.Filled.Business));
		LayoutState.Add((Urls.Clients.Add, "Add new client", Icons.Material.Filled.AddBusiness));
	}
}