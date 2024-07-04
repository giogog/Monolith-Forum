using Client.Contracts;
using Client.Models;

namespace Client.Services;

public class CommentService:ICommentService
{
    private readonly IHttpRequestService<Result> _httpRequestService;

    public CommentService(IHttpRequestService<Result> httpRequestService)
    {
        _httpRequestService = httpRequestService;
    }

    public async Task<PaginatedApiResponse<IEnumerable<CommentResult>>> GetComments(int topicId,int page)
    {
        return await _httpRequestService.PaginatedRequestAsync<IEnumerable<CommentResult>>(new ApiRequest(ApiType.GET, $"Comment/paged/{topicId}", page));
    }

    public async Task<ApiResponse<IEnumerable<CommentResult>>> GetAllComments(int topicId)
    {
        return await _httpRequestService.RequestAsync<IEnumerable<CommentResult>>(new ApiRequest(ApiType.GET, $"Comment/{topicId}", null));
    }
    public async Task<ApiResponse<Result>> AddComment(AddCommentModelDto addCommentModelDto)
    {
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.POST, "Comment/create",addCommentModelDto));
    }

    public async Task<ApiResponse<Result>> AddReply(AddCommentModelDto addCommentModelDto)
    {
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.POST, "Reply", addCommentModelDto));
    }

    public async Task<ApiResponse<Result>> DeleteComment(int commentId)
    {
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.DELETE, $"Comment/delete/{commentId}", null));
    }

    public async Task<ApiResponse<Result>> EditComment(int commentId, UpdateCommentModelDto addCommentModelDto)
    {
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.PUT, $"Comment/update/{commentId}", addCommentModelDto));
    }
}
