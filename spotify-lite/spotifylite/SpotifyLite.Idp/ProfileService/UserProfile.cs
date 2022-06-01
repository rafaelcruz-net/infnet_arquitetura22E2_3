using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpotifyLite.Idp.ProfileService
{
    public class UserProfile : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = context.Subject.GetSubjectId();

            var claims = new List<Claim>()
            {
                new Claim("name", "LoremIpsumUser"),
                new Claim("email", "xpto@xpto.com"),
                new Claim("role", "spotify-user"),
            };

            context.IssuedClaims = claims;
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
