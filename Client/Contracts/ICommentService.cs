using Client.Models;

namespace Client.Contracts;

public interface ICommentService
{
    Task<PaginatedApiResponse<IEnumerable<CommentResult>>> GetComments(int topicId, int page);
    Task<ApiResponse<Result>> AddComment(AddCommentModelDto addCommentModelDto);
    Task<ApiResponse<Result>> AddReply(AddCommentModelDto addCommentModelDto);
    Task<ApiResponse<Result>> EditComment(int commentId,UpdateCommentModelDto addCommentModelDto);
    Task<ApiResponse<Result>> DeleteComment(int commentId);
    Task<ApiResponse<IEnumerable<CommentResult>>> GetAllComments(int topicId);
}
