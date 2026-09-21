using System.Runtime.CompilerServices;
using log4net;
using Shared.Contracts;

namespace Shared.Log4Net;

/// <summary>
/// Defines the Log4Net logging service.
/// Writes shared logging operations through the Log4Net library.
/// The dependency injection container supplies it to ILogService consumers when configured.
/// It translates caller context and exceptions into Log4Net entries.
/// It does not impose business-specific message content.
/// </summary>
internal class Log4NetLogService : ILogService
{
	private readonly ITlsService _tlsService;
	private readonly ILog _logger;

	public Log4NetLogService(ITlsService tlsService)
	{
		_tlsService = tlsService;
		_logger = LogManager.GetLogger(GetType());
	}

	public void Debug(
		string message,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Debug(GetFullMessage(message, filePath, lineNumber, memberName));

	public void Debug(
		string message,
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Debug(GetFullMessage(message, filePath, lineNumber, memberName), exception);

	public void Debug(
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Debug(GetFullMessage(exception.ToString(), filePath, lineNumber, memberName));

	public void Info(
		string message,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Info(GetFullMessage(message, filePath, lineNumber, memberName));

	public void Info(
		string message,
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Info(GetFullMessage(message, filePath, lineNumber, memberName), exception);

	public void Info(
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Info(GetFullMessage(exception.ToString(), filePath, lineNumber, memberName));

	public void Warn(
		string message,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Warn(GetFullMessage(message, filePath, lineNumber, memberName));

	public void Warn(
		string message,
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Warn(GetFullMessage(message, filePath, lineNumber, memberName), exception);

	public void Warn(
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Warn(GetFullMessage(exception.ToString(), filePath, lineNumber, memberName));

	public void Error(
		string message,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Error(GetFullMessage(message, filePath, lineNumber, memberName));

	public void Error(
		string message,
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Error(GetFullMessage(message, filePath, lineNumber, memberName), exception);

	public void Error(
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Error(GetFullMessage(exception.ToString(), filePath, lineNumber, memberName));

	public void Fatal(
		string message,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Fatal(GetFullMessage(message, filePath, lineNumber, memberName));

	public void Fatal(
		string message,
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Fatal(GetFullMessage(message, filePath, lineNumber, memberName), exception);

	public void Fatal(
		Exception exception,
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0,
		[CallerMemberName] string memberName = "") =>
		_logger.Fatal(GetFullMessage(exception.ToString(), filePath, lineNumber, memberName));

	public bool IsDebugEnabled => _logger.IsDebugEnabled;

	public bool IsInfoEnabled => _logger.IsInfoEnabled;

	public bool IsWarnEnabled => _logger.IsWarnEnabled;

	public bool IsErrorEnabled => _logger.IsErrorEnabled;

	public bool IsFatalEnabled => _logger.IsFatalEnabled;

	private string GetFullMessage(
		string message,
		string filePath,
		int lineNumber,
		string memberName = "")
	{
		int start = filePath.IndexOf("Accurence", StringComparison.Ordinal);
		int length = filePath.Length;
		string className;
		if (start >= 0)
		{
			className = filePath.Substring(start, length - start - 3).Replace('\\', '.');
		}
		else
		{
			className = filePath[..(length - 3)].Replace('\\', '.');
		}

		string correlationId = _tlsService.CorrelationId;
		return $"{correlationId}. {className}:{memberName}:{lineNumber}. {message}";
	}
}
