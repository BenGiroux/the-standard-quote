using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace ContractorJobBuilderV2.SharedKernel.Interfaces
{
    public interface IRepository<TId> where TId : ValueObject
    {
        Task<T> GetByIdAsync<T>(TId id) where T : BaseEntity<TId>, IAggregateRoot;
        Task<T> GetByIdAsync<T>(ISpecification<T> spec) where T : BaseEntity<TId>, IAggregateRoot;
        Task<List<T>> ListAsync<T>() where T : BaseEntity<TId>, IAggregateRoot;
        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : BaseEntity<TId>, IAggregateRoot;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
        Task UpdateAsync<T>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
        Task DeleteAsync<T>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
    }
}