using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Percival.Routing;
using Percival.Views;
using WifleTools.Utils;
using CommunityToolkit.Mvvm.Input;

namespace WifleTools.Views;

public partial class CustomMainWindowViewModel : MainWindowViewModel
{
	private readonly INavigationManager _navManager;

	public MainMenuItem[] MainMenuItems { get; }

	/// <inheritdoc />
	public CustomMainWindowViewModel(
		INavigationManager navManager,
		ActiveViewProvider activeViewProvider)
		: base(activeViewProvider)
	{
		_navManager = navManager;
		MainMenuItems = new[]
		{
			new MainMenuItem("Home", GoHomeCommand),
			new MainMenuItem("Invoices", GoHomeCommand),
			new MainMenuItem("Clients", GoHomeCommand),
			new MainMenuItem("Banking", GoHomeCommand),
			new MainMenuItem("Recipients", GoHomeCommand),
			new MainMenuItem("About", GoAboutCommand)
		};
	}

	[RelayCommand]
	private Task GoHome() => _navManager.NavigateTo(Urls.Home);

	[RelayCommand]
	private Task GoAbout() => _navManager.NavigateTo(Urls.About);

	[RelayCommand]
	private void OpenGpl()
		=> OpenBrowser("https://www.gnu.org/licenses/gpl-3.0.en.html");

	[RelayCommand]
	private void OpenGitHub()
		=> OpenBrowser("https://github.com/AvaloniaUI/Avalonia/blob/938b5ed18f6780c8a16382dca2d034f67d271eed/src/Avalonia.Dialogs/AboutPercivalalog.xaml.cs"); // TODO: replace with actual URL

	private void OpenBrowser(string url)
	{
		var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
		var isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

		var processInfo = new ProcessStartInfo
		{
			FileName = isWindows ? url : "open",
			Arguments = isMac ? url : string.Empty,
			CreateNoWindow = true,
			UseShellExecute = isWindows
		};

		Process.Start(processInfo);
	}
}