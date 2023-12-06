using MudBlazor;
using WifleTools.Tools;

namespace WifleTools.Shared;

public partial class MainLayout
{
	/// <inheritdoc />
	protected override void SetupNav()
	{
		NavMenuState.MaxWidth = MaxWidth.False;
		NavMenuState.FixedWidth = true;
		NavMenuState.Subtext = "Quick launch";
		NavMenuState.Add((Urls.Home, "Home", Icons.Material.Filled.Home));
		NavMenuState.Add((Urls.Invoices.Index, "Invoicing", Icons.Material.Filled.AttachMoney));
		NavMenuState.Add((Urls.Clients.Index, "Clients", Icons.Material.Filled.Business));
		NavMenuState.Add((Urls.Banking.Index, "Banking", Icons.Material.Filled.CreditCard));
	}
}