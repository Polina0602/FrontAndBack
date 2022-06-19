using FrontAndBack.Models;
using FrontAndBack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontAndBack.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IPlayerRepository _playerRepository;

        public DetailsModel(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Player player { get; private set; }

        public IActionResult OnGet(int id)
        {
            player = _playerRepository.GetPlayerById(id);

            if(player == null)
            {
                return RedirectToPage("/NotFound");
              
            }
            return Page();
        }
    }
}
