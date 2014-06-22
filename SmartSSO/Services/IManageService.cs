namespace SmartSSO.Services
{
    public interface IManageService
    {
        bool Login(string username, string password);

        void Logout(string username);
    }
}