﻿using Microsoft.AspNetCore.Mvc;
using TC.Api.ViewModels;

namespace TC.Api.Controllers;

[Route("api/fornecedores")]
public class FornecedoresController : MainController
{
    public FornecedoresController()
    {

    }

    [HttpGet]
    public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
    {

    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
    {

    }

    [HttpPost]
    public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
    {

    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
    {

    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
    {

    }
}
