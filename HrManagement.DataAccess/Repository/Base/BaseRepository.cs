using HrManagement.DataAccess.Context;
using HrManagement.DataAccess.Models;

namespace HrManagement.DataAccess.Repository.Base;

public abstract class BaseRepository<T>(HrManagementDbContext context) : IGenericRepository<T> where T : class, IBaseModel 
{
    public T? GetById(int id)
    {
        return context.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    public IQueryable<T> GetAll()
    {
        return context.Set<T>();
    }

    public bool Add(T entity)
    {
        context.Set<T>().Add(entity);
        return context.SaveChanges() > 0;
    }

    public bool Update(T entity)
    {
        var oldEntity = GetById(entity.Id);
        if (oldEntity is null) return false;
        
        UpdateEntity(oldEntity, entity);
        return context.SaveChanges() > 0;
    }

    protected abstract void UpdateEntity(T oldEntity, T newEntity);
    protected abstract void DeleteAdditionalDependencies();

    public bool Delete(int id)
    {
        var entity = GetById(id);
        if (entity is null) return false;
        
        context.Set<T>().Remove(entity);
        DeleteAdditionalDependencies();
        return context.SaveChanges() > 0;
    }
}