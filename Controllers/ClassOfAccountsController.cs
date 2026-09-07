
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var classes = await _db.ClassesOfAccount
                    .Include(c => c.SubGroupOfAccounts)
                    .ToListAsync();

            return View(classes);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ClassOfAccountsViewModel();
            await LoadSubGroupsAsync(viewModel);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var classes = await _db.ClassesOfAccount.FindAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            var classesViewModel = new ClassOfAccountsViewModel();
            classesViewModel.Id = (int)id;
            classesViewModel.SubGroupId = classes.SubGroupId;
            classesViewModel.ClassCode = classes.ClassCode;
            classesViewModel.ClassDescription = classes.ClassDescription;
            await LoadSubGroupsAsync(classesViewModel);

            return View(classesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var classes = await _db.ClassesOfAccount.FindAsync(id);
            if (classes == null)
            {
                return NotFound();
            }

            var classesViewModel = new ClassOfAccountsViewModel();
            classesViewModel.Id = (int)id;
            classesViewModel.SubGroupId = classes.SubGroupId;
            classesViewModel.ClassCode = classes.ClassCode;
            classesViewModel.ClassDescription = classes.ClassDescription;

            await LoadSubGroupsAsync(classesViewModel);

            return View(classesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassOfAccountsViewModel viewModelObj)
        {

            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please correct the errors and try again.");
                await LoadSubGroupsAsync(viewModelObj);
                return View(viewModelObj);
            }

            // Initialize the ClassOfAccounts object with the data from the view model
            var classesAccountObj = new ClassOfAccounts
            {
                SubGroupId = viewModelObj.SubGroupId,
                ClassCode = viewModelObj.ClassCode,
                ClassDescription = viewModelObj.ClassDescription
            };

            // Perform custom validation checks
            if (classesAccountObj.ClassCode.Length != 4)
            {
                ModelState.AddModelError("ClassCode", "Class Code must be exactly 4 characters.");
                await LoadSubGroupsAsync(viewModelObj);
                return View(viewModelObj);
            }

            if (string.IsNullOrWhiteSpace(classesAccountObj.ClassDescription) || classesAccountObj.ClassDescription.Length < 15 || classesAccountObj.ClassDescription.Length > 50)
            {
                ModelState.AddModelError("ClassDescription", "Class Description is required and must be between 15 and 50 characters.");
                await LoadSubGroupsAsync(viewModelObj);

                return View(viewModelObj);
            }

            try
            {
                _db.ClassesOfAccount.Add(classesAccountObj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while creating the class of accounts: {ex.Message}");
                await LoadSubGroupsAsync(viewModelObj);
                return View(viewModelObj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClassOfAccountsViewModel viewModelObj)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please correct the errors and try again.");
                await LoadSubGroupsAsync(viewModelObj);
                return View(viewModelObj);
            }

            Console.WriteLine($"Id recebido: {viewModelObj.Id}");

            // Initialize the ClassOfAccounts object with the data from the view model
            var classesAccountObj = new ClassOfAccounts
            {
                Id = viewModelObj.Id,
                SubGroupId = viewModelObj.SubGroupId,
                ClassCode = viewModelObj.ClassCode,
                ClassDescription = viewModelObj.ClassDescription
            };

            // Perform custom validation checks
            if (classesAccountObj.ClassCode.Length != 4)
            {
                ModelState.AddModelError("ClassCode", "Class Code must be exactly 4 characters.");
                await LoadSubGroupsAsync(viewModelObj);
                return View(viewModelObj);
            }

            if (string.IsNullOrWhiteSpace(classesAccountObj.ClassDescription) || classesAccountObj.ClassDescription.Length < 15 || classesAccountObj.ClassDescription.Length > 50)
            {
                ModelState.AddModelError("ClassDescription", "Class Description is required and must be between 15 and 50 characters.");
                await LoadSubGroupsAsync(viewModelObj);

                return View(viewModelObj);
            }

            try
            {
                _db.ClassesOfAccount.Update(classesAccountObj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while creating the class of accounts: {ex.Message}");
                await LoadSubGroupsAsync(viewModelObj);
                return View(viewModelObj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ClassOfAccountsViewModel viewModelObj)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please correct the errors and try again.");
                await LoadSubGroupsAsync(viewModelObj);
                return View(viewModelObj);
            }

            // Initialize the ClassOfAccounts object with the data from the view model
            var classesAccountObj = new ClassOfAccounts
            {
                Id = viewModelObj.Id,
                SubGroupId = viewModelObj.SubGroupId,
                ClassCode = viewModelObj.ClassCode,
                ClassDescription = viewModelObj.ClassDescription
            };

            try
            {
                _db.ClassesOfAccount.Remove(classesAccountObj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while creating the class of accounts: {ex.Message}");
                await LoadSubGroupsAsync(viewModelObj);
                return View(viewModelObj);
            }
        }

        private async Task LoadSubGroupsAsync(ClassOfAccountsViewModel viewModel)
        {
            ArgumentNullException.ThrowIfNull(viewModel);

            viewModel.SubGroups = await _db.SubGroupOfAccounts
                .Select(subGroup => new SelectListItem
                {
                    Value = subGroup.Id.ToString(),
                    Text = subGroup.SubGroupDescription
                })
                .ToListAsync();
        }
    }
}
