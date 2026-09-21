using Business.Contracts.Adapters;

namespace Adapter.Sms;

/// <summary>
/// Defines the SMS adapter implementation.
/// Sends business-requested text messages through the adapter boundary.
/// The dependency injection container creates the adapter for consumers of ISmsAdapter.
/// It belongs to the adapter layer and isolates business code from the selected SMS provider.
/// Provider-specific delivery behavior remains intentionally unfinished in this reference template.
/// </summary>
internal class SmsAdapter : ISmsAdapter
{
	public TaskStatus Send(string phoneNumber, string text)
	{
		throw new NotImplementedException();
	}
}
