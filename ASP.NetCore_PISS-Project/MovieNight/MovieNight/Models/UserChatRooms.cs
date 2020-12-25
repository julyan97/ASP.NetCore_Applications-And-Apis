using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieNight.Models
{
    public class UserChatRooms
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }
}
