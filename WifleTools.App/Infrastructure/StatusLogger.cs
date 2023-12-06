using System;
using Microsoft.Extensions.Logging;
using MudBlazor;

namespace WifleTools.Infrastructure;

public class StatusLogger<T> : IStatusLogger<T>
{
	private readonly ISnackbar _snackbar;
	private readonly ILogger<T> _logger;

	public StatusLogger(ISnackbar snackbar, ILogger<T> logger)
	{
		_snackbar = snackbar;
		_logger = logger;
	}

	/// <inheritdoc />
	public void Success(string message)
	{
		_snackbar.Add(message, Severity.Success, ConfigureSnackbar);
		_logger.LogInformation(message);
	}

	/// <inheritdoc />
	public void Warning(string message)
	{
		_snackbar.Add(message, Severity.Warning, ConfigureDangerSnackbar);
		_logger.LogWarning(message);
	}

	/// <inheritdoc />
	public void Info(string message)
	{
		_snackbar.Add(message, Severity.Info, ConfigureSnackbar);
		_logger.LogInformation(message);
	}

	/// <inheritdoc />
	public void Error(string message)
	{
		_snackbar.Add(message, Severity.Error, ConfigureDangerSnackbar);
		_logger.LogError(message);
	}

	/// <inheritdoc />
	public void Error(Exception e)
	{
		var message = e is Infrastructure.Exceptions.AppException 
			? e.Message
			: "An unknown error has occurred. If you continue to have problems, please contact Hubber.";

		_snackbar.Add(message, Severity.Error, ConfigureDangerSnackbar);
		_logger.LogError(e, e.Message);
	}

	private void ConfigureSnackbar(SnackbarOptions o)
	{
		o.ShowTransitionDuration = 500;
		o.HideTransitionDuration = 500;
		o.VisibleStateDuration = 5000;
	}

	private void ConfigureDangerSnackbar(SnackbarOptions o)
	{
		o.ShowTransitionDuration = 500;
		o.HideTransitionDuration = 500;
		o.RequireInteraction = true;
	}
}