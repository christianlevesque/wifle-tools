using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Percival.Views;
using WifleTools.Data;

namespace WifleTools.Views.Invoices;

public partial class IndexViewModel : ObservableObject, IViewModel
{
	private readonly ICrudService<Invoice> _invoiceService;

	public IndexViewModel(ICrudService<Invoice> invoiceService)
	{
		_invoiceService = invoiceService;
	}

	[ObservableProperty]
	private List<Invoice> _invoices = new();

	public async Task LoadInvoices()
	{
		System.Diagnostics.Debug.WriteLine("Loading new invoices");
		Invoices = await _invoiceService.Get();
		// Invoices.Clear();
		// var invoices = await _invoiceService.Get();
		// foreach (var i in invoices)
		// {
		// 	Invoices.Add(i);
		// }
	}
}