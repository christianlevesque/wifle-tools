using MudBlazor;
using WifleTools.Tools;

namespace WifleTools.Shared;

public partial class MainLayout
{
	/// <inheritdoc />
	protected override void SetupNav()
	{
		LayoutState.MaxWidth = MaxWidth.False;
		LayoutState.FixedWidth = true;
		LayoutState.Subtext = "Quick launch";
		LayoutState.Add((Urls.Home, "Home", Icons.Material.Filled.Home));
		LayoutState.Add((Urls.Invoices.Index, "Invoicing", Icons.Material.Filled.AttachMoney));
		LayoutState.Add((Urls.Clients.Index, "Clients", Icons.Material.Filled.Business));
		LayoutState.Add((Urls.Banking.Index, "Banking", Icons.Material.Filled.CreditCard));
		LayoutState.Add((Urls.Recipients.Index, "Recipients", Icons.Material.Filled.Groups));
	}
}