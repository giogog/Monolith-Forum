using Client.Contracts;
using Client.Models;

namespace Client.Services;

public class UpvoteService : IUpvoteService
{
    private readonly IHttpRequestService<Result> _httpRequestService;

    public UpvoteService(IHttpRequestService<Result> httpRequestService)
    {
        _httpRequestService = httpRequestService;
    }



    public async Task<ApiResponse<Result>> Upvote(int topicId)
    {
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.POST, $"Upvote/{topicId}", null));
    }
}
