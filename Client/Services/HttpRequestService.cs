using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
//using System.Text.Json;

namespace Client.Services;

public class HttpRequestService<T> : IHttpRequestService<T>
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IJwtService _jwtService;
    private readonly IAuthenticationService _authService;
    private readonly ApiAuthenticationStateProvider _authStateProvider;
    private readonly string _url;
    public HttpRequestService(IHttpClientFactory httpClientFactory,IConfiguration config, IJwtService jwtService,IAuthenticationService authService, ApiAuthenticationStateProvider authStateProvider)
    {
        _authStateProvider = authStateProvider;
        this._jwtService = jwtService;
        this._authService = authService;
        _httpClientFactory = httpClientFactory;
        _url = config["ApiUrl"];

    }

    private async Task<HttpResponseMessage> BuildUpRequest(ApiRequest request)
    {
        var loginAsJson = JsonConvert.SerializeObject(request.Data);
        var requestUrl = $"{_url}{request.Endpoint}";
        HttpClient client = _httpClientFactory.CreateClient(requestUrl);

        var authState = await _authService.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            var token = await _jwtService.GetAuthToken();
            client.DefaultRequestHeaders.Authorization = _jwtService.SetAuthorizationHeader(token);
        }


        var headers = client.DefaultRequestHeaders;
        HttpRequestMessage message = new();

        message.RequestUri = new Uri(requestUrl);

        if (request.Data != null)
        {
            message.Content = new StringContent(loginAsJson, Encoding.UTF8, "application/json");
        }

        HttpResponseMessage apiResponse = new();

        switch (request.ApiType)
        {
            case ApiType.POST:
                message.Method = HttpMethod.Post;
                break;
            case ApiType.PUT:
                message.Method = HttpMethod.Put;
                break;
            case ApiType.PATCH:
                message.Method = HttpMethod.Patch;
                break;
            case ApiType.DELETE:
                message.Method = HttpMethod.Delete;
                break;
            default:
                message.Method = HttpMethod.Get;
                break;
        }

        apiResponse = await client.SendAsync(message);
        return apiResponse;
    }

    public async Task<PaginatedApiResponse<T>> PaginatedRequestAsync<T>(ApiRequest request)
    {
        try
        {
            var apiResponse = await BuildUpRequest(request);
            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new PaginatedApiResponse<T>() { IsSuccess = false, Message = "Not Found",StatusCode = (int)HttpStatusCode.NotFound };
                case HttpStatusCode.Forbidden:
                    return new PaginatedApiResponse<T>() { IsSuccess = false, Message = "Access denied", StatusCode = (int)HttpStatusCode.Forbidden };
                case HttpStatusCode.Unauthorized:
                    _authService.Logout();
                    return new PaginatedApiResponse<T>() { IsSuccess = false, Message = "Unauthorized", StatusCode = (int)HttpStatusCode.Unauthorized };
                case HttpStatusCode.InternalServerError:
                    return new PaginatedApiResponse<T>() { IsSuccess = false, Message = "Internal server error", StatusCode = (int)HttpStatusCode.InternalServerError };
                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<PaginatedApiResponse<T>>(apiContent);
                    return result;
            }

        }
        catch (Exception ex)
        {
            PaginatedApiResponse<T> result = new()
            {
                Message = ex.Message,
                IsSuccess = false
            };

            return result;
        }
    }

    public async Task<ApiResponse<T>> RequestAsync<T>(ApiRequest request)
    {

        try
        { 
             var apiResponse = await BuildUpRequest(request); 
            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new ApiResponse<T>() { IsSuccess = false, Message = "Not Found", StatusCode = (int)HttpStatusCode.NotFound };
                case HttpStatusCode.Forbidden:
                    return new ApiResponse<T>() { IsSuccess = false, Message = "Access denied", StatusCode = (int)HttpStatusCode.Forbidden };
                case HttpStatusCode.Unauthorized:
                    return new ApiResponse<T>() { IsSuccess = false, Message = "Unauthorized", StatusCode = (int)HttpStatusCode.Unauthorized };
                case HttpStatusCode.InternalServerError:
                    return new ApiResponse<T>() { IsSuccess = false, Message = "Internal server error", StatusCode = (int)HttpStatusCode.InternalServerError };
                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponse<T>>(apiContent);
                    return result;
            }

        }
        catch (Exception ex)
        {
            ApiResponse<T> result = new()
            {
                Message = ex.Message,
                IsSuccess = false
            };

            return result;
        }
    }
}

