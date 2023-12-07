using MudBlazor;
using WifleTools.Shared;
using WifleTools.Tools;

namespace WifleTools.Pages.Banking;

public class BankingLayout : MainLayout
{
	protected override void SetupNav()
	{
		LayoutState.Subtext = "Bank accounts";
		LayoutState.MaxWidth = MaxWidth.Small;
		LayoutState.FixedWidth = false;
		LayoutState.BackUrl = Urls.Home;
		LayoutState.Add((Urls.Banking.Index, "Listing", Icons.Material.Filled.CreditCard));
		LayoutState.Add((Urls.Banking.Add, "Add new account", Icons.Material.Filled.AddCard));
	}
}