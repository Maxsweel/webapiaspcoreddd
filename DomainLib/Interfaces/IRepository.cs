using DomainLib.Entitys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainLib.Interfaces
{
    //Interface de repository de entitys
    public interface IRepository<T> where T:BaseEntity
    {
        //grud
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<T> InsertAsync(T Item);
        Task<T> UpdateAsync(T Item);
        Task<bool> DeleteAsync(Guid id);

    }
}
