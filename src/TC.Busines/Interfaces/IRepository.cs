﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TC.Busines.Models;

namespace TC.Busines.Interfaces;
public interface IRepository<TEntity>: IDisposable where TEntity : Entity
{
    void Adicionar(TEntity entity);
    Task<TEntity> ObterPorId(Guid id);
    Task<List<TEntity>> ObterTodos();
    void Atualizar(TEntity entity);
    void Remover(Guid id);
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}
