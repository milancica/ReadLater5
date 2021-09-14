using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Entity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
    }
}
