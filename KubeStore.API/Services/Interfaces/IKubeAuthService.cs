using KubeStore.API.DTO;

namespace KubeStore.API.Services.Interfaces
{
    public interface IKubeAuthService
    {
        Task<AuthMessageResponse> RegisterUserAsync(RegisterVM registerVM);
        Task<AuthMessageResponse> LoginUserAsync(LoginVM loginVM);
        Task<AuthMessageResponse> LogoutUserAsync();
    }
}
