using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WifleTools.Data;

namespace WifleTools.Pdf;

public class InvoiceDocument : IDocument
{
	private readonly Invoice _invoice;

	public InvoiceDocument(Invoice invoice)
	{
		_invoice = invoice;
	}

	public void Compose(IDocumentContainer container)
	{
		container.Page(
			page =>
			{
				page.Size(PageSizes.A4);
				page.Margin(50);
	
				page.Header()
					.Component(new HeaderComponent(_invoice));
				page.Content()
					.Component(new BodyComponent(_invoice));
			});
	}
}