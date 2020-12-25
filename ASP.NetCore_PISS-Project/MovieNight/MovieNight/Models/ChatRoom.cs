using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieNight.Models
{
    public class ChatRoom : BaseData
    {
        public string Owner { get; set; }
        public List<UserChatRooms> UserChatRooms { get; set; }
    }


}
