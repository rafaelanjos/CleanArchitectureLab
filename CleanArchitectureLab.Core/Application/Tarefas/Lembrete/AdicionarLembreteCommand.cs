using CleanArchitectureLab.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Tarefas.Lembrete
{
    public class AdicionarLembreteCommand : IAdicionarLembreteCommand
    {
        private readonly TarefasContext _context;

        public AdicionarLembreteCommand(TarefasContext context)
        {
            _context = context;
        }

        public void Execute(AdiconarLembreteDto dto)
        {
            var tarefa = _context.Tarefas.Where(x => x.Id == dto.Id).FirstOrDefault();
            tarefa.Lembrete = dto.Lembrete;
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
        }
    }
}
