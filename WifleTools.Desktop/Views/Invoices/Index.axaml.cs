using System.Threading.Tasks;
using Percival.Routing;
using Percival.Views;

namespace WifleTools.Views.Invoices;

[Route(Urls.Invoices.Index)]
public partial class Index : PercivalControl<IndexViewModel>
{
	public Index(IndexViewModel vm) : base(vm)
	{
		InitializeComponent();
	}

	/// <inheritdoc />
	public override Task PercivalInitialized()
	{
		System.Diagnostics.Debug.WriteLine($"VM is {Vm.Invoices}");
		return Vm.LoadInvoices();
	}
}