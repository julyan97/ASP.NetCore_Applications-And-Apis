using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieNight.Models
{
    public class User : IdentityUser
    {
        public List<UserChatRooms> UserChatRooms { get; set; }
        public string Role { get; set; } = "User";
    }
}
