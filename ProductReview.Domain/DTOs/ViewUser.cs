using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Domain.DTOs
{
    public class ViewUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<int> Products { get; set; }
    }
}
