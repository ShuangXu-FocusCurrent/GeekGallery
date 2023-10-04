namespace GeekGallery.Models;

public class Collection
{
    public int Id { get; set; }     

    // 外键，表示关联的用户
    public int UserId { get; set; }
    public Author User { get; set; } 

    // 外键，表示关联的帖子
    public int PostId { get; set; }
    public Post Post { get; set; }   
}