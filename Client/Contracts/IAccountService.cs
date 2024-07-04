using Client.Models;

namespace Client.Contracts
{
    public interface IAccountService
    {
        Task<ApiResponse<RegisterResult>> Register(RegisterModelDto registerModel);
        Task<ApiResponse<LoginResult>> Login(LoginModel loginModel);
        Task<ApiResponse<Result>> RequestPasswordReset(string email);
        Task<ApiResponse<Result>> PasswordReset(ResetPasswordDto resetPasswordDto);

        Task<ApiResponse<RegisterResult>> ResendConfiramtionsMail(string username);
    }
}
