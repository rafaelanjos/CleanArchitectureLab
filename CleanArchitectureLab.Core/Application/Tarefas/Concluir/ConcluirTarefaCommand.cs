using CleanArchitectureLab.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Tarefas.Concluir
{
    public class ConcluirTarefaCommand : IConcluirTarefaCommand
    {
        private readonly TarefasContext _context;

        public ConcluirTarefaCommand(TarefasContext context)
        {
            _context = context;
        }

        public void Execute(ConcluirTarefaDto dto)
        {
            var tarefa = _context.Tarefas.Where(x => x.Id == dto.Id).FirstOrDefault();
            tarefa.AlterarEstadoConclusao();
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
        }
    }
}
