using MudBlazor;
using WifleTools.Shared;
using WifleTools.Tools;

namespace WifleTools.Pages.Recipients;

public class RecipientsLayout : MainLayout
{
	protected override void SetupNav()
	{
		LayoutState.Subtext = "Recipients";
		LayoutState.MaxWidth = MaxWidth.Large;
		LayoutState.FixedWidth = false;
		LayoutState.BackUrl = Urls.Home;
		LayoutState.Add((Urls.Recipients.Index, "Listing", Icons.Material.Filled.Groups));
		LayoutState.Add((Urls.Recipients.Add, "Add new recipient", Icons.Material.Filled.Person));
	}
}