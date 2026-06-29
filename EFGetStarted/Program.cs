using EFGetStarted.Data;
using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;

using var db = new BloggingContext();

Console.WriteLine($"Database path: {db.DbPath}");


//create a new blog and save it to the database
Console.WriteLine("Insert a new Blog.");
db.Add(new Blog() { Url = "http://sample.com" });
await db.SaveChangesAsync();


//read the first blog from the database
Console.WriteLine("Quering for a blog.");
var queriedBlog = await db.Blogs
        .OrderBy(b => b.BlogId)
        .FirstAsync();


//update the blog and add a post to it
Console.WriteLine("Updating the blog and adding a post.");
queriedBlog.Url = "https://sample.com/blog";
queriedBlog.Posts.Add(
    new Post
    {
        Title = "Hello World",
        Content = "I wrote an app using EF Core!"
    });
await db.SaveChangesAsync();


// delete the blog
Console.WriteLine("Delete the blog.");
db.Remove(queriedBlog);
await db.SaveChangesAsync();