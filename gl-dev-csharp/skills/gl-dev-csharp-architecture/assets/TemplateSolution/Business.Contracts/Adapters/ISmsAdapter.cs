namespace Business.Contracts.Adapters;

public interface ISmsAdapter
{
	public TaskStatus Send(string phoneNumber, string text);
}
