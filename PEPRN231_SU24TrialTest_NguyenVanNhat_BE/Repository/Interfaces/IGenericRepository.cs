﻿using System.Linq.Expressions;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int? pageIndex = null, int? pageSize = null);

        Task<TEntity> GetByIDAsync(object id);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);

        Task InsertAsync(TEntity entity);

        Task DeleteAsync(object id);

        Task DeleteAsync(TEntity entityToDelete);

        Task UpdateAsync(TEntity entityToUpdate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}
