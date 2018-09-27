using CleanArchitectureLab.Core.Application.Tarefas.Concluir;
using CleanArchitectureLab.Core.Application.Tarefas.Criar;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureLab.UI.Tarefas
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IConcluirTarefaCommand _concluirTarefaCommand;
        private readonly ICriarTarefaCommand _criarTarefaCommand;

        public TarefasController(IConcluirTarefaCommand concluirTarefaCommand, ICriarTarefaCommand criarTarefaCommand)
        {
            _concluirTarefaCommand = concluirTarefaCommand;
            _criarTarefaCommand = criarTarefaCommand;
        }


    }
}