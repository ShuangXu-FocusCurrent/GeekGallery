using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekGallery.Models;
using GeekGallery.Data;
using GeekGallery.Services;
using GeekGallery.Utilities;
using Microsoft.EntityFrameworkCore;

using NuGet.Protocol;

namespace GeekGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApiContext _context;

        public PostUtilities postJson;


        public PostsController(ApiContext context)
        {
            postJson = new PostUtilities();
            _context = context;
        }
        
        [HttpGet("initialise")]
        public async Task<ActionResult<List<Post>>> initialiseContext(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var postsFromJSON = postJson.ListAllPosts();
            foreach(Post post in postsFromJSON)
            {
                _context.Posts.Add(post);
            }
            await _context.SaveChangesAsync();
            return await _context.Posts.ToListAsync();
        }
        
        // GETAll: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            return await _context.Posts.ToListAsync();
        }
        
        // GET: api/Post
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }
        
        //Put
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;
           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'PostContext.Posts'  is null.");
            }
            _context.Posts.Add(post);
            postJson.AddNewPost(post);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPost", new { id = post.Id }, post);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }
        
        // DELETE: api/Posts
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            postJson.DeletePost(id);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        
    }
    
    

    /*
     [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DataService _dataService;

        public PostsController(DataService dataService)
        {
            _dataService = dataService;
        }

        //Create/Edit
        [HttpPost]
        public async Task<ActionResult<Post>> CreateEditAsync(Post post)
        {

            try
            {
                if (post.Id == 0)
                {
                   await _dataService.AddPostAsync(post);
                }
                else
                {
                    var existingPost = _dataService.GetPostById(post.Id);
                    if (existingPost == null)
                        return NotFound();
                    _dataService.UpdatePost(post);

                }

                return CreatedAtAction(nameof(Get), new { id = post.Id }, post);

            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

        }

        //Get

        [HttpGet("Umar")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var result = _dataService.GetPostById(id);
            if (result == null)
                return  NotFound();

            return Ok(result);

            //http 404
        }

        //Delete
        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result =_dataService.GetPostById(id);
            if (result == null)
                return NotFound();

            _dataService.DeletePost(id);
            return NoContent();

        }
        //Get all
        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _dataService.GetAllPosts();
            return Ok(result);
        }

    }
    */
    /*
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
        
        [HttpGet("Umar")]
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
    */
}

