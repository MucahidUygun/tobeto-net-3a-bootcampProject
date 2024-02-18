using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework.EfRepositoryBase
{
    public class EfRepositoryBase<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TContext : DbContext
    {
        protected readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }
        //IQueryable, LINQ sorguları oluşturmak için kullanılan bir.NET arayüzüdür.TEntity, metodun sorgulanacağı veri tipidir.
        //Query: Bu, metodun adıdır. Query metodu, IQueryable tipinde bir veri kaynağına LINQ sorguları oluşturmak için kullanılır.
        //Buradaki işleyiş:
        /*_context nesnesinin Set<TEntity>() metodu çağrılır.Bu metot, TEntity tipindeki veriler için bir DbSet nesnesi döndürür.
        DbSet nesnesi, bir IQueryable nesnesine dönüştürülür. Dönüştürülen IQueryable nesnesi, metodun dönüş değeri olarak döndürülür.*/
        public IQueryable<TEntity> Query() => Context.Set<TEntity>();

        public async Task<TEntity> Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);
            //Burada bir liste alıyoruz. Listedeki tüm verileri istediğimiz durumda predicate null olacaktır. Tüm verileri değil de ilgili sorguya göre verileri de listeleyebiliriz bu durumda null durumu ortadan kalkacaktır.
            if (predicate != null)
                queryable = queryable.Where(predicate);
            return await queryable.ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
