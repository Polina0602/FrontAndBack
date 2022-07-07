using FrontAndBack.Models;
using FrontAndBack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontAndBack.Pages.Players
{
//    public class DeleteModel : PageModel
//    {
//        private readonly IPlayerRepository _playerRepository;

//        public DeleteModel(IPlayerRepository playerRepository)
//        {
//            _playerRepository = playerRepository;
//        }

//        [BindProperty]
//        public Player Player { get; set; }

//        public IActionResult OnGet(int id)
//        {
//            Player Player = _playerRepository.GetPlayerById(id);

//            if (Player == null)
//                return RedirectToPage("/NotFound");
//            return Page();
//        }

//        public IActionResult OnPost()
//        {
//            Player deletedPlayer = _playerRepository.DeletePlayer(Player.ID);

//            if (deletedPlayer == null)
//                return RedirectToPage("/NotFound");
//            return RedirectToPage("/Players");
//        }
//    }
//}

public class DeleteModel : PageModel
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public DeleteModel(IPlayerRepository playerRepository, IWebHostEnvironment webHostEnvironment)
    {
        _playerRepository = playerRepository;
        _webHostEnvironment = webHostEnvironment;
    }

        [BindProperty]
    public Player Player { get; set; }
    public IActionResult OnGet(int id)
    {
        Player = _playerRepository.GetPlayerById(id);

        if (Player == null)
            return RedirectToPage("/NotFound");

        return Page();
    }

    public IActionResult OnPost()
    {
        Player deletedPlayer = _playerRepository.DeletePlayer(Player.ID);

                if (deletedPlayer.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", deletedPlayer.PhotoPath);

                    if (deletedPlayer.PhotoPath != "noimage.png")
                        System.IO.File.Delete(filePath);
                }

            if (deletedPlayer == null)
            return RedirectToPage("/NotFound");

        return RedirectToPage("Players");
    }
}
}