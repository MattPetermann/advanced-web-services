using Microsoft.AspNetCore.Mvc;
using Modas.Models;

namespace Modas.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index() => View(FakeEventRepository.Events);
	}
}