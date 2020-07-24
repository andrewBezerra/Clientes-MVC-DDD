using System.Collections.Generic;

namespace ClientesProdutos.Application.Shared.Commands
{
    public interface ICommandResult
    {
        bool Ok { get; }
        IEnumerable<string> Results { get; set; }
    }
}