using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductReview.Domain.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
