using Client.Contracts;
using Client.Models;

namespace Client.Services;

public class UserService : IUserService
{
    private readonly IHttpRequestService<Result> _request;
    public UserService(IHttpRequestService<Result> request)
    {
        _request = request;
    }
    public async Task<ApiResponse<AuthorizedUserResult>> GetUserWithEmail(string email)
    {
        return await _request.RequestAsync<AuthorizedUserResult>(new ApiRequest(ApiType.GET,$"User/with-email/{email}",null));
    }
    public async Task<ApiResponse<AuthorizedUserResult>> GetAuthorizedUserData(int id)
    {
        return await _request.RequestAsync<AuthorizedUserResult>(new ApiRequest(ApiType.GET, $"User/with-id/{id}", null));
    }
    public async Task<ApiResponse<Result>> UpdateAuthrizedUserData(int id, AuthorizedUserResult authorizedUserResult)
    {
        return await _request.RequestAsync<Result>(new ApiRequest(ApiType.PUT, $"User/with-id/{id}", authorizedUserResult));
    }
    public async Task<ApiResponse<Result>> BanUser(int id, Ban ban)
    {
        return await _request.RequestAsync<Result>(new ApiRequest(ApiType.PATCH, $"User/{id}/{(int)ban}", null));
    }
    public async Task<PaginatedApiResponse<IEnumerable<AuthorizedUserResult>>> GetUsers(int page)
    {
        return await _request.PaginatedRequestAsync<IEnumerable<AuthorizedUserResult>>(new ApiRequest(ApiType.GET, $"User/users/{page}", null));
    }
    public async Task<ApiResponse<Result>> ChangeUserModeratorStatus(int userId)
    {
        return await _request.RequestAsync<Result>(new ApiRequest(ApiType.POST, $"User/moderator/{userId}", null));
    }

}