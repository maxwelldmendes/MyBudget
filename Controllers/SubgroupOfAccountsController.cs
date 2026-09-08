using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;
using MyBudget.Mappers;
using MyBudget.Models;
using MyBudget.ViewModel;

namespace MyBudget.Controllers
{
    public class SubgroupOfAccountsController : Controller
    {
        private readonly AppMyBudgetContext _db;

        public SubgroupOfAccountsController(AppMyBudgetContext db)
        {
            _db = db;
        }
        //
        public async Task<IActionResult> Index()
        {
            var subgroups = await _db.SubGroupOfAccounts
                            .Include(c => c.GroupOfAccounts)
                            .AsNoTracking()
                            .ToListAsync();

            return View(subgroups);
        }

        //
        public async Task<IActionResult> Edit(int? id)
        {
            var subGroup = await _db.SubGroupOfAccounts
                            .Include(c => c.GroupOfAccounts)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(c => c.Id == id);

            if (subGroup == null)
            {
                return NotFound();
            }
            /*
                        var groupClass = await _db.GroupOfAccounts
                            .FirstOrDefaultAsync(group => group.Id == subGroup.GroupId);

                        if (groupClass == null)
                        {
                            return NotFound();
                        }

                        subGroup.GroupOfAccounts.Id = subGroup.GroupId;
                        subGroup.GroupOfAccounts.GroupDescription = groupClass.GroupDescription;
                        subGroup.GroupOfAccounts.GroupInformation = groupClass.GroupInformation;

            */
            var subGroupsVM = new SubGroupOfAccountsViewModel();

            SubGroupOfAccountsMapper.MapSubGroupOfAccountsToViewModel(subGroup, subGroupsVM);


            return View(subGroupsVM);
        }

        private object SubGroupOfAccountsViewModel(List<SubGroupOfAccounts> subroups, AppMyBudgetContext db)
        {
            throw new NotImplementedException();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


















    }
}