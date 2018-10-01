using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Tarefas.Criar
{
    public interface ICriarTarefaCommand
    {
        void Execute(CriarTarefaDto tarefaDto);
    }
}
