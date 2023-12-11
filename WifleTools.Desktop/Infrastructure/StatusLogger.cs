using System;
using Microsoft.Extensions.Logging;

namespace WifleTools.Infrastructure;

public class StatusLogger<T> : IStatusLogger<T>
{
	private readonly ILogger<T> _logger;

	public StatusLogger(ILogger<T> logger)
	{
		_logger = logger;
	}

	/// <inheritdoc />
	public void Success(string message)
	{
		_logger.LogInformation(message);
	}

	/// <inheritdoc />
	public void Warning(string message)
	{
		_logger.LogWarning(message);
	}

	/// <inheritdoc />
	public void Info(string message)
	{
		_logger.LogInformation(message);
	}

	/// <inheritdoc />
	public void Error(string message)
	{
		_logger.LogError(message);
	}

	/// <inheritdoc />
	public void Error(Exception e)
	{
		var message = e is Infrastructure.Exceptions.AppException 
			? e.Message
			: "An unknown error has occurred. If you continue to have problems, please contact Hubber.";

		_logger.LogError(e, e.Message);
	}
}