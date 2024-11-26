using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationalApp.Data;
using OrganizationalApp.Models;
using OrganizationalApp.Models.Entities;
using System.Diagnostics;
using System.Linq;


namespace OrganizationalApp.Controllers
{
	public class HomeController : Controller
	{
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //	_logger = logger;
        //}

        //      private readonly ApplicationDbContext _context;

        //      public HomeController(ApplicationDbContext context)
        //      {
        //          _context = context;
        //      }

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
		{

            var users = _context.Users
        .OrderBy(u => u.Level)
        .ToList();

            return View(users);



            /*var user = _context.Users.ToList();
            return View(user);*/
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
