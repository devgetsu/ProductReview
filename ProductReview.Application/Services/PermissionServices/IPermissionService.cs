using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.PermissionServices
{
    public interface IPermissionService
    {
        public Task<Permission> CreatePermission(CreatePermissionDTO perDTO);
        public Task<Permission> UpdatePermissionByName(string name, CreatePermissionDTO perDTO);
        public Task<Permission> UpdatePermissionById(int id, CreatePermissionDTO perDTO);
        public Task<bool> DeletePermissionById(int id);
        public Task<bool> DeletePermissionByName(string name);
        public Task<Permission> GetPermissionById(int id);
        public Task<Permission> GetPermissionByName(string name);
        public Task<IEnumerable<Permission>> GetAllPermissions();
    }
}
