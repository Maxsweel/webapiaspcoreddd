using DomainLib.Entitys;
using System.Threading.Tasks;

namespace DomainLib.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity user);
    }
}
