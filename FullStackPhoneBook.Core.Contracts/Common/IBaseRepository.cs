using FullStackPhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStackPhoneBook.Core.Contracts.Common
{
    public interface IBaseRepository<TEntity> where TEntity:BaseEntity, new() // new yani hatman consrtuctor default dashte bashe
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        void Delete(int id);
        TEntity Add(TEntity entity);
    }
}
