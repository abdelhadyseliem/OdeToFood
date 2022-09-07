using Microsoft.AspNetCore.Mvc;
using OdeToFood.Domain.Repositories;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantRepository _restaurantRepo;

        public RestaurantCountViewComponent(IRestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public IViewComponentResult Invoke()
        {
            var count = _restaurantRepo.GetRestaurantsCount();

            return View(count);
        }
    }
}
