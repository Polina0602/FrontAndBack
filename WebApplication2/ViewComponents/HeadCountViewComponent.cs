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

        public IViewComponentResult Invoke()
        {
            var result = _playerRepository.PlayerCountByRole();
            return View(result);
        }
        
    }
}
