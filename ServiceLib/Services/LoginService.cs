

using DomainLib.Entitys;
using DomainLib.Interfaces.Services.User;
using DomainLib.Repository;
using System.Threading.Tasks;

namespace ServiceLib.Services
{
    public class LoginService : ILoginService
    {

        private IUserRepository _repository;
        public LoginService(IUserRepository repository)
        {
            _repository = repository;             
        }
        public async Task<object> FindByLogin(UserEntity user)
        {
            var baseUser = new UserEntity();
            if(user != null && ! string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);

                if(baseUser == null)
                {
                    return null;
                }
                else 
                {
                    return baseUser;
                }
            }
            else 
            {
                return null;
            }
        }
    
    }
}
