using Client.Models;

namespace Client.Contracts;

public interface IHttpRequestService<T>
{

    Task<ApiResponse<T>> RequestAsync<T>(ApiRequest request);
    Task<PaginatedApiResponse<T>> PaginatedRequestAsync<T>(ApiRequest request);

}
