using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekGallery.Models;
using GeekGallery.Data;

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
        public JsonResult CreateEdit(Post post)
        {
            if (post.Id == 0)
            {
                _context.Posts.Add(post);
            }
            else
            {
                var postInDb = _context.Posts.Find(post.Id);
                if (postInDb == null)
                    return new JsonResult(NotFound());
                postInDb = post;
            }

            _context.SaveChanges();
            return new JsonResult(Ok(post));
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
        public JsonResult Delete(int id)
        {
            var result = _context.Posts.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            
            _context.Posts.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());

        }
        //Get all
        [HttpGet("/GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.Posts.ToList();
            return new JsonResult(Ok(result));
        }
    }
}
