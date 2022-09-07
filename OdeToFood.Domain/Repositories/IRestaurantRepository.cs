using OdeToFood.Entities;

namespace OdeToFood.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(Guid id);
        void Update(Restaurant restaurant);
        void Add(Restaurant restaurant);
        Restaurant Remove(Guid restaurantId);
        int GetRestaurantsCount();
        int SaveChanges();
    }
}
