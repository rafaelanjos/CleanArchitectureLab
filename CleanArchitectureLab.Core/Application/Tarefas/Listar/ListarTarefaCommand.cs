using AutoMapper;
using CleanArchitectureLab.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Tarefas.Listar
{
    public class ListarTarefaCommand : IListarTarefaCommand
    {
        private readonly TarefasContext _context;

        public ListarTarefaCommand(TarefasContext context)
        {
            _context = context;
        }

        public IEnumerable<ListaTarefasDto> Execute(int responsavelId)
        {
            var tarefas = _context.Tarefas.Where(x => x.ResponsavelId == responsavelId).ToList();
            return Mapper.Map<IEnumerable<ListaTarefasDto>>(tarefas);
        }
    }
}
