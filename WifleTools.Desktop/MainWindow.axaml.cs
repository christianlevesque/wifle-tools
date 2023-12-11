using AvaloniaDi.Views;
using WifleTools.Views;

namespace WifleTools;

public partial class MainWindow
	: SiteveyorMainWindow<CustomMainWindowViewModel>
{
    public MainWindow(CustomMainWindowViewModel vm) : base(vm)
    {
        InitializeComponent();
	}
}