namespace DressZone.Repository
{
    using Context;
    using Context.Contracts;
    using DressZone.Repository.Contracts;
    using Models.Account;
    using Models.Shop.Common;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository(IDressZoneDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected IDressZoneDbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Hard Delete.Deletes the entire record from the Context. Not recommended.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Soft delete. Flags a record as IsDeleted and gets Detached by the Context.
        /// </summary>
        /// <param name="id"></param>
        public virtual void AddDeleteFlag(T entity)
        {
            if (entity != null)
            {
                var entry = this.Context.Entry(entity);
                entry.State = EntityState.Modified;
            }
        }

        public virtual T Attach(T entity)
        {
            return this.Context.Set<T>().Attach(entity);
        }

        public virtual void Detach(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            try
            {
                return this.Context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
