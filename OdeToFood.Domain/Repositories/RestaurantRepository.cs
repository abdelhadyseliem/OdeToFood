using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Entities;

namespace OdeToFood.Domain.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public DataContext Context { get; }

        public RestaurantRepository(DataContext context)
        {
            Context = context;
        }

        public void Add(Restaurant restaurant)
        {
            Context.Restaurants.Add(restaurant);
        }

        public Restaurant GetById(Guid id)
        {
            return Context.Restaurants.Find(id);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Update(Restaurant restaurant)
        {
            Context.Restaurants.Attach(restaurant);
            Context.Entry(restaurant).State = EntityState.Modified;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = Context.Restaurants
                .Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                .OrderBy(r => r.Name);

            return query;
        }

        public Restaurant Remove(Guid restaurantId)
        {
            var restaurant = GetById(restaurantId);

            if (restaurant != null)
            {
                Context.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetRestaurantsCount()
        {
            return Context.Restaurants.Count();
        }
    }
}
