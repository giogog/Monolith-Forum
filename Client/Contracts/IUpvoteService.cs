using Client.Models;

namespace Client.Contracts;

public interface IUpvoteService
{
    Task<ApiResponse<Result>> Upvote(int topicId);
}
