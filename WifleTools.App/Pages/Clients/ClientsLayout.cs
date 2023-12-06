using MudBlazor;
using WifleTools.Shared;
using WifleTools.Tools;

namespace WifleTools.Pages.Clients;

public class ClientsLayout : MainLayout
{
	protected override void SetupNav()
	{
		NavMenuState.Subtext = "Clients";
		NavMenuState.MaxWidth = MaxWidth.Small;
		NavMenuState.FixedWidth = false;
		NavMenuState.BackUrl = Urls.Home;
		NavMenuState.Add((Urls.Clients.Index, "Listing", Icons.Material.Filled.Business));
		NavMenuState.Add((Urls.Clients.Add, "Add new client", Icons.Material.Filled.AddBusiness));
	}
}