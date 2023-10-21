using kubestore.DTO;
using Microsoft.AspNetCore.Identity;

namespace kubestore.Services
{
	public class KubeRoleService : IKubeRoleService
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		public KubeRoleService(RoleManager<IdentityRole> roleManager) 
		{ 
			_roleManager = roleManager;
		}

		public async Task<RoleMessageResponse> AddRole(IdentityRole role)
		{
			IdentityResult result = await _roleManager.CreateAsync(role);

			return new RoleMessageResponse
			{
				IsSuccess = result.Succeeded,
				Message = result.ToString(),
				Errors = result.Errors.Select(e => e.Description)
			};
		}

		public IdentityRole GetRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public List<IdentityRole> GetRoles()
		{
			return _roleManager.Roles.ToList();
		}

		public RoleMessageResponse RemoveRole(string roleName)
		{
			throw new NotImplementedException();
		}
	}
}
