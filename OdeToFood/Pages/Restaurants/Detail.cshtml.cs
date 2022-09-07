using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Domain.Repositories;
using OdeToFood.Entities;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepo;

        [TempData]
        public string Message { get; set; }

        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public IActionResult OnGet(Guid restaurantId)
        {
            Restaurant = _restaurantRepo.GetById(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("../NotFound");
            }

            return Page();
        }
    }
}
