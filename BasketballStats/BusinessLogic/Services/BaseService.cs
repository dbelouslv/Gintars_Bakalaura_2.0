using BS.EntityData.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

public abstract class BaseService<T> where T : class
{
    protected IDataContext DataContext;
    public readonly IDbSet<T> Dbset;

    protected BaseService(IDataContext dataContext)
    {
        DataContext = dataContext;
        Dbset = dataContext.Set<T>();
    }

    public virtual void Add(T entity)
    {
        Dbset.Add(entity);
        DataContext.SaveChanges();
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        foreach (T entity in entities)
        {
            Dbset.Add(entity);
        }

        DataContext.SaveChanges();
    }

    public virtual void Update(T entity)
    {
        Dbset.Attach(entity);
        DataContext.Entry(entity).State = EntityState.Modified;
        DataContext.SaveChanges();
    }

    public virtual void Update(IEnumerable<T> entities)
    {
        foreach (T entity in entities)
        {
            Dbset.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        DataContext.SaveChanges();
    }

    public virtual void Delete(T entity)
    {
        Dbset.Remove(entity);
        DataContext.SaveChanges();
    }

    public virtual void Delete(IEnumerable<T> entitites)
    {
        foreach (T entity in entitites.ToArray())
        {
            Dbset.Remove(entity);
        }

        DataContext.SaveChanges();
    }

    public virtual T Get(Expression<Func<T, bool>> where)
    {
        return Dbset.Where(where).FirstOrDefault();
    }
}