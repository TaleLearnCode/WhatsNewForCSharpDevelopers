using Microsoft.EntityFrameworkCore;
using System.Text;
using TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.Data;
using TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.Models;

DbScaffoldingContext context = new();

/* ----------------------------------------------------------------------------
 * Creating the Blog
 * ---------------------------------------------------------------------------- */

Console.WriteLine("Creating the Blog");

Blog blog = new() { BlogName = "Chad's View of the World", BlogDescription = "Where Chad hardly ever writes.", BlogUrl = "https://www.chadgreen.com" };
context.Blogs.Add(blog);
context.SaveChanges();

/* ----------------------------------------------------------------------------
 * Creating the Tags
 * ---------------------------------------------------------------------------- */

Console.WriteLine("Creating the tags");

Tag cSharp9Tag = new() { TagName = "C# 9", TagDescription = "Articles about changes within C# 9" };
context.Tags.Add(cSharp9Tag);

Tag cSharp10Tag = new() { TagName = "C# 10", TagDescription = "Articles about changes within C# 10" };
context.Tags.Add(cSharp10Tag);

Tag recordTag = new() { TagName = "Record Type" };
context.Tags.Add(recordTag);

Tag DotNet6Tag = new() { TagName = ".NET 6" };
context.Tags.Add(DotNet6Tag);

Tag LinqTag = new() { TagName = "LINQ" };
context.Tags.Add(LinqTag);

Tag EFCore6Tag = new() { TagName = "EF Core 6.0" };
context.Tags.Add(EFCore6Tag);

Tag EntityFrameworkTag = new() { TagName = "Entity Framework" };
context.Tags.Add(EntityFrameworkTag);

context.SaveChanges();

/* ----------------------------------------------------------------------------
 * Creating the Posts
 * ---------------------------------------------------------------------------- */

Console.WriteLine("Creating the posts");

Post post = new()
{
	Title = "Record Classes",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp9Tag);
post.Tags.Add(recordTag);
context.Posts.Add(post);

post = new()
{
	Title = "Improvements to structs",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp10Tag);
post.Tags.Add(recordTag);
context.Posts.Add(post);

post = new()
{
	Title = "Record Structs",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp10Tag);
post.Tags.Add(recordTag);
context.Posts.Add(post);

post = new()
{
	Title = "Improvements to structs",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp10Tag);
post.Tags.Add(recordTag);
context.Posts.Add(post);

post = new()
{
	Title = "Top-Level Statements",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp9Tag);
context.Posts.Add(post);

post = new()
{
	Title = "File-Scoped Namespace Declaration",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp10Tag);
context.Posts.Add(post);

post = new()
{
	Title = "Global and Implicit Usings",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp10Tag);
context.Posts.Add(post);

post = new()
{
	Title = "Constant Interpolated Strings",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp10Tag);
context.Posts.Add(post);

post = new()
{
	Title = "Extended Property Patterns",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(recordTag);
context.Posts.Add(post);

post = new()
{
	Title = "Assignment and Declaration in Same Deconstruction",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp10Tag);
context.Posts.Add(post);

post = new()
{
	Title = "Interpolated String Handlers",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(cSharp10Tag);
context.Posts.Add(post);

post = new()
{
	Title = "DateOnly and TimeOnly",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(DotNet6Tag);
context.Posts.Add(post);

post = new()
{
	Title = "Hot Reload",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(DotNet6Tag);
context.Posts.Add(post);

post = new()
{
	Title = "Chunk",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(DotNet6Tag);
post.Tags.Add(LinqTag);
context.Posts.Add(post);

post = new()
{
	Title = "OrDefault() Overloads",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(DotNet6Tag);
post.Tags.Add(LinqTag);
context.Posts.Add(post);

post = new()
{
	Title = "PriorityQueue<T,N>",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(DotNet6Tag);
post.Tags.Add(LinqTag);
context.Posts.Add(post);

post = new()
{
	Title = "MinBy() and MaxBy()",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(DotNet6Tag);
post.Tags.Add(LinqTag);
context.Posts.Add(post);

post = new()
{
	Title = "Set Operations",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(DotNet6Tag);
post.Tags.Add(LinqTag);
context.Posts.Add(post);

post = new()
{
	Title = "Chunk",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(DotNet6Tag);
post.Tags.Add(LinqTag);
context.Posts.Add(post);

post = new()
{
	Title = "New Mapping Attributes",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(EFCore6Tag);
post.Tags.Add(EntityFrameworkTag);
context.Posts.Add(post);

post = new()
{
	Title = "Model Building Improvements",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(EFCore6Tag);
post.Tags.Add(EntityFrameworkTag);
context.Posts.Add(post);

post = new()
{
	Title = "Pre-Convention Model Configuration",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(EFCore6Tag);
post.Tags.Add(EntityFrameworkTag);
context.Posts.Add(post);

post = new()
{
	Title = "Improvements to Scaffolding from an Existing Database",
	Contents = "Lorem ipsum dolor sit amet consectetur adipiscing, elit blandit in lacus metus vulputate faucibus, massa montes semper habitant ac.",
	PostedOn = DateTime.Now,
	BlogId = blog.BlogId
};
post.Tags.Add(EFCore6Tag);
post.Tags.Add(EntityFrameworkTag);
context.Posts.Add(post);

context.SaveChanges();

/* ----------------------------------------------------------------------------
 * Query the datat
 * ---------------------------------------------------------------------------- */

Console.WriteLine("Querying the data");

List<Post>? posts = context.Posts
	.Include(x => x.Tags)
	.Include(x => x.Blog)
	.ToList();

Console.WriteLine("Blog\tTags\tTitle");
if (posts is not null && posts.Any())
	foreach (Post blogPost in posts)
		Console.WriteLine($"{blogPost.Blog?.BlogName}\t{PrepTags(blogPost.Tags.ToList())}\t{blogPost.Title}");
else
	Console.WriteLine("The blog posts found");


static string PrepTags(List<Tag> tags)
{
	if (tags is not null && tags.Any())
	{
		StringBuilder response = new();
		foreach (Tag tag in tags)
			response.Append($"{tag.TagName}, ");
		return response.ToString()[..(response.Length - 2)];
	}
	else
		return string.Empty;
}