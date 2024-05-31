using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Controllers
{
	[Route("Transaction")]
	public class TransactionController : Controller
	{
		private TransactionService transactionService;
		public TransactionController(TransactionService _transactionService)
		{
			this.transactionService = _transactionService;
		}

		[Produces("application/json")]
		[HttpGet("FindAll")]
		public IActionResult FindAll()
		{
			try
			{
				return Ok(transactionService.findAll());

			}
			catch
			{

				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpGet("findByDates/{from}/{to}")]
		public IActionResult FindByDates(string from, string to)
		{
			try
			{
				return Ok(transactionService.dateRange(from, to));

			}
			catch
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpGet("today/{date}")]
		public IActionResult Today(string date)
		{
			try
			{
				return Ok(transactionService.Today(date));

			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
