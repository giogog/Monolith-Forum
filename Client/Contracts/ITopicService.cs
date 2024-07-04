using Client.Models;

namespace Client.Contracts;

public interface ITopicService
{
    Task<ApiResponse<Result>> AddTopic(TopicModelDto createTopicModelDto);
    Task<ApiResponse<Result>> EditTopic(UpdateTopicModelDto createTopicModelDto);
    Task<ApiResponse<Result>> DeleteTopic(int topicId);
    Task<ApiResponse<Result>> ChangeTopicStatus(int topicId, Status status);
    Task<ApiResponse<Result>> ChangeTopicState(int topicId, State state);
    Task<PaginatedApiResponse<IEnumerable<TopicResult>>> GetTopicsByForum(int forumId,int page);
    Task<PaginatedApiResponse<IEnumerable<TopicResult>>> GetAllTopics(int page);
    Task<PaginatedApiResponse<IEnumerable<TopicResult>>> GetTopicsWithUser(int userId, int page);
    Task<PaginatedApiResponse<IEnumerable<TopicResult>>> GetPendingTopics(int page);
    Task<ApiResponse<TopicResult>> GetTopicById(int id);
}
