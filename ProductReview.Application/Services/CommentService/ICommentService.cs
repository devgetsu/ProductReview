using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.CommentService
{
    public interface ICommentService
    {
        public Task<Comment> CreateComment(CommentDTO perDTO);
        public Task<Comment> UpdateCommentById(int id, CommentDTO perDTO);
        public Task<bool> DeleteCommentById(int id);
        public Task<Comment> GetCommentById(int id);
        public Task<IEnumerable<Comment>> GetAllComments();
    }
}
