using Microsoft.EntityFrameworkCore;
using GeekGallery.Models;
namespace GeekGallery.Data;

public class ApiContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
        
    }
}