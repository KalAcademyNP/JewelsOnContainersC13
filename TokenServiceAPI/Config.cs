using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenServiceAPI
{
    public static class Config
    {
		public static IEnumerable<ApiScope> Apis()
		{
			return new List<ApiScope>
				{
					new ApiScope("basket", "Shopping Cart Api"),
					new ApiScope("order", "Ordering Api")
				};
		}
		public static IEnumerable<ApiResource> GetAllApiResources()
		{
			return new List<ApiResource>
				{
					 new ApiResource("basket", "Shopping Cart Api"),
					 new ApiResource("order", "Ordering Api"),
				};
		}

		public static Dictionary<string, string> GetUrls(IConfiguration configuration)
		{
			Dictionary<string, string> urls = new Dictionary<string, string>();

			urls.Add("Mvc", configuration.GetValue<string>("MvcClient"));
			urls.Add("BasketApi", configuration.GetValue<string>("BasketApiClient"));
			urls.Add("OrderApi", configuration.GetValue<string>("OrderApiClient"));

			return urls;

		}

		public static IEnumerable<Client> GetClients(Dictionary<string, string> clientUrls)
		{
			return new List<Client>
				{
	                //implicit flow grant type
	                new Client
					{
						ClientId = "mvc",
						ClientName = "MVC Client",
						AllowedGrantTypes = GrantTypes.Hybrid, //means user is redirected to identity server
	                    ClientSecrets = new [] { new Secret("secret".Sha256())},
						RedirectUris = {$"{clientUrls["Mvc"]}/signin-oidc"},
						PostLogoutRedirectUris={$"{clientUrls["Mvc"]}/signout-callback-oidc"},
						AllowAccessTokensViaBrowser = false,
						AllowOfflineAccess = true,
						RequireConsent = false,
						RequirePkce = false,
						AlwaysIncludeUserClaimsInIdToken = true,
						AllowedScopes = new List<string>
						{
							IdentityServerConstants.StandardScopes.OpenId,
							IdentityServerConstants.StandardScopes.Profile,
							"order",
							"basket",

						}
					},
					new Client
					{
						ClientId = "basketswaggerui",
						ClientName = "Basket Swagger UI",
						AllowedGrantTypes = GrantTypes.Implicit,
						AllowAccessTokensViaBrowser = true,
						RequireConsent = false,
						RequirePkce = false,
						RedirectUris = {$"{clientUrls["BasketApi"]}/swagger/oauth2-redirect.html" },
						PostLogoutRedirectUris = {$"{clientUrls["BasketApi"]}/signout-callback-oidc"},

						 AllowedScopes = new List<string>
						 {
							IdentityServerConstants.StandardScopes.OpenId,
							IdentityServerConstants.StandardScopes.Profile,
							"basket"
						 }
					},
					new Client
					{
						ClientId = "orderswaggerui",
						ClientName = "Order Swagger UI",
						AllowedGrantTypes = GrantTypes.Implicit,
						AllowAccessTokensViaBrowser = true,
						RequirePkce = false,

						RedirectUris = { $"{clientUrls["OrderApi"]}/swagger/o2c.html" },
						PostLogoutRedirectUris = { $"{clientUrls["OrderApi"]}/swagger/" },

						 AllowedScopes = new List<string>
						 {

							"order"
						 }
					}
				};

		}

		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>()
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
               // new IdentityResources.Email()
            };
		}

	}
}
