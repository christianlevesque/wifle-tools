using AvaloniaDi.Views;

namespace WifleTools.Views;

public class AboutViewModel : IViewModel
{
	public string[] TechStackItems { get; } =
	{
		"AvaloniaUI for the user interface",
		"Entity Framework Core for database manipulation",
		"SQLite for data storage in text files"
	};
}