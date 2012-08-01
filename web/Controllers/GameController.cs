using System.Diagnostics;
using System.Web.Mvc;
using web.Extensions;

namespace web.Controllers
{
    public class GameController : Controller
    {
        public void Join(int id)
        {
            Debug.WriteLine("Join game <{0}>".Format(id));
        }
    }
}