using FullStackPhoneBook.Core.Contracts.Common;
using FullStackPhoneBook.Domain.Core;
using System.Linq;

namespace FullStackPhoneBook.Infrastructures.DataAccess.Common
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
    {

        private readonly PhoneBookContext _dbContext;
        public BaseRepository(PhoneBookContext dbContext)
        {
            _dbContext = dbContext;
        }



        public TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            TEntity entity = new TEntity
            {
                Id = id
            };
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }
    }
}
