using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace SpotifyLite.Idp.IdentityServerConfiguration
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("Spotify Lite", "Infnet Arquitetura", new string[] { "user", "admin" })
                {
                    ApiSecrets =
                    {
                        new Secret("SuperSenhaDificil".Sha256())
                    },
                    Scopes =
                    {
                        "SpotifyLite-API"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope
                {
                    Name = "SpotifyAPI",
                    Description = "Scope for API Spotify",
                    UserClaims = { "spotify-user", "spotify-admin" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client()
                {
                    ClientId = "a77fef41-e95c-4cdd-8ff3-38d0e32f33ef",
                    ClientName = "Spotify Service Token",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = { new Secret("SpotifySecret".Sha256()) },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SpotifyAPI"
                    }

                }
            };
        }
    }
}
