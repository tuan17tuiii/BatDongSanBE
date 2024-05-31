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
		[Route("FindAll")]
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
	}
}
