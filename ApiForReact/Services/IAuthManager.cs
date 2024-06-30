namespace ApiForReact.Services
{
    public interface IAuthManager
    {
        string Authenticate(string username, string password);
    }
}
