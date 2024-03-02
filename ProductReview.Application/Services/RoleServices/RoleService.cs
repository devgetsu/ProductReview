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
        private readonly IRolePermissionRepos _reposPerRol;

        public RoleService(IRoleRepository repos, IRolePermissionRepos rePerRol)
        {
            _repos = repos;
            _reposPerRol = rePerRol;
        }

        public async Task<Role> CreateRole(CreateRoleDTO roleDTO)
        {

            var x = _repos.Create(new Role { Name = roleDTO.Name }).Result;

            foreach (var p in roleDTO.Permissions)
            {
                await _reposPerRol.Create(new RolePermission()
                {
                    RoleId = x.Id,
                    PermissionId = p
                });
            }

            return x;
        }

        public async Task<bool> DeleteRoleById(int id)
        {
            var y = await _repos.Delete(x => x.Id == id);
            return y;
        }

        public async Task<bool> DeleteRoleByName(string name)
        {
            var s = await _repos.Delete(x => x.Name == name);
            return s;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {

            var x = await _repos.GetAll();
            return x;
        }

        public async Task<Role> GetRoleById(int id)
        {
            var s = await _repos.GetByAny(x => x.Id == id);
            return s;
        }

        public async Task<Role> GetRoleByName(string name)
        {
            var s = await _repos.GetByAny(x => x.Name == name);
            return s;
        }

        public async Task<Role> UpdateRoleById(int id, CreateRoleDTO roleDTO)
        {
            var s = await _repos.GetByAny(x => x.Id == id);
            if (s == null)
            {
                return new Role() { };
            }
            else
            {
                var res = await _repos.Update(new Role { Name = roleDTO.Name });
                return res;
            }
        }

        public async Task<Role> UpdateRoleByName(string name, CreateRoleDTO roleDTO)
        {
            var s = await _repos.GetByAny(x => x.Name == name);
            if (s == null)
            {
                return new Role() { };
            }
            else
            {
                var res = await _repos.Update(new Role { Name = roleDTO.Name });
                return res;
            }
        }
    }
}
