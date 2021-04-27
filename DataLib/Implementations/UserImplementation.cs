using DataLib.Context;
using DataLib.Repository;
using DomainLib.Entitys;
using DomainLib.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLib.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(DataContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}