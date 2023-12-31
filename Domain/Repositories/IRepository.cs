﻿using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Domain.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
	TEntity? Get(System.Guid id);
	Task<TEntity?> GetAsync(System.Guid id);

	IEnumerable<TEntity> GetAll();
	Task<IEnumerable<TEntity>> GetAllAsync();

	IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
	Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

	TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
	Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

	IEnumerable<TEntity> GetPage(int pageIndex, int pageSize = 10);

	void Add(TEntity entity);
	Task AddAsync(TEntity entity);
	void AddRange(IEnumerable<TEntity> entities);
	Task AddRangeAsync(IEnumerable<TEntity> entities);

	void Remove(TEntity entity);
	void RemoveRange(IEnumerable<TEntity> entities);
}
