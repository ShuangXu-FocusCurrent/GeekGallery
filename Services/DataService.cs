
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using GeekGallery.Models;
using GeekGallery.Data;
namespace GeekGallery.Services;
public class DataService
{
    /*
    private readonly string _jsonFilePath;
    private List<Author> _authors;
    private List<Post> _posts;
    private readonly ApiContext _context;

    
    public DataService(string jsonFilePath,ApiContext context)
    {
        _jsonFilePath = jsonFilePath;
        _context = context;
        LoadData();
    }
    
    private void LoadData()
    {
        try
        {
            var jsonData = File.ReadAllText(_jsonFilePath);
            var data = JsonSerializer.Deserialize<DataModel>(jsonData);

            _authors = data.Authors ?? new List<Author>();
            _posts = data.Posts ?? new List<Post>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading data: {ex.Message}");
            _authors = new List<Author>();
            _posts = new List<Post>();
        }
    }
    
    private void SaveData()
    {
        try
        {
            var data = new DataModel
            {
                Authors = _authors,
                Posts = _posts
            };

            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFilePath, jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving data: {ex.Message}");
        }
    }
    public List<Author> GetAllAuthors()
    {
        return _authors;
    }

    public List<Post> GetAllPosts()
    {
        return _posts;
    }

    public Author GetAuthorById(int id)
    {
        return _authors.FirstOrDefault(a => a.Id == id);
    }

    public Post GetPostById(int id)
    {
        return _posts.FirstOrDefault(p => p.Id == id);
    }
    
    public async Task AddAuthorAsync(Author author)
    {
        author.Id = _authors.Count > 0 ? _authors.Max(a => a.Id) + 1 : 1;
        _authors.Add(author);
        SaveData();
        await _context.Authors.AddAsync(author); 
        await _context.SaveChangesAsync();  
    }

    public async Task AddPostAsync(Post post)
    {
        post.Id = _posts.Count > 0 ? _posts.Max(p => p.Id) + 1 : 1;
        _posts.Add(post);
        SaveData();
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }
    
    public void UpdateAuthor(Author updatedAuthor)
    {
        var existingAuthor = _authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);
        if (existingAuthor != null)
        {
            // Update author properties here
            existingAuthor.Name = updatedAuthor.Name;
            existingAuthor.Email = updatedAuthor.Email;
            SaveData();
            
            _context.Authors.Update(existingAuthor);
            _context.SaveChanges(); 
        }
    }

    public void UpdatePost(Post updatedPost)
    {
        var existingPost = _posts.FirstOrDefault(p => p.Id == updatedPost.Id);
        if (existingPost != null)
        {
            // Update post properties here
            existingPost.Title = updatedPost.Title;
            existingPost.Content = updatedPost.Content;
            SaveData();

            _context.Posts.Update(existingPost);
            _context.SaveChanges();
        }
    }

    public void DeleteAuthor(int id)
    {
        var authorToDelete = _authors.FirstOrDefault(a => a.Id == id);
        if (authorToDelete != null)
        {
            _authors.Remove(authorToDelete);
            SaveData();
            
            _context.Authors.Remove(authorToDelete); 
            _context.SaveChanges(); 
        }
    }

    public void DeletePost(int id)
    {
        var postToDelete = _posts.FirstOrDefault(p => p.Id == id);
        if (postToDelete != null)
        {
            _posts.Remove(postToDelete);
            SaveData();
            
            _context.Posts.Remove(postToDelete); 
            _context.SaveChanges(); 
        }
    }


    
    public class DataModel
    {
        public List<Author> Authors { get; set; }
        public List<Post> Posts { get; set; }
    }
    
    */
    
    


    
}