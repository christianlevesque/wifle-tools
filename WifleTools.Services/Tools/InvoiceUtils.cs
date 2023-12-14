using WifleTools.Data;

namespace WifleTools.Tools;

public static class InvoiceUtils
{
	public static int GetInvoiceAmount(Invoice invoice) => invoice.Amount * invoice.Client.Rate;

	public static string ToCurrencyString(this int self) => $"{(double)self / 100:C}";

	public static string CreateInvoiceNumber(Invoice invoice, int number)
		=> $"{invoice.Date.Year}{invoice.Date.Month}{invoice.Date.Day}{number}";

	public static string CreateInvoiceFilename(Invoice invoice)
		=> $"{invoice.Client.Name}_{invoice.InvoiceNumber}.pdf";
}