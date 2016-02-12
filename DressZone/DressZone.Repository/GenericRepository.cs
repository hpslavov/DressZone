namespace DressZone.Repository
{
    using Context;
    using DressZone.Repository.Contracts;
    using Models.Shop.Common;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenericRepository<T> : IRepository<T> where T : BaseModel
    {
        public GenericRepository(DressZoneDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DressZoneDbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.Where(x => !x.IsDeleted);
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
                entry.Entity.CreatedOn = DateTime.Now;
                entry.State = EntityState.Added;
            }
            else
            {
                entity.CreatedOn = DateTime.Now;
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entity.ModifiedOn = DateTime.Now;
                this.DbSet.Attach(entity);
            }
            entry.Entity.ModifiedOn = DateTime.Now;
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Hard delete. Deleting the object from the database.
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
        /// Setting IsDeleted property to true, not deleting the real record.
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedOn = DateTime.Now;
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
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
