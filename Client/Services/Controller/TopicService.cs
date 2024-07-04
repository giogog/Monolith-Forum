using Client.Contracts;
using Client.Models;

namespace Client.Services;

public class TopicService : ITopicService
{
    private readonly IHttpRequestService<Result> _httpRequestService;

    public TopicService(IHttpRequestService<Result> httpRequestService)
    {
        _httpRequestService = httpRequestService;
    }

    public async Task<ApiResponse<Result>> AddTopic(TopicModelDto createTopicModelDto)
    {
    
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.POST, $"Topic/create", createTopicModelDto));
    }



    public async Task<ApiResponse<TopicResult>> GetTopicById(int id)
    {
        return await _httpRequestService.RequestAsync<TopicResult>(new ApiRequest(ApiType.GET, $"Topic/topic/{id}", null));
    }

    public async Task<PaginatedApiResponse<IEnumerable<TopicResult>>> GetTopicsByForum(int forumId,int page)
    {
        return await _httpRequestService.PaginatedRequestAsync<IEnumerable<TopicResult>>(new ApiRequest(ApiType.GET, $"Topic/{forumId}/{page}",null));
    }
    public async Task<PaginatedApiResponse<IEnumerable<TopicResult>>> GetAllTopics(int page)
    {
        return await _httpRequestService.PaginatedRequestAsync<IEnumerable<TopicResult>>(new ApiRequest(ApiType.GET, $"Topic/topics/{page}", null));
    }

    public async Task<PaginatedApiResponse<IEnumerable<TopicResult>>> GetPendingTopics(int page)
    {
        return await _httpRequestService.PaginatedRequestAsync<IEnumerable<TopicResult>>(new ApiRequest(ApiType.GET, $"Topic/pending/{page}", null));
    }
    public async Task<PaginatedApiResponse<IEnumerable<TopicResult>>> GetTopicsWithUser(int userId, int page)
    {
        return await _httpRequestService.PaginatedRequestAsync<IEnumerable<TopicResult>>(new ApiRequest(ApiType.GET, $"Topic/user/{userId}/{page}", null));
    }

    public async Task<ApiResponse<Result>> EditTopic(UpdateTopicModelDto updateTopicModelDto)
    {
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.PUT, $"Topic/update/{updateTopicModelDto.Id}", updateTopicModelDto));
    }
    public async Task<ApiResponse<Result>> DeleteTopic(int topicId)
    {
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.DELETE, $"Topic/delete/{topicId}", null));
    }
    public async Task<ApiResponse<Result>> ChangeTopicStatus(int topicId,Status status)
    {
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.PATCH, $"Topic/change-topic-status/{topicId}/{(int)status}", null));
    }
    public async Task<ApiResponse<Result>> ChangeTopicState(int topicId, State state)
    {
        return await _httpRequestService.RequestAsync<Result>(new ApiRequest(ApiType.PATCH, $"Topic/change-topic-state/{topicId}/{(int)state}", null));
    }

}
