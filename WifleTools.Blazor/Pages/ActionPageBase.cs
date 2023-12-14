using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using WifleTools.Infrastructure;

namespace WifleTools.Pages;

public abstract class ActionPageBase<TPage, TModel> : ComponentBase 
	where TPage : ComponentBase
	where TModel : Entity, new()
{
	private int _counter;

	protected TModel Model = new ();

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
	protected ICrudService<TModel> Service { get; set; } = default!;

	protected async Task SubmitRequest(Func<Task<bool>> submitFunc)
	{
		WasSuccessful = false;

		Logger.LogInformation("Submitting service request");

		// Do the work
		_counter++;
		StateHasChanged();
		Logger.LogInformation("UI re-rendered after incrementing counter");
		try
		{
			WasSuccessful = await submitFunc();
			Logger.LogInformation("Service request submitted");
		}
		catch (Exception e)
		{
			Logger.LogInformation("Service request failed, see exception message");
			StatusLogger.Error(e);
		}
		--_counter;
		StateHasChanged();
		Logger.LogInformation("UI re-rendered after decrementing counter");
	}

	protected async Task<TReturn> SubmitRequest<TReturn>(Func<Task<TReturn>> submitFunc)
	{
		WasSuccessful = false;

		Logger.LogInformation("Submitting service request");

		++_counter;
		StateHasChanged();
		Logger.LogInformation("UI re-rendered after incrementing counter");

		TReturn result = default!;
		try
		{
			result = await submitFunc();
			Logger.LogInformation("Service request submitted");
		}
		catch (Exception e)
		{
			Logger.LogInformation("Service request failed, see exception message");
			StatusLogger.Error(e);
		}
		--_counter;
		WasSuccessful = result is not null;
		StateHasChanged();
		Logger.LogInformation("UI re-rendered after decrementing counter");

		return result;
	}

	protected async Task SubmitRequest(Func<Task> submitFunc)
	{
		WasSuccessful = false;

		Logger.LogInformation("Submitting service request");

		// Do the work
		_counter++;
		StateHasChanged();
		Logger.LogInformation("UI re-rendered after incrementing counter");

		try
		{
			await submitFunc();
			Logger.LogInformation("Service request submitted");
			WasSuccessful = true;
		}
		catch (Exception e)
		{
			Logger.LogInformation("Service request failed, see exception message");
			StatusLogger.Error(e);
		}
		--_counter;
		StateHasChanged();
		Logger.LogInformation("UI re-rendered after decrementing counter");

		Logger.LogInformation("Service request submitted");
	}
}