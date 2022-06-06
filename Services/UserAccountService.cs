using BlazorApp.Data;

namespace BlazorApp.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly HAMMERContext _context;
        public UserAccountService(HAMMERContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public User AddOrUpdateUser(User user)
        {
            var model = user.Id > 0 ? _context.User.Where(x => x.Id == user.Id).FirstOrDefault() : user;
            if (model?.Id > 0)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.UserName = user.UserName;
                model.Password = user.Password;
                model.Role = user.Role;
            }
            else
            {
                _context.User.Add(model);
            }

            _context.SaveChanges();
            return model;
        }

        public async Task<User?> GetUser(User user)
        {
            var dbUser = await _context.User.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);
            return dbUser;
        }

    }
}
