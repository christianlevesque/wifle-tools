using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using WifleTools.Data;
using WifleTools.Infrastructure;

namespace WifleTools.Pdf;

public class InvoicePdfGenerator
{
	private readonly AppDbContext _dbContext;
	private readonly IStatusLogger<InvoicePdfGenerator> _statusLogger;

	public InvoicePdfGenerator(
		AppDbContext dbContext,
		IStatusLogger<InvoicePdfGenerator> statusLogger)
	{
		_dbContext = dbContext;
		_statusLogger = statusLogger;
	}

	public async Task Generate(Invoice invoice)
	{
		try
		{
			var existing = await _dbContext.Invoices
				.Where(i => i.Date == invoice.Date)
				.OrderBy(i => i.CreatedAt)
				.ToListAsync();
			var number = existing.FindIndex(i => i.Id == invoice.Id) + 1;
			invoice.InvoiceNumber = $"{invoice.Date.Year}{invoice.Date.Month}{invoice.Date.Day}{number}";

			var pdf = new InvoiceDocument(invoice);
			var filename = $"{invoice.Client.Name}_{invoice.InvoiceNumber}.pdf";
			var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			var filePath = Path.Combine(desktopPath, filename);
			pdf.GeneratePdf(filePath);

			_statusLogger.Success($"Invoice for {invoice.Client.Name} was exported to your desktop!");
			_statusLogger.Success("Look at Wifle EARN! Look at her EARN!");
		}
		catch (Exception e)
		{
			_statusLogger.Error(e);
		}
	}
}