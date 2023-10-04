namespace GeekGallery.Models;

public class Comment
{
    public int Id { get; set; }          
    public string Content { get; set; }  

    // 评论的创建日期
    public DateTime CreatedAt { get; set; }

    // 外键，表示关联的帖子
    public int PostId { get; set; }
    public Post Post { get; set; }       

    // 外键，表示关联的用户
    public int AuthorId { get; set; }
    public Author Author { get; set; } 
}