using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Tarefas.Listar
{
    public interface IListarTarefaCommand
    {
        IEnumerable<ListaTarefasDto> Execute(int responsavelId);
    }
}
