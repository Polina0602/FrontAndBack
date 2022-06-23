using FrontAndBack.Models;
using FrontAndBack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontAndBack.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IPlayerRepository playerRepository, IWebHostEnvironment webHostEnvironment) 
        {
            _playerRepository = playerRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Player Player { get; set; }
        [BindProperty]
        public IFormFile? Photo { get; set; }
        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Player = _playerRepository.GetPlayerById(id.Value);
            }
            else
            {
                Player = new Player();
            }
            if(Player == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Player.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Player.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    Player.PhotoPath = ProcessUploadFile();
                }

                if (Player.ID > 0)
                {
                    Player = _playerRepository.UpdatePlayer(Player);

                    TempData["SuccessMessage"] = $"Update {Player.Name} succesfull!";
                }
                else 
                {
                    Player = _playerRepository.AddPlayer(Player);
                    TempData["SuccessMessage"] = $"Create {Player.Name} succesfull!";
                }

                return RedirectToPage("Players");
            }
                return Page();
        }

        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
                Message = "Thank you for turning on notifications!";
            else
                Message = "You have turned off email notifications";

            Player = _playerRepository.GetPlayerById(id);
        }
        
        private string ProcessUploadFile()
        {
            string uniqueFileName = null;

            if(Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using(var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }

            return uniqueFileName;
        }
    }
}
