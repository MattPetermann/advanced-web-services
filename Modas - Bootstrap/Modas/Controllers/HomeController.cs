using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Modas.Models;

namespace Modas.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index(int pageNumber = 1, int resultCount = 10)
        {
            return View( new IndexViewModel
            {
                Events = FakeEventRepository.Events.Skip((pageNumber - 1) * resultCount).Take(resultCount),
                EventCount = FakeEventRepository.Events.Count(),
                MaxPages = (int)Math.Ceiling(FakeEventRepository.Events.Count / (resultCount + 0.0)),
                CurrentPage = pageNumber,
                ResultCount = resultCount
            });
        } 
	}
}