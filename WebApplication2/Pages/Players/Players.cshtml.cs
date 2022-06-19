using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FrontAndBack.Services;
using FrontAndBack.Models;

namespace FrontAndBack.Pages.Players
{
    public class PlayersModel : PageModel
    {
        private readonly IPlayerRepository _db;

        public PlayersModel(IPlayerRepository db)
        {
            _db = db;
        }

        public IEnumerable<Player> Players { get; set; }

        public void OnGet()
        {
            Players = _db.GetAllPlayers();
        }
    }
}
