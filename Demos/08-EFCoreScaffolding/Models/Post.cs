using System;
using System.Collections.Generic;

namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.Models
{
    /// <summary>
    /// Represents a blog post.
    /// </summary>
    public partial class Post
    {
        public Post()
        {
            Tags = new HashSet<Tag>();
        }

        /// <summary>
        /// Identifier of the post record.
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// Title of the blog post.
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// Contents of the blog post.
        /// </summary>
        public string Contents { get; set; } = null!;
        /// <summary>
        /// The date and time the blog post is posted.
        /// </summary>
        public DateTime PostedOn { get; set; }
        /// <summary>
        /// The date and time of the last updat to the blog post.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Identifier of the Blog the post is associated with.
        /// </summary>
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; } = null!;

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
