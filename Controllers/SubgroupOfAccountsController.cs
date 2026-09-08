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
    public class SubGroupOfAccountsController : Controller
    {
        private readonly AppMyBudgetContext _db;

        public SubGroupOfAccountsController(AppMyBudgetContext db)
        {
            _db = db;
        }

        //
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subgroups = await _db.SubGroupOfAccounts
                            .Include(c => c.GroupOfAccounts)
                            .AsNoTracking()
                            .ToListAsync();

            return View(subgroups);
        }

        //
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var subGroup = await _db.SubGroupOfAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (subGroup == null)
            {
                return NotFound();
            }

            var viewModel = new SubGroupOfAccountsViewModel
            {
                Id = subGroup.Id,
                SubGroupDescription = subGroup.SubGroupDescription,
                GroupId = subGroup.GroupId,
                Groups = await _db.GroupOfAccounts
                    .AsNoTracking()
                    .OrderBy(x => x.GroupDescription)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.GroupDescription
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var viewModel = new SubGroupOfAccountsViewModel
            {
                Id = 0,
                SubGroupDescription = string.Empty,
                GroupId = 0,
                Groups = await _db.GroupOfAccounts

                    .AsNoTracking()
                    .OrderBy(x => x.GroupDescription)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.GroupDescription
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubGroupOfAccountsViewModel viewModel)
        {
            var subgroupACC = new SubGroupOfAccounts()
            {
                SubGroupDescription = viewModel.SubGroupDescription,
                GroupId = viewModel.GroupId
            };

            try
            {
                _db.SubGroupOfAccounts.Add(subgroupACC);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Catch-all for any other unexpected errors
                return BadRequest(error: $"A generic error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SubGroupOfAccountsViewModel viewModel)
        {
            var subGroup = new SubGroupOfAccounts()
            {
                Id = id,
                SubGroupDescription = viewModel.SubGroupDescription,
                GroupId = viewModel.GroupId,
            };

            try
            {
                _db.SubGroupOfAccounts.Update(subGroup);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Catch-all for any other unexpected errors
                return BadRequest(error: $"A generic error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var subGroup = await _db.SubGroupOfAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (subGroup == null)
            {
                return NotFound();
            }

            var viewModel = new SubGroupOfAccountsViewModel
            {
                Id = subGroup.Id,
                SubGroupDescription = subGroup.SubGroupDescription,
                GroupId = subGroup.GroupId,
                Groups = await _db.GroupOfAccounts
                    .AsNoTracking()
                    .OrderBy(x => x.GroupDescription)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.GroupDescription
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SubGroupOfAccountsViewModel viewModel)
        {
            var subGroup = await _db.SubGroupOfAccounts.FindAsync(id);
            if (subGroup == null)
            {
                return NotFound();
            }

            try
            {
                _db.SubGroupOfAccounts.Remove(subGroup);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Catch-all for any other unexpected errors
                return BadRequest(error: $"A generic error occurred: {ex.Message}");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}