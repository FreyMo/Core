namespace Core.Common.Commands
{
	using System.Windows.Input;

	public interface ICommandBase : ICommand
	{
		void RaiseCanExecuteChanged();
	}
}