using Client.Models;

namespace Client.Contracts;

public interface IForumService
{
    Task<PaginatedApiResponse<IEnumerable<ForumResult>>> GetAllForums(int page);
    Task<PaginatedApiResponse<IEnumerable<ForumResult>>> GetPendingForums(int page);
    Task<PaginatedApiResponse<IEnumerable<ForumResult>>> GetDeletedForums(int page);
    Task<PaginatedApiResponse<IEnumerable<ForumResult>>> GetForums(int page);
    Task<ApiResponse<Result>> CreateForum(CreateForumModelDto createForumDto);
    Task<ApiResponse<Result>> UpdateForum(UpdateForumDto updateForumDto);
    Task<ApiResponse<Result>> DeleteForum(int forumId);
    Task<ApiResponse<Result>> DeleteForumFromUser(int forumId);
    Task<ApiResponse<Result>> ChangeForumState(int forumId,State state);
    Task<ApiResponse<Result>> ChangeForumStatus(int forumId,Status status);


}
