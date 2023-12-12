using System.Threading.Tasks;
using Percival.Routing;
using Percival.Views;

namespace WifleTools.Views;

public class HomeViewModel : IViewModel
{
	private readonly INavigationManager _navManager;

	public HomeViewModel(INavigationManager navManager)
	{
		_navManager = navManager;
	}

	public Task GoAbout()
		=> _navManager.NavigateTo(Urls.About);
}