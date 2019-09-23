using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Modas.Models;

namespace Modas.Controllers
{
	public class HomeController : Controller
	{
        private EFEventRepository repository;
        public HomeController(EFEventRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(int pageNumber = 1, int resultCount = 10) => 
            View(new IndexViewModel
            {
                Events = repository.Events.Skip((pageNumber - 1) * resultCount).Take(resultCount),
                Locations = repository.Locations,
                EventCount = repository.Events.Count(),
                MaxPages = (int)Math.Ceiling(repository.Events.Count() / (resultCount + 0.0)),
                CurrentPage = pageNumber,
                ResultCount = resultCount
            });
	}
}