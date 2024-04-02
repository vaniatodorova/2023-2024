using Microsoft.EntityFrameworkCore;
using RestaurantReservingAPI.Models;

namespace RestaurantReservingAPI.Data
{
	public class EmployeeContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
		{

		}
	}
}
