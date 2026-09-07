Para criar uma API am ASP.NET C# precisamos dos seguintes pacotes:

	1. dotnet add package Microsoft.AspNetCore.OpenApi   
	2. dotnet add package Scalar.AspNetCore --version 2.17.2
	3. dotnet add package Microsoft.EntityFrameworkCore --version 10.0.11
	4. dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 10.0.11
	5. dotnet add package Microsoft.EntityFrameworkCore.Tools --version 10.0.11
	6. dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.0.11
	
	Estrutura do Projeto:
	
	MyBudget
		+-------- Controllers
		|
		+-------- Data
		|         +-------------- Configurations
		|
		+-------- Database
		|
		+-------- Models
		|
		+-------- ViewModel
		|
		+-------- Views
		
		
	Para cada model (Persistido no DB) criar:
		1. Um controller.cs
		2. Um ViewModel
		3. Uma pasta dentro da pasta Views com o nome do Controller 
		4. Arquivos cshtml
		
		Para fazer o CRUD devemos programar os metodos seguintes:
		
		
+--------------------------------------------------------+
+-------------- Classe de controle ----------------------+
+--------------------------------------------------------+
public class GroupOfAccountsController : Controller
{
// GET: GroupOfAccounts
private readonly AppMyBudgetContext _db;
public GroupOfAccountsController(AppMyBudgetContext db)
{
	_db = db;
}
	
+--------------------------------------------------------+
+---------------- GET: GroupOfAccounts ------------------+
+--------------------------------------------------------+
// GET: GroupOfAccounts
[HttpGet]
public async Task<IActionResult> Index()
{
	var groups = await _db.GroupOfAccounts
						  .AsNoTracking()
						  .ToListAsync();

	return View(groups);
}

+--------------------------------------------------------+
+----------- GET: GroupOfAccounts/Details/Id ------------+
+--------------------------------------------------------+
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
	
+--------------------------------------------------------+
+------------- GET: GroupOfAccounts/Create --------------+
+--------------------------------------------------------+
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
	
+--------------------------------------------------------+
+------------- GET: GroupOfAccounts/Delete --------------+
+--------------------------------------------------------+
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

+--------------------------------------------------------+
+------------ POST: GroupOfAccounts/Create --------------+
+--------------------------------------------------------+	
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

+--------------------------------------------------------+
+------------ POST: GroupOfAccounts/Edit/Id -------------+
+--------------------------------------------------------+	
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

+--------------------------------------------------------+
+----------- POST: GroupOfAccounts/Delete/Id ------------+
+--------------------------------------------------------+	
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
}

		