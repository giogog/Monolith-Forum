using System.Net.Http.Headers;
using System.Security.Claims;

namespace Client.Contracts;

public interface IJwtService
{
    AuthenticationHeaderValue SetAuthorizationHeader(string token);
    string? GetRoleFromToken(string token);
    Task SetAuthToken(string token);
    Task<string> GetAuthToken();
    string GetRoleFromClaims(IEnumerable<Claim> claims);
    string GetUsernameFromClaims(IEnumerable<Claim> claims);
    int GetIdFromClaims(IEnumerable<Claim> claims);
    IEnumerable<Claim>? GetClaimsFromToken(string token);
}
