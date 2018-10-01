﻿using CleanArchitectureLab.Core.Application.Tarefas.Concluir;
using CleanArchitectureLab.Core.Application.Tarefas.Criar;
using CleanArchitectureLab.Core.Application.Tarefas.Listar;
using CleanArchitectureLab.UI.Common;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CleanArchitectureLab.UI.Tarefas
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IListarTarefaCommand _listarTarefaCommand;
        private readonly IConcluirTarefaCommand _concluirTarefaCommand;
        private readonly ICriarTarefaCommand _criarTarefaCommand;

        public TarefasController(IListarTarefaCommand listarTarefaCommand, IConcluirTarefaCommand concluirTarefaCommand, ICriarTarefaCommand criarTarefaCommand)
        {
            _listarTarefaCommand = listarTarefaCommand;
            _concluirTarefaCommand = concluirTarefaCommand;
            _criarTarefaCommand = criarTarefaCommand;
        }

        [Route("{responsavelId}")]
        [HttpGet]
        public IActionResult ListarTarefas(int responsavelId)
        {
            try
            {
                var result = _listarTarefaCommand.Execute(responsavelId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // logar
                return StatusCode(500, Mensagens.ErroGeral);
            }
            
        }

        [HttpPost]
        public IActionResult CriarTarefa(CriarTarefaDto dto)
        {
            try
            {
                // Validar
                _criarTarefaCommand.Execute(dto);

                return StatusCode(201, Mensagens.CadastroSucesso);
            }
            catch (Exception ex)
            {
                //logar
                return StatusCode(500, Mensagens.ErroGeral);
            }
        }

        [Route("AterarStatus")]
        [HttpPost]
        public IActionResult ConcluirTarefa(ConcluirTarefaDto dto)
        {
            try
            {
                // Validar
                _concluirTarefaCommand.Execute(dto);

                return StatusCode(201, Mensagens.CadastroSucesso);
            }
            catch (Exception ex)
            {
                //logar
                return StatusCode(500, Mensagens.ErroGeral);
            }
        }
    }
}