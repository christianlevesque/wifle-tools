// ReSharper disable MemberHidesStaticFromOuterClass
namespace WifleTools.Tools;

public static class Urls
{
	private const string Base = "/";
	public const string Home = Base;
	public const string About = "/About";

	public static class Invoices
	{
		private const string Base = "/Invoices";
		public const string Index = Base;
		public const string Add = $"{Base}/Add";
	}

	public static class Clients
	{
		private const string Base = "/Clients";
		public const string Index = Base;
		public const string Add = $"{Base}/Add";
	}

	public static class Banking
	{
		private const string Base = "/Banking";
		public const string Index = Base;
		public const string Add = $"{Base}/Add";
	}
}