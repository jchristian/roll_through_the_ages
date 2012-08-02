using System.Web.Mvc;
using web.Models.Lobby;

namespace web.Controllers
{
    public class LobbyController : Controller
    {
        public ActionResult Index()
        {
            var model = new LobbyModel
            {
                Games = new[]
                {
                    new GameModel { Id = 1, Name = "Game 1", NumberOfPlayers = 3 },
                    new GameModel { Id = 2, Name = "Game 2", NumberOfPlayers = 3 },
                    new GameModel { Id = 3, Name = "Game 3", NumberOfPlayers = 3 },
                    new GameModel { Id = 4, Name = "Game 4", NumberOfPlayers = 3 },
                    new GameModel { Id = 5, Name = "Game 5", NumberOfPlayers = 3 },
                    new GameModel { Id = 6, Name = "Game 6", NumberOfPlayers = 3 },
                    new GameModel { Id = 7, Name = "Game 7", NumberOfPlayers = 3 },
                    new GameModel { Id = 8, Name = "Game 8", NumberOfPlayers = 2 },
                    new GameModel { Id = 9, Name = "Game 9", NumberOfPlayers = 2 },
                    new GameModel { Id = 10, Name = "Game 10", NumberOfPlayers = 1 },
                    new GameModel { Id = 11, Name = "Game 11", NumberOfPlayers = 1 },
                    new GameModel { Id = 12, Name = "Game 12", NumberOfPlayers = 1 },
                    new GameModel { Id = 13, Name = "Game 13", NumberOfPlayers = 1 }
                }
            };

            return View(model);
        }
    }
}