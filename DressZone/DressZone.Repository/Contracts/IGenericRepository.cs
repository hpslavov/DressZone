﻿namespace DressZone.Repository.Contracts
{
    using Models.Account;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGenericRepository<T> : IDisposable where T : class
    {

        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void AddDeleteFlag(T entity);

        T Attach(T entity);

        void Detach(T entity);

        int SaveChanges();

        void PartialModifiedUpdated(T entity);
    }
}
