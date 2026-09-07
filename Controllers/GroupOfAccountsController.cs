
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;
using MyBudget.Mappers;
using MyBudget.Models;
using MyBudget.ViewModel;


namespace MyBudget.Controllers;

public class GroupOfAccountsController : Controller
{
    // GET: GroupOfAccounts
    private readonly AppMyBudgetContext _db;

    public GroupOfAccountsController(AppMyBudgetContext db)
    {
        _db = db;
    }

    // GET: GroupOfAccounts
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var groups = await _db.GroupOfAccounts
                              .AsNoTracking()
                              .ToListAsync();

        return View(groups);
    }

    // GET: GroupOfAccounts/Details/5
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var group = await _db.GroupOfAccounts
                              .AsNoTracking()
                              .FirstOrDefaultAsync(m => m.Id == id);

        if (group == null)
        {
            return NotFound();
        }

        var viewModel = new GroupOfAccountsViewModel();
        GroupOfAccountsMapper.MapGroupOfAccountsToViewModel(group, viewModel);

        return View(viewModel);
    }

    // GET: GroupOfAccounts/Create
    [HttpGet]
    public IActionResult Create()
    {
        var viewModel = new GroupOfAccountsViewModel();

        GroupOfAccountsMapper.MapGroupOfAccountsToViewModel(
            new GroupOfAccounts(),
            viewModel);

        return View(viewModel);
    }

    // POST: GroupOfAccounts/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GroupOfAccountsViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var group = new GroupOfAccounts();
            GroupOfAccountsMapper.MapViewModelToGroupOfAccounts(viewModel, group);
            _db.GroupOfAccounts.Add(group);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    // POST: GroupOfAccounts/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, GroupOfAccountsViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var group = await _db.GroupOfAccounts.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            GroupOfAccountsMapper.MapViewModelToGroupOfAccounts(viewModel, group);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var group = await _db.GroupOfAccounts
                              .AsNoTracking()
                              .FirstOrDefaultAsync(m => m.Id == id);

        if (group == null)
        {
            return NotFound();
        }

        var viewModel = new GroupOfAccountsViewModel();
        GroupOfAccountsMapper.MapGroupOfAccountsToViewModel(group, viewModel);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, GroupOfAccountsViewModel viewModel)
    {
        var group = await _db.GroupOfAccounts.FindAsync(id);
        if (group == null)
        {
            return NotFound();
        }

        _db.GroupOfAccounts.Remove(group);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
