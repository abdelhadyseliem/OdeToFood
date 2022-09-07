using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Domain.Repositories;
using OdeToFood.Entities;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepo;

        [TempData]
        public string Message { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public void OnGet()
        {
            var result = _restaurantRepo
                .GetRestaurantsByName(SearchTerm);

            Restaurants = result;
        }

    }
}
