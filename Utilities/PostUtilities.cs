using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using GeekGallery.Models;
namespace GeekGallery.Utilities;
public class PostUtilities
{
    public string Path { get; set; }

    public PostUtilities()
    {
        Path = "data.json";
    }
        

    public T? ReadJson<T>(string? path = null)
    {
        var text = File.ReadAllText(path ?? Path);
        return JsonSerializer.Deserialize<T>(text);
    }

    public void WriteJson(PostArray posts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(posts, options);
        File.WriteAllText(Path, jsonString);
    }
    
    public List<Post> ListAllPosts()
    {
        var posts = ReadJson<PostArray>()?.posts;
        if (posts is null)
            return new List<Post>();
        else
            return posts;
    }

    private Post? FindPostById(int id)
    {
        var posts = ReadJson<PostArray>()?.posts;
        if (posts is null)
            return null;

        else
        {
            Post foundPost = posts.FirstOrDefault(a => a.Id == id);
            return foundPost;
        }


    } 
    
    public void AddNewPost(Post newPost)
    {
        var posts = ReadJson<PostArray>();
        posts?.posts.Add(newPost);
        if (posts is null)
            return;
        WriteJson(posts);
    }

    public void DeletePost(int id)
    {
        var posts = ReadJson<PostArray>();
        if (posts is null)
        {
            
            return;
        }
        var postId = id;

        var foundPost = posts.posts.FindIndex(p => p.Id == postId);
        if (foundPost is -1)
        {
            Console.WriteLine($"Could not find post with the id {postId}");
        }
        else
        {
            Console.WriteLine($"Removing {postId}");
            posts.posts.RemoveAt(foundPost);
            WriteJson(posts);
        }
    }

    public void EditPost(Post editedPost)
    {
        var posts = ReadJson<PostArray>();
        if (posts is null)
        {
            Console.WriteLine("No Posts Found :(");
            return;
        }
        var postId = editedPost.Id;

        var foundPost = posts.posts.FirstOrDefault(p => p.Id == postId);
        if (foundPost is null)
        {
            Console.WriteLine($"Could not find a post with id {postId}");
            return;
        }

        foundPost = editedPost;
        WriteJson(posts);
    }
}