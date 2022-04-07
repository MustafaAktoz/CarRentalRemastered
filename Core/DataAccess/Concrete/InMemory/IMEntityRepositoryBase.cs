using Core.Constants;
using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.Concrete.InMemory
{
    public class IMEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected List<TEntity> _entities;

        public IMEntityRepositoryBase()
        {
            _entities = new List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            int index = TryGetDataIndex(entity);
            _entities.Remove(_entities[index]);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.AsQueryable().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter==null?_entities:_entities.AsQueryable().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            int index = TryGetDataIndex(entity);
            _entities[index] = entity;
        }

        private int TryGetDataIndex(TEntity entity)
        {
            var result = _entities.SingleOrDefault(e => e.Id == entity.Id);
            if (result == null) throw new Exception(Messages.DataToBeProcessedWasNotFound);

            var index = _entities.FindIndex(e => e.Id == entity.Id);
            return index;
        }
    }
}