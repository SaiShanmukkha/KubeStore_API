using kubestore.DTO;

namespace kubestore.Services
{
    public interface IKubeAuthService
    {
        Task<AuthMessageResponse> RegisterUserAsync(RegisterVM registerVM);
        Task<AuthMessageResponse> LoginUserAsync(LoginVM loginVM);
        Task<AuthMessageResponse> LogoutUserAsync();
    }
}
