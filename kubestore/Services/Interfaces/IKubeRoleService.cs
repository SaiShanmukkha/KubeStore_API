using kubestore.DTO;
using Microsoft.AspNetCore.Identity;

namespace kubestore.Services.Interfaces
{
    public interface IKubeRoleService
    {
        public List<IdentityRole> GetRoles();
        public IdentityRole GetRole(string roleName);
        public Task<RoleMessageResponse> AddRole(IdentityRole role);
        public RoleMessageResponse RemoveRole(string roleName);
    }
}
