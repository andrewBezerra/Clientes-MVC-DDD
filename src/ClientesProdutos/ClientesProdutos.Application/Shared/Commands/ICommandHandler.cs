namespace ClientesProdutos.Application.Shared.Commands
{
    public interface ICommandHandler<Command> where Command : ICommand
    {
        ICommandResult Handle(Command command);
    }
}