using System;
using System.Collections.Generic;

namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.Models
{
    /// <summary>
    /// Represents a blog managed by the system.
    /// </summary>
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        /// <summary>
        /// Identifier of the blog record.
        /// </summary>
        public int BlogId { get; set; }
        /// <summary>
        /// The name of the blog.
        /// </summary>
        public string BlogName { get; set; } = null!;
        /// <summary>
        /// A description of the blog.
        /// </summary>
        public string? BlogDescription { get; set; }
        /// <summary>
        /// The URL to the blog&apos;s home page.
        /// </summary>
        public string? BlogUrl { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
