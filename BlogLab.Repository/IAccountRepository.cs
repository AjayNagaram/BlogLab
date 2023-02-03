using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogLab.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace BlogLab.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> CreateAsync(ApplicationUserIdentity user,
            CancellationToken token);

        public Task<ApplicationUserIdentity> GetByUsernameAsync(string normalizedUsername, 
            CancellationToken token);
    }
}
