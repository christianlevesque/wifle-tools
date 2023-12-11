using MudBlazor;
using WifleTools.Shared;
using WifleTools.Tools;

namespace WifleTools.Pages.Invoicing;

public class InvoicingLayout : MainLayout
{
	protected override void SetupNav()
	{
		LayoutState.Subtext = "Invoicing";
		LayoutState.MaxWidth = MaxWidth.Large;
		LayoutState.FixedWidth = false;
		LayoutState.BackUrl = Urls.Home;
		LayoutState.Add((Urls.Invoices.Index, "Listing", Icons.Material.Filled.Folder));
		LayoutState.Add((Urls.Invoices.Add, "Create invoice", Icons.Material.Filled.AttachMoney));
	}
}