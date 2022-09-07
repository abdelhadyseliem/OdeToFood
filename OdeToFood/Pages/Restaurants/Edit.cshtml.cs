using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Entities;
using OdeToFood.Entities.Enums;
using OdeToFood.Domain.Repositories;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepo;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantRepository restaurantRepo, IHtmlHelper htmlHelper)
        {
            _restaurantRepo = restaurantRepo;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(Guid? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();

            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantRepo.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant is null)
            {
                return RedirectToPage("../NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id is not null)
            {
                TempData["Message"] = "Restaurant Updated!";
                _restaurantRepo.Update(Restaurant);
            }
            else
            {
                TempData["Message"] = "Restaurant Saved!";
                _restaurantRepo.Add(Restaurant);
            }

            _restaurantRepo.SaveChanges();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}
