using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationalApp.Data;
using OrganizationalApp.Models;
using OrganizationalApp.Models.Entities;
//using System.Reflection.Emit;

namespace OrganizationalApp.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EmpController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUsersViewModel viewModel)
        {
            var users = new Users
            {
                Name = viewModel.Name,
                Level = viewModel.Level,
                PkCode = viewModel.PkCode,
                FkCode = viewModel.FkCode,
                Code = viewModel.Code,
            };

            await dbContext.Users.AddAsync(users);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Emp");
            //return View();
        }


        [HttpGet]
        //public async Task<IActionResult> List()
        //{
        //    var users = await dbContext.Users
        //        .Select(u => new
        //        {
        //            u.Id,
        //            Name = u.name ?? "No Name",  // Default value for null
        //            Level = u.level ?? 0,       // Default value for null
        //            PkCode = u.pkcode ?? "N/A",
        //            FkCode = u.fkcode ?? "N/A",
        //            Code = u.code ?? "N/A"
        //        }).ToListAsync();

        //    return View(users);
        //}
        public async Task<IActionResult> List()
        {
            var user = await dbContext.Users.ToListAsync();

            return View(user);
        }


        [HttpGet]

        public async Task<IActionResult> Edit(int Id)
        {
            var users = await dbContext.Users.FindAsync(Id);

            return View(users);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Users viewModel)
        {
            var users = await dbContext.Users.FindAsync(viewModel.Id);

            if (users is not null)
            {
                users.Name = viewModel.Name;
                users.Level = viewModel.Level;
                users.PkCode = viewModel.PkCode;
                users.FkCode = viewModel.FkCode;
                users.Code = viewModel.Code;


                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Emp");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Users viewModel)
        {
            var users = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (users is not null)
            {
                dbContext.Users.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Emp");
        }
    }
}
