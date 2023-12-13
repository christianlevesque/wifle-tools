using System.Threading.Tasks;
using Percival.Routing;
using Percival.Views;

namespace WifleTools.Views.Invoices;

[Route(Urls.Invoices.Index)]
public partial class Index : PercivalControl
{
	public Index()
	{
		InitializeComponent();
	}

	[Inject]
	private IndexViewModel Vm { get; set; } = default!;

	/// <inheritdoc />
	public override Task PercivalInitialized()
	{
		DataContext = Vm;
		return Task.CompletedTask;
	}
}