﻿using System.Threading.Tasks;
using Percival.Routing;
using Percival.Views;

namespace WifleTools.Views;

[Route(Urls.About)]
public partial class About : PercivalControl
{
	public About()
	{
		InitializeComponent();
	}

	[Inject]
	private AboutViewModel Vm { get; set; } = default!;

	/// <inheritdoc />
	public override Task PercivalInitialized()
	{
		DataContext = Vm;
		return Task.CompletedTask;
	}
}