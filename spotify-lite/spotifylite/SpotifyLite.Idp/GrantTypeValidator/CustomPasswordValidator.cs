using IdentityModel;
using IdentityServer4.Validation;
using SpotifyLite.Domain.User.Repository;
using System.Threading.Tasks;

namespace SpotifyLite.Idp.GrantTypeValidator
{
    public class CustomPasswordValidator : IResourceOwnerPasswordValidator
    {
        public CustomPasswordValidator(IUserRepository repository)
        {
            Repository = repository;
        }

        public IUserRepository Repository { get; }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var password = context.Password;
            var username = context.UserName;

            var user = await this.Repository.GetUserByPassword(username, password); 

            if (user != null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }
        }
    }
}
