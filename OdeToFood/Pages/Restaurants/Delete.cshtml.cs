using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Domain.Repositories;
using OdeToFood.Entities;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepo;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantRepository restaurantRepo)
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

        public IActionResult OnPost(Guid restaurantId)
        {
            Restaurant = _restaurantRepo.Remove(restaurantId);
            _restaurantRepo.SaveChanges();

            if (Restaurant == null)
            {
                return RedirectToPage("../NotFound");
            }

            TempData["Message"] = $"{Restaurant.Name} is deleted successfully.";
            return RedirectToPage("./List");
        }
    }
}
