using MudBlazor;
using WifleTools.Shared;
using WifleTools.Tools;

namespace WifleTools.Pages.Banking;

public class BankingLayout : MainLayout
{
	protected override void SetupNav()
	{
		NavMenuState.Subtext = "Bank accounts";
		NavMenuState.MaxWidth = MaxWidth.Small;
		NavMenuState.FixedWidth = false;
		NavMenuState.BackUrl = Urls.Home;
		NavMenuState.Add((Urls.Banking.Index, "Listing", Icons.Material.Filled.CreditCard));
		NavMenuState.Add((Urls.Banking.Add, "Add new account", Icons.Material.Filled.AddCard));
	}
}