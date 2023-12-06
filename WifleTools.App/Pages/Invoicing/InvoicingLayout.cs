using MudBlazor;
using WifleTools.Shared;
using WifleTools.Tools;

namespace WifleTools.Pages.Invoicing;

public class InvoicingLayout : MainLayout
{
	protected override void SetupNav()
	{
		NavMenuState.Subtext = "Invoicing";
		NavMenuState.MaxWidth = MaxWidth.Small;
		NavMenuState.FixedWidth = false;
		NavMenuState.BackUrl = Urls.Home;
		NavMenuState.Add((Urls.Invoices.Index, "Listing", Icons.Material.Filled.Folder));
		NavMenuState.Add((Urls.Invoices.Add, "Create invoice", Icons.Material.Filled.AttachMoney));
	}
}