﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBlog.Domain.Repository.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int id);
        Task<T> Get(Expression<Func<T, bool>> predicate);

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Delete(int id);
    }
}
