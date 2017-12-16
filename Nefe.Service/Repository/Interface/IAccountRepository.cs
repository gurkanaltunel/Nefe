namespace Nefe.Service.Repository.Interface
{
    public interface IAccountRepository
    {
        bool Login(string email, string password);
    }
}
