using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repos;

        public RoleService(IRoleRepository repos)
        {
            _repos = repos;
        }

        public async Task<Role> CreateRole(CreateRoleDTO role)
        {

            var x = _repos.Create(new Role { Name = role.Name }).Result;

            foreach (var p in roleDTO.Permissions)
            {
                _context.RolePermissions.Add(new RolePermission()
                {
                    RoleId = entry.Entity.Id,
                    PermissionId = p
                });
                await _context.SaveChangesAsync();
            }

            return Ok(entry.Entity);
        }

        public Task<bool> DeleteRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoleByName(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRoleByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateRoleById(CreateRoleDTO role)
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateRoleByName(CreateRoleDTO role)
        {
            throw new NotImplementedException();
        }
    }
}
