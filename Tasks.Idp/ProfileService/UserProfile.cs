using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Tasks.Domain.User.Repository;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tasks.Idp.ProfileService
{
    public class UserProfile : IProfileService
    {
        public UserProfile(IUserRepository repository)
        {
            Repository = repository;
        }

        public IUserRepository Repository { get; }


        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = context.Subject.GetSubjectId();

            var user = await this.Repository.GetById(new Guid(id)); 
            
            var claims = new List<Claim>()
            {
                new Claim("name", user.Name),
                new Claim("email", user.Email.Value),
                new Claim("role", "tasks-user"),
            };

            context.IssuedClaims = claims;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
