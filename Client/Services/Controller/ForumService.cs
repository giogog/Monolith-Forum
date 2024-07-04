using Client.Contracts;
using Client.Models;

namespace Client.Services;

public class ForumService : IForumService
{
    private readonly IHttpRequestService<Result> _httpRequestService;

    public ForumService(IHttpRequestService<Result> httpRequestService) => _httpRequestService = httpRequestService;
    public async Task<ApiResponse<Result>> ChangeForumState(int forumId, State state) =>
        await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.PATCH, $"Forum/state/{forumId}/{(int)state}", null));
    public async Task<ApiResponse<Result>> ChangeForumStatus(int forumId, Status status) =>
        await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.PATCH, $"Forum/status/{forumId}/{(int)status}", null));

    public async Task<ApiResponse<Result>> CreateForum(CreateForumModelDto createForumDto) =>
        await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.POST, $"Forum/create", createForumDto));

    public async Task<ApiResponse<Result>> DeleteForum(int forumId) =>
        await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.DELETE, $"Forum/delete/{forumId}", null));

    public async Task<ApiResponse<Result>> DeleteForumFromUser(int forumId) =>
        await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.PATCH, $"Forum/delete-from-user/{forumId}", null));
    public async Task<ApiResponse<Result>> UpdateForum(UpdateForumDto updateForumDto) =>
        await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.PUT, $"Forum/update/{updateForumDto.Id}", updateForumDto));

    public async Task<PaginatedApiResponse<IEnumerable<ForumResult>>> GetAllForums(int page) =>
        await _httpRequestService.PaginatedRequestAsync<IEnumerable<ForumResult>>(new ApiRequest(ApiType.GET, $"Forum/{page}", null));

    public async Task<PaginatedApiResponse<IEnumerable<ForumResult>>> GetDeletedForums(int page) =>
        await _httpRequestService.PaginatedRequestAsync<IEnumerable<ForumResult>>(new ApiRequest(ApiType.GET, $"Forum/deleted/{page}", null));

    public async Task<PaginatedApiResponse<IEnumerable<ForumResult>>> GetForums(int page) => 
        await _httpRequestService.PaginatedRequestAsync<IEnumerable<ForumResult>>(new ApiRequest(ApiType.GET, $"Forum/forums/{page}", null));

    public async Task<PaginatedApiResponse<IEnumerable<ForumResult>>> GetPendingForums(int page) => 
        await _httpRequestService.PaginatedRequestAsync<IEnumerable<ForumResult>>(new ApiRequest(ApiType.GET, $"Forum/pending/{page}", null));

}
