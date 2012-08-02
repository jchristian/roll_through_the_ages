using System.Linq;
using System.Web.Mvc;
using web.Extensions;
using web.Models.Game;

namespace web.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Join(int id)
        {
            var model = new GameModel { Name = "Game {0}".FormatWith(id), Player = new PlayerModel(), Opponents = Enumerable.Empty<PlayerModel>(), Dice = new DiceModel()};
            return View("Index", model);
        }
    }
}