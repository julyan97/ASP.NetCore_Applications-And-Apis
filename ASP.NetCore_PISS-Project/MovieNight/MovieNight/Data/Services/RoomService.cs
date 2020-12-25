using Microsoft.EntityFrameworkCore;
using MovieNight.Data;
using MovieNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieNight.Repositories
{
    public class RoomService : BaseService<ChatRoom>, IRoomService
    {
        public RoomService(ApplicationDbContext db) 
        {
            this.Db = db;
        }

        public void AddUserToRoom(User user, ChatRoom room)
        {
            //mapping many to many
            UserChatRooms mapper = new UserChatRooms();
            mapper.User = user;
            mapper.ChatRoom = room;
            //---

            room.UserChatRooms.Add(mapper);
            Db.SaveChanges();
        }

        public List<ChatRoom> FindAllRoomsWhere(Expression<Func<ChatRoom, bool>> predicate)
        {

            var list = Db.ChatRooms
                .Include(x => x.UserChatRooms)
                .ThenInclude(x => x.User)
                .Where(predicate)
                .ToList();

            return list;
        }

        public ChatRoom FindRoomById(string id)
        {
            var room = Db.ChatRooms.Include(x => x.UserChatRooms)
                    .ThenInclude(x => x.User)
                    .FirstOrDefault(x => x.Id == id);

            return room;
        }

        public List<string> GetAllUserNamesInRoomById(string id)
        {
            var room = FindRoomById(id);
            var list = room.UserChatRooms.Select(x => x.User.UserName).ToList();
            return list;
        }

        public void RemoveRoomById(string id)
        {
            var room = Db.ChatRooms.FirstOrDefault(x => x.Id == id);
            Remove(room);
        }
    }
}
