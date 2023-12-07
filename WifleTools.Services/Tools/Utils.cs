using WifleTools.Data;

namespace WifleTools.Tools;

public static class Utils
{
	public static int GetInvoiceAmount(Invoice invoice) => invoice.Amount * invoice.Client.Rate;

	public static string ToCurrencyString(this int value) => $"{(double)value / 100:C}";
}