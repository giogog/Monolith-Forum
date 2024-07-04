using Client.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Client.Contracts
{
    public interface IAuthenticationService
    {
        public void MarkUserAsAuthenticated(ICollection<Claim> claims);
        Task<AuthenticationState> GetAuthenticationStateAsync();
        Task Logout();
    }
}