using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieNight.Data;
using MovieNight.Models;
using MovieNight.Models.ModelView;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MovieNight.Repositories;
using Microsoft.AspNetCore.Identity;

namespace MovieNight.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        private readonly MovieService movieService;
        private readonly RoomService roomService;
        private readonly UserManager<User> userManager;

        public HomeController(ILogger<HomeController> logger
            , ApplicationDbContext db
            , MovieService movieService
            , RoomService roomService
            , UserManager<User> userManager)
        {
            this.db = db;
            this.movieService = movieService;
            this.roomService = roomService;
            this.userManager = userManager;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {

            var list = roomService.FindAllRoomsWhere(x => (x.Id.Contains(search) || x.Owner.Contains(search)) || (search == null));
            var model = new IndexViewModel() { ChatRooms = list };
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                model.UserRole = user.Role;
            }
            catch
            {
                model.UserRole = "user";
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddMovie(string movieUrl, string movieName)
        {
            movieService.Add(new Movie() { Name = movieName, Path = movieUrl });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteMovie(string movieName)
        {
            movieService.RemoveByName(movieName);
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Home/roomchat/{id}")]
        public async Task<IActionResult> RoomChat(string id)
        {
            try
            {
                var room = roomService.FindRoomById(id);

                if (!room.UserChatRooms.Any(x => x.User.UserName == User.Identity.Name))
                {
                    var user = await userManager.FindByNameAsync(User.Identity.Name);
                    roomService.AddUserToRoom(user, room);
                }
                var users = roomService.GetAllUserNamesInRoomById(id);

                RoomChatModelView model = new RoomChatModelView() { Id = id, Users = users, Movies = db.Movies.ToList() };
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult JoinRoom(string Id)
        {
            return RedirectToAction("RoomChat", new { Id = Id });
        }


        [HttpPost]
        public IActionResult CreateRoom()
        {

            var user = db.Users.Include(x => x.UserChatRooms)
                .ThenInclude(x => x.ChatRoom)
                .FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name);

            //mapping many to many
            UserChatRooms mapper = new UserChatRooms() { User = user, ChatRoom = new ChatRoom() };
            mapper.ChatRoom.Owner = user.UserName;

            user.UserChatRooms.Add(mapper);
            db.SaveChanges();

            return RedirectToAction("RoomChat", new { Id = mapper.ChatRoomId });
        }

        [HttpGet]
        public IActionResult DeleteRoom(string id)
        {
            var room = roomService.FindRoomById(id);
            if (HttpContext.User.Identity.Name != room.Owner) return RedirectToAction("Index");
            roomService.Remove(room);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
