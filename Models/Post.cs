using System;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;
namespace GeekGallery.Models;
public class PostArray
{
    public List<Post> posts { get; set; }
}
public class Post
{
   


    public int Id { get; set; }
   
    public string Title { get; set; }
    
    public string Content { get; set; }
   
    public DateTime CreateDate { get; set; }
   
    public int LikeCount { get; set; }
   
    public int CollectionCount { get; set; }
    
    
  //  public int AuthorId { get; set; }
    // public Author Author {get; set; }
    
    public Post(int id, string title, string content, DateTime createDate, int likeCount, int collectionCount)
    {
        Id = id;
        Title = title;
        Content = content;
        CreateDate = createDate;
        LikeCount = likeCount;
        CollectionCount = collectionCount;
    }
}
