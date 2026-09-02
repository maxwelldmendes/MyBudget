
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;
using MyBudget.Models;
using MyBudget.ViewModel;

namespace MyBudget.Controllers
{
    public class ClassOfAccountsController : Controller
    {
        private readonly AppMyBudgetContext _db;

        public ClassOfAccountsController(AppMyBudgetContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> Create()
        {
            var viewModel = new ClassOfAccountsViewModel
            {
                SubGroups = await _db.SubGroupOfAccounts
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.SubGroupDescription
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClassOfAccountsViewModel viewModelObj)
        {
            var classesAccountObj = new ClassOfAccounts
            {
                Id = viewModelObj.ClassOfAccounts.Id,
                SubGroupId = (int)viewModelObj.SubGroupId,
                ClassCode = viewModelObj.ClassOfAccounts.ClassCode,
                ClassDescription = viewModelObj.ClassOfAccounts.ClassDescription
            };

            _db.ClassesOfAccount.Add(classesAccountObj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            var classes = await _db.ClassesOfAccount
                    .Include(c => c.SubGroupOfAccounts)
                    .ToListAsync();

            return View(classes);
        }
    }
}
