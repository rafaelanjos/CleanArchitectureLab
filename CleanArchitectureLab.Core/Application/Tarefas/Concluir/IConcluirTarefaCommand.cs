using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Tarefas.Concluir
{
    public interface IConcluirTarefaCommand
    {
        void Execute(ConcluirTarefaDto dto);
    }
}
