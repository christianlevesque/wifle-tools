using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WifleTools.Pdf;

public class AddressComponent : IComponent
{
	private readonly AddressableEntity _entity;
	private readonly string _title;

	public AddressComponent(AddressableEntity entity, string title)
	{
		_entity = entity;
		_title = title;
	}

	/// <inheritdoc />
	public void Compose(IContainer container)
	{
		container.Column(column =>
		{
			column.Spacing(2);

			column
				.Item()
				.BorderBottom(1)
				.PaddingBottom(5)
				.Text(_title)
				.FontSize(16)
				.Bold();

			column
				.Item()
				.Text(_entity.Name);

			if (!string.IsNullOrEmpty(_entity.Address1))
			{
				column
					.Item()
					.Text(_entity.Address1);
			}

			if (!string.IsNullOrEmpty(_entity.City))
			{
				column
					.Item()
					.Text(
						text =>
						{
							text.Span(_entity.City);
							if (!string.IsNullOrEmpty(_entity.State))
							{
								text.Span($", {_entity.State}");
							}
						});
			}
		});
	}
}