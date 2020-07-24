namespace ClientesProdutos.Application.Shared.Commands
{
    public interface ICommand
    {
        bool isValid { get; }
    }
}