using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitchGames.Users.Dal.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}