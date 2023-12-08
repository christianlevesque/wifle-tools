using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WifleTools.Data;

namespace WifleTools.Pdf;

public class CommentsComponent : IComponent
{
	private readonly Invoice _invoice;

	public CommentsComponent(Invoice invoice)
	{
		_invoice = invoice;
	}

	/// <inheritdoc />
	public void Compose(IContainer container)
	{
		container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
		{
			column.Spacing(5);
			column
				.Item()
				.Text("Comments").FontSize(14);
			column
				.Item()
				.Text("Please remit payment to the following bank account:");
			column
				.Item()
				.Text($"ABA: {_invoice.Account.AbaNumber}");
			column
				.Item()
				.Text($"Account: {_invoice.Account.AccountNumber}");
		});
	}
}