using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BlazorWebApp.Util;
using System;
using BlazorWebApp.DTOs;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using BlazorWebApp.Interfaces;

namespace BlazorWebApp.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider, ICustomAuthStateProvider
    {
        private const string USER_SESSION_OBJECT_KEY = "user_session_obj";

        private ProtectedSessionStorage protectedSessionStore;
        private HttpClient _httpClient;
        public CustomAuthStateProvider(ProtectedSessionStorage protectedSessionStore, HttpClient _httpClient) =>
                (this.protectedSessionStore, this._httpClient) = (protectedSessionStore, _httpClient);

        private AuthorizedUserDTO Usuario { get; set; }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthorizedUserDTO userSession = await GetUserSession();

            if (userSession != null)
            {
                return await GenerateAuthenticationState(userSession);
            }
           
            
            return await GenerateEmptyAuthenticationState();
        }

        public async Task<AuthorizedUserDTO> GetUserSession()
        {
            try
            {
                if (Usuario != null)
                return Usuario;

            var localUserJson = await protectedSessionStore.GetAsync<string>(USER_SESSION_OBJECT_KEY);

            if (string.IsNullOrEmpty(localUserJson.Value))
                return null;

                return RefreshUserSession(JsonConvert.DeserializeObject<AuthorizedUserDTO>(localUserJson.Value));
            }
            catch
            {
                 await LogoutAsync();
                return null;
            }
        }

        private async Task SetUserSession(AuthorizedUserDTO user)
        {

            RefreshUserSession(user);

            await protectedSessionStore.SetAsync(USER_SESSION_OBJECT_KEY, JsonConvert.SerializeObject(user));
        }

      

        private AuthorizedUserDTO RefreshUserSession(AuthorizedUserDTO user) => Usuario = user;

        private Task<AuthenticationState> GenerateAuthenticationState(AuthorizedUserDTO user)
        {

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Hash, user.Token),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.UserData, user.ShoppingCartId.ToString())
            }, "apiauth_type");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            Thread.CurrentPrincipal = claimsPrincipal;
            return Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        private Task<AuthenticationState> GenerateEmptyAuthenticationState() => Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));

        public async Task LoginAsync(AuthorizedUserDTO user)
        {

            await SetUserSession(user);

            NotifyAuthenticationStateChanged(GenerateAuthenticationState(user));
        }

     

        public async Task LogoutAsync()
        {
            try
            {

                await SetUserSession(null);

                NotifyAuthenticationStateChanged(GenerateEmptyAuthenticationState());
            }
            catch(Exception ex)
            {
                NotifyAuthenticationStateChanged(GenerateEmptyAuthenticationState());
            }
        }


    }
}