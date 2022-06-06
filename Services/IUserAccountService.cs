using BlazorApp.Data;

namespace BlazorApp.Services
{
    public interface IUserAccountService
    {
        Task<User?> GetUser(User user);

        User AddOrUpdateUser(User user);
    }
}
