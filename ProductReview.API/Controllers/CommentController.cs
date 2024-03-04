using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.API.Attributes;
using ProductReview.Application.Services.CommentService;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Enums;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [IdentityFilter(Permission.GetCommit)]

        public async Task<ActionResult<IEnumerable<Comment>>> GetAllComments()
        {
            var comments = await _commentService.GetAllComments();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        [IdentityFilter(Permission.GetCommit)]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        [IdentityFilter(Permission.AddCommit)]

        public async Task<ActionResult<Comment>> CreateComment([FromForm] CommentDTO commentDTO)
        {
            try
            {
                var createdComment = await _commentService.CreateComment(commentDTO);
                return CreatedAtAction(nameof(GetCommentById), new { id = createdComment.Id }, createdComment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating comment: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [IdentityFilter(Permission.UpdateCommit)]

        public async Task<ActionResult<Comment>> UpdateCommentById(int id, [FromForm] CommentDTO commentDTO)
        {
            try
            {
                var updatedComment = await _commentService.UpdateCommentById(id, commentDTO);
                if (updatedComment == null)
                {
                    return NotFound();
                }
                return Ok(updatedComment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating comment: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [IdentityFilter(Permission.DeleteCommit)]
        public async Task<IActionResult> DeleteCommentById(int id)
        {
            try
            {
                var result = await _commentService.DeleteCommentById(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting comment: {ex.Message}");
            }
        }
    }
}
