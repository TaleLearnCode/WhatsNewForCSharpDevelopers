using System;
using System.Collections.Generic;

namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.Models
{
    /// <summary>
    /// Represents the tags (wword or phrase describing a blog post. used in the system.
    /// </summary>
    public partial class Tag
    {
        public Tag()
        {
            Posts = new HashSet<Post>();
        }

        /// <summary>
        /// Identifier of the tag record.
        /// </summary>
        public int TagId { get; set; }
        /// <summary>
        /// The name of the tag (what is shown to users).
        /// </summary>
        public string TagName { get; set; } = null!;
        /// <summary>
        /// A short description of the tag.
        /// </summary>
        public string? TagDescription { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
