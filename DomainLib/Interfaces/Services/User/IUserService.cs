using DomainLib.Entitys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainLib.Interfaces.Services.User
{
    interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> Post(UserEntity user);
        Task<UserEntity> Put(UserEntity user);
        Task<bool> Delete(Guid id);
    }
}
