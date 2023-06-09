using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
       // [BindProperty] ��� ����� ������ ��������� [BindProperties]
        public Category Category { get; set; }

        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }


        //������ �� ��� ������� => public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
            //Category = _db.Category.FirstOrDefault(u=> u.Id == id);
            //Category = _db.Category.SingleOrDefault(u=> u.Id == id);
            //Category = _db.Category.Where(u=> u.Id == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost(Category category)
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated succesfully";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
