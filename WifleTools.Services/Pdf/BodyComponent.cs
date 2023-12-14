using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WifleTools.Data;
using WifleTools.Tools;

namespace WifleTools.Pdf;

public class BodyComponent : IComponent
{
	private readonly Invoice _invoice;

	public BodyComponent(Invoice invoice)
	{
		_invoice = invoice;
	}

	/// <inheritdoc />
	public void Compose(IContainer container)
	{
		container
			.PaddingVertical(40)
			.Column(
				column =>
				{
					column.Spacing(40);

					column
						.Item()
						.Row(
							row =>
							{
								row
									.RelativeItem()
									.Component(new AddressComponent(_invoice.Client, "To"));
								row.ConstantItem(50);
								row
									.RelativeItem()
									.Component(new AddressComponent(_invoice.Recipient, "From"));
							});

					column
						.Item()
						.Component(new TableComponent(_invoice));

					var titleStyle = TextStyle.Default.Bold().FontColor(Colors.Blue.Medium);
					column
						.Item()
						.AlignRight()
						.Text(text =>
						{
							text
								.Span("Total")
								.Style(titleStyle);
							text
								.Element()
								.Width(12);
							text.Span(InvoiceUtils.GetInvoiceAmount(_invoice).ToCurrencyString());
						});

					column
						.Item()
						.PaddingTop(25)
						.Component(new CommentsComponent(_invoice));
				});
	}
}