using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.RoleServices
{
    public interface IRoleService
    {
        public Task<Role> CreateRole(CreateRoleDTO role);
        public Task<Role> UpdateRoleByName(CreateRoleDTO role);
        public Task<Role> UpdateRoleById(CreateRoleDTO role);
        public Task<bool> DeleteRoleById(int id);
        public Task<bool> DeleteRoleByName(int id);
        public Task<Role> GetRoleById(int id);
        public Task<Role> GetRoleByName(string name);
        public Task<IEnumerable<Role>> GetAllRoles();

    }
}
