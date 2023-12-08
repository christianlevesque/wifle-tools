using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WifleTools.Data;

namespace WifleTools.Pdf;

public class HeaderComponent : IComponent
{
	private readonly Invoice _invoice;

	public HeaderComponent(Invoice invoice)
	{
		_invoice = invoice;
	}

	/// <inheritdoc />
	public void Compose(IContainer container)
	{
		var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

		container.Row(row =>
		{
			row.RelativeItem().Column(column =>
			{
				column.Item().Text($"Invoice #{_invoice.InvoiceNumber}").Style(titleStyle);

				column.Item().Text(text =>
				{
					text.Span("Issue date: ").SemiBold();
					text.Span($"{_invoice.Date:d}");
				});
			});
		});
	}
}