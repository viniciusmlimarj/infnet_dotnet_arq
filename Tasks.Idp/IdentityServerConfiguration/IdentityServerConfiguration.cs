using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Tasks.Idp.IdentityServerConfiguration
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
                new ApiResource("Tasks", "Infnet Arquitetura", new string[] { "user", "admin" })
                {
                    ApiSecrets =
                    {
                        new Secret("SuperSenhaDificil".Sha256())
                    },
                    Scopes =
                    {
                        "TasksAPI"
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
                    Name = "TasksAPI",
                    Description = "Escopo da api de tarefas",
                    UserClaims = { "user", "admin" }
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
                    ClientName = "Token",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = { new Secret("Secret".Sha256()) },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "TasksAPI"
                    }

                }
            };
        }
    }
}
