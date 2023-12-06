using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using WifleTools.Infrastructure;

namespace WifleTools.Pages;

public abstract class ActionPageBase<TPage, TService, TModel> : ActionPageBase<TPage, TService>
	where TPage : ComponentBase
	where TModel : new()
{
	protected TModel Model = new ();
}

public abstract class ActionPageBase<TPage, TService> : ComponentBase 
	where TPage : ComponentBase
{
	private int _counter;
	protected string? ErrorMessage;
	protected string? SuccessMessage;

	protected bool Loading => _counter > 0;

	protected bool WasSuccessful { get; set; }

	protected string? SearchTerm { get; set; }

	[Inject]
	protected ILogger<TPage> Logger { get; set; } = default!;

	[Inject]
	protected IStatusLogger<TPage> StatusLogger { get; set; } = default!;

	[Inject]
	protected NavigationManager NavManager { get; set; } = default!;

	[Inject]
	protected TService Service { get; set; } = default!;

	protected async Task SubmitRequest(Func<Task<bool>> submitFunc)
	{
		WasSuccessful = false;

		Logger!.LogInformation("Submitting service request");

		// Do the work
		_counter++;
		WasSuccessful = await submitFunc();
		--_counter;

		Logger!.LogInformation("Service request submitted");
	}

	protected async Task<TReturn> SubmitRequest<TReturn>(Func<Task<TReturn>> submitFunc)
	{
		WasSuccessful = false;

		Logger!.LogInformation("Submitting service request");

		++_counter;
		var result = await submitFunc();
		--_counter;

		Logger!.LogInformation("Service request submitted");

		WasSuccessful = result is not null;

		return result;
	}

	protected void ResetError()
	{
		ErrorMessage = null;
	}
}