using Microsoft.EntityFrameworkCore;
using RestaurantReservingAPI.Models;

namespace RestaurantReservingAPI.Data
{
	public class ApiContext : DbContext
	{
		public DbSet<RestaurantReserving> Reservings { get; set; }
		public ApiContext(DbContextOptions<ApiContext> options) : base(options)
		{

		}
	}
}
