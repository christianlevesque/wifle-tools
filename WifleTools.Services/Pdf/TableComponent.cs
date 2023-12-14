using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WifleTools.Data;
using WifleTools.Tools;

namespace WifleTools.Pdf;

public class TableComponent : IComponent
{
	private readonly Invoice _invoice;

	public TableComponent(Invoice invoice)
	{
		_invoice = invoice;
	}

	/// <inheritdoc />
	public void Compose(IContainer container)
	{
		container.Table(
        		table =>
        		{
        			table.ColumnsDefinition(
        				columns =>
        				{
        					columns.ConstantColumn(25);
        					columns.RelativeColumn(3);
        					columns.RelativeColumn();
        					columns.RelativeColumn();
        					columns.RelativeColumn();
        				});
        
        			table.Header(
        				header =>
        				{
        					header
        						.Cell()
        						.Element(HeaderCellStyle)
        						.Text("#");
        					header
        						.Cell()
        						.Element(HeaderCellStyle)
        						.Text("Product");
        					header
        						.Cell()
        						.Element(HeaderCellStyle)
        						.Text("Unit price");
        					header
        						.Cell()
        						.Element(HeaderCellStyle)
        						.Text("Quantity");
        					header
        						.Cell()
        						.Element(HeaderCellStyle)
								.AlignRight()
        						.Text("Total");
        				});
        
        			table
        				.Cell()
        				.Element(BodyCellStyle)
        				.Text("1");
        			table
        				.Cell()
        				.Element(BodyCellStyle)
        				.Text(_invoice.For);
        			table
        				.Cell()
        				.Element(BodyCellStyle)
        				.Text($"{_invoice.Client.Rate.ToCurrencyString()}/word");
        			table
        				.Cell()
        				.Element(BodyCellStyle)
        				.Text($"{_invoice.Amount} words");
        			table
        				.Cell()
        				.Element(LastBodyCellStyle)
						.AlignRight()
        				.Text(
        					InvoiceUtils.GetInvoiceAmount(_invoice)
        						.ToCurrencyString());
        
        			
        		});
	}

	private static IContainer HeaderCellStyle(IContainer container)
    {
        return container
            .DefaultTextStyle(x => x.SemiBold())
            .PaddingVertical(5)
            .BorderBottom(1)
            .BorderColor(Colors.Black);
    }

	private static IContainer BodyCellStyle(IContainer container)
	{
		return LastBodyCellStyle(container).PaddingRight(15);
	}

	private static IContainer LastBodyCellStyle(IContainer container)
	{
		return container
			.BorderBottom(1)
			.BorderColor(Colors.Grey.Lighten2)
			.PaddingVertical(5);
	}
}