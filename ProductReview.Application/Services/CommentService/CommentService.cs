using NewProductReview.Applicaion.Abstraction.RepositoryInterfaces;
using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;

namespace ProductReview.Application.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IProductRepository _productRepository;

        public CommentService(ICommentRepository commentRepository, IProductRepository productRepository)
        {
            _commentRepository = commentRepository;
            _productRepository = productRepository;
        }

        public async Task<Comment> CreateComment(CommentDTO commentDTO)
        {
            var newComment = new Comment
            {
                Comment_text = commentDTO.Comment_text,
                Product_ID =    commentDTO.Product_id,
                Product = await _productRepository.GetByAny(x=>x.Id ==  commentDTO.Product_id)
            };

            return await _commentRepository.Create(newComment);
        }

        public async Task<bool> DeleteCommentById(int id)
        {
            return await _commentRepository.Delete(c => c.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _commentRepository.GetAll();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _commentRepository.GetByAny(c => c.Id == id);
        }

        public async Task<Comment> UpdateCommentById(int id, CommentDTO commentDTO)
        {
            var existingComment = await _commentRepository.GetByAny(c => c.Id == id);
            if (existingComment == null)
            {
                return null;
            }

            existingComment.Comment_text = commentDTO.Comment_text;
            existingComment.Product_ID = commentDTO.Product_id;
            existingComment.Product = await _productRepository.GetByAny(x => x.Id == commentDTO.Product_id);

            return await _commentRepository.Update(existingComment);
        }
    }
}
