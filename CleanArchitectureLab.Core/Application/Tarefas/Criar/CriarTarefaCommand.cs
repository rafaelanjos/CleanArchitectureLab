using AutoMapper;
using CleanArchitectureLab.Core.Domain.Tarefas;
using CleanArchitectureLab.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Tarefas.Criar
{
    public class CriarTarefaCommand : ICriarTarefaCommand
    {
        private readonly TarefasContext _context;

        public CriarTarefaCommand(TarefasContext context)
        {
            _context = context;
        }

        public void Execute(TarefaDto tarefaDto)
        {
            var tarefa = Mapper.Map<Tarefa>(tarefaDto);
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            //disparar evento 
                // Ajuste no mongo para painel de leitura
                // Mongo para fila de tarefas concluidas no dia
        }
    }
}
