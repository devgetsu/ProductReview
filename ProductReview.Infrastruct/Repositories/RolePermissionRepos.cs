using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Infrastruct.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Infrastruct.Repositories
{
    public class RolePermissionRepos : BaseRepository<RoleRepository>, IRolePermissionRepos
    {
        public RolePermissionRepos(AppDbContext db)
            : base(db) 
        {
        }
    }
}
