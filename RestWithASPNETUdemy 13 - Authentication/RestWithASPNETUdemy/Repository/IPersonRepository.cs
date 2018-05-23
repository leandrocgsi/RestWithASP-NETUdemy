using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Base;

namespace RestWithASPNETUdemy.Business
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
