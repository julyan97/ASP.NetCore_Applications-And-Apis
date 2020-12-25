using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieNight.Models.ModelView
{
    public class RoomChatModelView
    {
        public string Id { get; set; }
        public List<string> Users { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
