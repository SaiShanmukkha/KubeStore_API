using KubeStore.API.DTO;
using Microsoft.AspNetCore.Identity;

namespace KubeStore.API.Services.Interfaces
{
    public interface IKubeRoleService
    {
        public List<IdentityRole> GetRoles();
        public IdentityRole GetRole(string roleName);
        public Task<RoleMessageResponse> AddRole(IdentityRole role);
        public RoleMessageResponse RemoveRole(string roleName);
    }
}
