using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
