using LoggerService.BL.Services;
using LoggerService.Common;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.DAL.Repositories
{
    public interface IMongoRepository<TEntity> where TEntity : IIdentifiable
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        //Task<PagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate,
        //       TQuery query) where TQuery : PagedQueryBase;
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<string>> GetAllAsync();
    }
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : IIdentifiable
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogRequestsHandler _logRequestsHandler;
        public MongoRepository(/*IConnectionFactory connectionFactory*/ ILogRequestsHandler logRequestsHandler)
        {
            //_connectionFactory = connectionFactory;
            _logRequestsHandler = logRequestsHandler;
        }

        protected IMongoCollection<TEntity> Collection { get; }

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            Collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> GetAsync(Guid id)
            => await GetAsync(e => e.Id == id);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await Collection.Find(predicate).SingleOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await Collection.Find(predicate).ToListAsync();

        //public async Task<PagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate,
        //        TQuery query) where TQuery : PagedQueryBase
        //    => await Collection.AsQueryable().Where(predicate).PaginateAsync(query);

        public async Task AddAsync(TEntity entity)
            => await Collection.InsertOneAsync(entity);

        public async Task UpdateAsync(TEntity entity)
            => await Collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);

        public async Task DeleteAsync(Guid id)
            => await Collection.DeleteOneAsync(e => e.Id == id);

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
            => await Collection.Find(predicate).AnyAsync();
        public async Task<List<string>> GetAllAsync()
            => await _logRequestsHandler.GetAllAsync();
    }
}
