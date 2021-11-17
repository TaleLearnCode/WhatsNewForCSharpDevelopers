using Microsoft.EntityFrameworkCore;
using TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.Models;

namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.Data
{
	public partial class DbScaffoldingContext : DbContext
	{
		public DbScaffoldingContext()
		{
		}

		public DbScaffoldingContext(DbContextOptions<DbScaffoldingContext> options)
				: base(options)
		{
		}

		public virtual DbSet<Blog> Blogs { get; set; } = null!;
		public virtual DbSet<Post> Posts { get; set; } = null!;
		public virtual DbSet<Tag> Tags { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbScaffolding");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Blog>(entity =>
			{
				entity.ToTable("Blog");

				entity.HasComment("Represents a blog managed by the system.");

				entity.Property(e => e.BlogId).HasComment("Identifier of the blog record.");

				entity.Property(e => e.BlogDescription)
									.HasMaxLength(500)
									.HasComment("A description of the blog.");

				entity.Property(e => e.BlogName)
									.HasMaxLength(200)
									.HasComment("The name of the blog.");

				entity.Property(e => e.BlogUrl)
									.HasMaxLength(500)
									.HasComment("The URL to the blog's home page.");
			});

			modelBuilder.Entity<Post>(entity =>
			{
				entity.ToTable("Post");

				entity.HasComment("Represents a blog post.");

				entity.Property(e => e.PostId).HasComment("Identifier of the post record.");

				entity.Property(e => e.BlogId).HasComment("Identifier of the Blog the post is associated with.");

				entity.Property(e => e.Contents).HasComment("Contents of the blog post.");

				entity.Property(e => e.PostedOn).HasComment("The date and time the blog post is posted.");

				entity.Property(e => e.Title)
									.HasMaxLength(200)
									.HasComment("Title of the blog post.");

				entity.Property(e => e.UpdatedOn).HasComment("The date and time of the last updat to the blog post.");

				entity.HasOne(d => d.Blog)
									.WithMany(p => p.Posts)
									.HasForeignKey(d => d.BlogId)
									.OnDelete(DeleteBehavior.ClientSetNull)
									.HasConstraintName("fkPost_Blog");

				entity.HasMany(d => d.Tags)
									.WithMany(p => p.Posts)
									.UsingEntity<Dictionary<string, object>>(
											"PostTag",
											l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId").HasConstraintName("fkPostTag_Tag"),
											r => r.HasOne<Post>().WithMany().HasForeignKey("PostId").HasConstraintName("fkPostTag_Post"),
											j =>
											{
										j.HasKey("PostId", "TagId").HasName("pkcPostTag");

										j.ToTable("PostTag").HasComment("Defines the tags a post is associated with.");

										j.IndexerProperty<int>("PostId").HasComment("Identifier of the assocated post.");

										j.IndexerProperty<int>("TagId").HasComment("Identifier of the assocated tag.");
									});
			});

			modelBuilder.Entity<Tag>(entity =>
			{
				entity.ToTable("Tag");

				entity.HasComment("Represents the tags (wword or phrase describing a blog post. used in the system.");

				entity.Property(e => e.TagId).HasComment("Identifier of the tag record.");

				entity.Property(e => e.TagDescription)
									.HasMaxLength(200)
									.HasComment("A short description of the tag.");

				entity.Property(e => e.TagName)
									.HasMaxLength(30)
									.HasComment("The name of the tag (what is shown to users).");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
