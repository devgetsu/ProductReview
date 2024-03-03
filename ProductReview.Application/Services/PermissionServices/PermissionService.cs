using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.PermissionServices
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _repos;

        public PermissionService(IPermissionRepository repos)
        {
            _repos = repos;
        }

        public async Task<Permission> CreatePermission(CreatePermissionDTO perDTO)
        {
            var checker = await _repos.GetByAny(x => x.Name == perDTO.Name);
            if (checker != null)
            {
                return new Permission() { Name = "Permission is already exists" };
            }
            var x = await _repos.Create(new Permission { Name = perDTO.Name });

            return x;
        }

        public async Task<bool> DeletePermissionById(int id)
        {
            var y = await _repos.Delete(x => x.Id == id);
            return y;
        }

        public async Task<bool> DeletePermissionByName(string name)
        {
            var s = await _repos.Delete(x => x.Name == name);
            return s;
        }

        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            var x = await _repos.GetAll();
            return x;
        }

        public async Task<Permission> GetPermissionById(int id)
        {
            var s = await _repos.GetByAny(x => x.Id == id);
            return s;
        }

        public async Task<Permission> GetPermissionByName(string name)
        {
            var s = await _repos.GetByAny(x => x.Name == name);
            return s;
        }

        public async Task<Permission> UpdatePermissionById(int id, CreatePermissionDTO perDTO)
        {
            var s = await _repos.GetByAny(x => x.Id == id);
            if (s == null)
            {
                return new Permission() { Name = "Permission is not found" };
            }
            else
            {
                if (s.Name != perDTO.Name && !_repos.GetAll().Result.Any(x => x.Name == perDTO.Name))
                {
                    s.Name = perDTO.Name;
                }
                else
                {
                    return new Permission() { Name = "Name is already exists" };
                }
                var res = await _repos.Update(s);
                return res;
            }
        }

        public async Task<Permission> UpdatePermissionByName(string name, CreatePermissionDTO perDTO)
        {
            var s = await _repos.GetByAny(x => x.Name == name);
            if (s == null)
            {
                return new Permission() { Name = "Permission is not foun" };
            }
            else
            {
                if (s.Name != perDTO.Name && !_repos.GetAll().Result.Any(x => x.Name == perDTO.Name))
                {
                    s.Name = perDTO.Name;
                }
                else
                {
                    return new Permission() { Name = "Name is already exists" };
                }
                var res = await _repos.Update(s);
                return res;
            }
        }
    }
}
