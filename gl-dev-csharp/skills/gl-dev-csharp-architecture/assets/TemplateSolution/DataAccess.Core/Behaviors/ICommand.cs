namespace DataAccess.Core.Behaviors;

public interface ICommand
{
	public Task<int> RunAsync<TInput, TOutput>(TInput data);
}
