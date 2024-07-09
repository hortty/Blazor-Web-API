using BlazorWebApp.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace BlazorWebApp.Interfaces
{
    public interface ICustomAuthStateProvider
    {

        Task LoginAsync(AuthorizedUserDTO user);

        Task LogoutAsync();

    }
}
