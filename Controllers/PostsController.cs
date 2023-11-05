using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekGallery.Models;
using GeekGallery.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace GeekGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApiContext _context;

        public PostsController(ApiContext context)
        {
            _context = context;
        }
        
        //Create/Edit
        [HttpPost]
        public  async Task<ActionResult>  CreateEdit(Post post)
        {

            try
            {
                if (post.Id == 0)
                {
                    _context.Posts.Add(post);
                }
                else
                {
                    var postInDb = await _context.Posts.FindAsync(post.Id);
                    if (postInDb == null)
                        return NotFound();
                    postInDb.Title = post.Title;
                    postInDb.Author = post.Author;
                    
                    _context.Posts.Update(postInDb);
                }
                
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = post.Id }, post);

            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
            
        }
        
        //Get
        
        [HttpGet]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var result = await _context.Posts.FindAsync(id);
            if (result == null)
                return  NotFound();

            return (Ok(result));
            
            //http 404
        }
        
        //Delete
        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result =await _context.Posts.FindAsync(id);
            if (result == null)
                return NotFound();
            
            _context.Posts.Remove(result);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        //Get all
        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await  _context.Posts.ToListAsync();
            return Ok(result);
        }
    }
}
