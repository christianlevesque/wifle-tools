using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WifleTools.Infrastructure;
using WifleTools.Infrastructure.Exceptions;

namespace WifleTools;

public abstract class CrudService<TModel> : ICrudService<TModel>
	where TModel : Entity
{
	protected readonly AppDbContext DbContext;
	protected readonly IStatusLogger<CrudService<TModel>> StatusLogger;

	protected DbSet<TModel> Set => DbContext.Set<TModel>();

	protected CrudService(AppDbContext dbContext, IStatusLogger<CrudService<TModel>> statusLogger)
	{
		DbContext = dbContext;
		StatusLogger = statusLogger;
	}

	/// <inheritdoc />
	public async Task<TModel> Get(Guid id)
	{
		return await Set.FindAsync(id) ??
			throw new AppException($"Couldn't find an entity with ID {id}. Please contact Hubber!");
	}

	/// <inheritdoc />
	public async Task<List<TModel>> Get()
	{
		return await Set.ToListAsync();
	}

	/// <inheritdoc />
	public async Task<Guid> Add(TModel model)
	{
		await Set.AddAsync(model);
		await DbContext.SaveChangesAsync();
		return model.Id;
	}

	/// <inheritdoc />
	public async Task<bool> Edit(TModel model)
	{
		try
		{
			if (await Set.FindAsync(model.Id) is null)
			{
				StatusLogger.Error($"Couldn't find an entity with ID {model.Id}. Please contact Hubber!");
				return false;
			}

			Set.Update(model);
			await DbContext.SaveChangesAsync();
			return true;
		}
		catch (Exception e)
		{
			StatusLogger.Error(e);
			return false;
		}
	}

	/// <inheritdoc />
	public async Task<bool> Delete(Guid id)
	{
		try
		{
			var entity = await Set.FindAsync(id);
			if (entity is null) { return true; }

			Set.Remove(entity);
			await DbContext.SaveChangesAsync();
			return true;
		}
		catch (Exception e)
		{
			StatusLogger.Error(e);
			return false;
		}
	}
}

public interface ICrudService<TModel>
	where TModel : Entity
{
	/// <summary>
	/// Gets an entity by primary key
	/// </summary>
	/// <param name="id">The primary key of the entity to retrieve</param>
	/// <returns>the requested <c>TModel</c></returns>
	Task<TModel> Get(Guid id);

	/// <summary>
	/// Gets a list of all entities in the backend
	/// </summary>
	/// <returns>a list of all entities in the database</returns>
	Task<List<TModel>> Get();

	/// <summary>
	/// Creates a new entry in the backend
	/// </summary>
	/// <param name="model">The DTO representing the entity to create</param>
	/// <returns><c>Task</c></returns>
	Task<Guid> Add(TModel model);

	/// <summary>
	/// Updates an existing entity in the backend
	/// </summary>
	/// <param name="model">The DTO representing the entity to update</param>
	/// <returns>whether the edit operation was successful</returns>
	Task<bool> Edit(TModel model);

	/// <summary>
	/// Deletes an entity by primary key
	/// </summary>
	/// <param name="id">The primary key of the entity to delete</param>
	/// <returns><c>Task</c></returns>
	Task<bool> Delete(Guid id);
}