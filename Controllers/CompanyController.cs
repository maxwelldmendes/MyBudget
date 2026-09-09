using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;
using MyBudget.Models;
using MyBudget.ViewModel;

namespace MyBudget.Controllers;

public class CompanyController : Controller
{
	private readonly AppMyBudgetContext _db;

	public CompanyController(AppMyBudgetContext db)
	{
		_db = db;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var companyList = await _db.Company
						.Include(c => c.CompanyAddress)
						.Include(c => c.LegalAddress)
						.ToListAsync();

		return View(companyList);
	}

	[HttpGet]
	public async Task<IActionResult> Create()
	{
		var companyList = new CompanyViewModel();

		return View(companyList);
	}


	[HttpPost]
	public async Task<IActionResult> Create(CompanyViewModel companyVM)
	{
		


		var companyList = await _db.Company
						.Include(c => c.CompanyAddress)
						.Include(c => c.LegalAddress)
						.ToListAsync();

		return View(companyList);
	}







	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View("Error!");
	}
}
