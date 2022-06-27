using FrontAndBack.Models;
using FrontAndBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontAndBack.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IPlayerRepository _playerRepository;

        public HeadCountViewComponent(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IViewComponentResult Invoke(Role? role = null)
        {
            var result = _playerRepository.PlayerCountByRole(role);
            return View(result);
        }
        
    }
}
