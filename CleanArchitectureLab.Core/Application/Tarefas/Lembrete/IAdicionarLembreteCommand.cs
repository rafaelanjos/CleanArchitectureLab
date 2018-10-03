using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Tarefas.Lembrete
{
    public interface IAdicionarLembreteCommand
    {
        void Execute(AdiconarLembreteDto dto);
    }
}
