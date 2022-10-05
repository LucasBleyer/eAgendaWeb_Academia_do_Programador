using AutoMapper;
using eAgenda.Aplicacao.ModuloTarefa;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Webapi.ViewModels.ModuloTarefa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace eAgenda.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TarefasController : eAgendaControllerBase
    {
        private readonly ServicoTarefa servicoTarefa;
        private readonly IMapper mapeadorTarefas;

        public TarefasController(ServicoTarefa servicoTarefa, IMapper mapeadorTarefas)
        {
            this.servicoTarefa = servicoTarefa;
            this.mapeadorTarefas = mapeadorTarefas;
        }

        [HttpGet]
        public ActionResult<List<ListarTarefaViewModel>> SelecionarTodos()
        {
            var tarefaResult = servicoTarefa.SelecionarTodos(StatusTarefaEnum.Todos, UsuarioLogado.Id);

            if (tarefaResult.IsFailed)
                return InternalError(tarefaResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorTarefas.Map<List<ListarTarefaViewModel>>(tarefaResult.Value)
            });
        }


        [HttpGet("visualizar-completa/{id:guid}")]
        public ActionResult<VisualizarTarefaViewModel> SelecionarTarefaCompletaPorId(Guid id)
        {
            var tarefaResult = servicoTarefa.SelecionarPorId(id);

            if (tarefaResult.IsFailed && RegistroNaoEncontrado(tarefaResult))
                return NotFound(tarefaResult);

            if (tarefaResult.IsFailed)
                return InternalError(tarefaResult);

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorTarefas.Map<VisualizarTarefaViewModel>(tarefaResult.Value)
            });
        }


        [HttpPost]
        public ActionResult<FormsTarefaViewModel> Inserir(InserirTarefaViewModel tarefaVM)
        {
            var tarefa = mapeadorTarefas.Map<Tarefa>(tarefaVM);

            tarefa.UsuarioId = UsuarioLogado.Id;

            var tarefaResult = servicoTarefa.Inserir(tarefa);

            if (tarefaResult.IsFailed)
                return InternalError(tarefaResult);

            return Ok(new
            {
                sucesso = true,
                dados = tarefaVM
            });
        }       

        [HttpPut("{id:guid}")]
        public ActionResult<FormsTarefaViewModel> Editar(Guid id, EditarTarefaViewModel tarefaVM)
        {
            var tarefaResult = servicoTarefa.SelecionarPorId(id);

            if (tarefaResult.IsFailed && RegistroNaoEncontrado(tarefaResult))
                return NotFound(tarefaResult);

            var tarefa = mapeadorTarefas.Map(tarefaVM, tarefaResult.Value);

            tarefaResult = servicoTarefa.Editar(tarefa);

            if (tarefaResult.IsFailed)
                return InternalError(tarefaResult);

            return Ok(new
            {
                sucesso = true,
                dados = tarefaVM
            });
        }


        [HttpDelete("{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var tarefaResult = servicoTarefa.Excluir(id);

            if (tarefaResult.IsFailed && RegistroNaoEncontrado<Tarefa>(tarefaResult))
                return NotFound(tarefaResult);

            if (tarefaResult.IsFailed)
                return InternalError<Tarefa>(tarefaResult);

            return NoContent();
        }


    }
}
