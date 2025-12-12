using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public List<Guid>? FavouriteListIDs { get; set; }
        public List<Guid>? CommentIDs { get; set; }
        public string AvatarImageID { get; set; }
        public string DisplayName { get; set; }
        public bool ProfileType { get; set; }
        //public int Reputation { get; set; } = 0;
        //public string? Signature { get; set; }
    }
}