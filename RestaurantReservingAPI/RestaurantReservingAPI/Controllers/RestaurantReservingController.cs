using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservingAPI.Models;
using RestaurantReservingAPI.Data;

namespace RestaurantReservingAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RestaurantReservingController : ControllerBase
	{
		private readonly ApiContext _context;

		public RestaurantReservingController(ApiContext context)
		{
			_context = context;
		}

		// Create/Edit
		[HttpPost]
		public JsonResult CreateEdit(RestaurantReserving booking)
		{
			if (booking.Id == 0)
			{
				_context.Reservings.Add(booking);
			}
			else
			{
				var bookingInDb = _context.Reservings.Find(booking.Id);

				if (bookingInDb == null)
					return new JsonResult(NotFound());

				bookingInDb = booking;
			}

			_context.SaveChanges();

			return new JsonResult(Ok(booking));

		}

		// Get
		[HttpGet]
		public JsonResult Get(int id)
		{
			var result = _context.Reservings.Find(id);

			if (result == null)
				return new JsonResult(NotFound());

			return new JsonResult(Ok(result));
		}

		// Delete
		[HttpDelete]
		public JsonResult Delete(int id)
		{
			var result = _context.Reservings.Find(id);

			if (result == null)
				return new JsonResult(NotFound());

			_context.Reservings.Remove(result);
			_context.SaveChanges();

			return new JsonResult(NoContent());
		}

		// Get all
		[HttpGet()]
		public JsonResult GetAll()
		{
			var result = _context.Reservings.ToList();

			return new JsonResult(Ok(result));
		}

	}
}
