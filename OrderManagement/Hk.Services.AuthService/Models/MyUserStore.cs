using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Hk.Services.AuthService.Models
{
    //public class MyUserStore : IUserStore<User>, IUserPasswordStore<User>
    //{
    //    private readonly MyDbContext _context;

    //    public MyUserStore(MyDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public void Dispose()
    //    {
    //        // implement your desired logic
    //    }

    //    // Following 3 methods are needed for IUserPasswordStore
    //    public Task<string> GetPasswordHashAsync(AppUser user)
    //    {
    //        // something like this:
    //        return Task.FromResult(user.Password_hash);
    //    }

    //    public Task<bool> HasPasswordAsync(AppUser user)
    //    {
    //        return Task.FromResult(user.Password_hash != null);
    //    }

    //    public Task SetPasswordHashAsync(AppUser user, string passwordHash)
    //    {
    //        user.Password_hash = passwordHash;
    //        return Task.FromResult(0);
    //    }

    //    public Task CreateAsync(User user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task UpdateAsync(User user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task DeleteAsync(User user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<User> IUserStore<User, string>.FindByIdAsync(string userId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<User> IUserStore<User, string>.FindByNameAsync(string userName)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}