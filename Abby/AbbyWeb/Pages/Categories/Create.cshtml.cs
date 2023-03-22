using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
       // [BindProperty] èëè ìîæíî ñâåðõó ïðîïèñàòü [BindProperties]
        public Category Category { get; set; }

        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }


        //ÏÎ×ÅÌÓ ÎÍ ÒÀÊ ÍÀÏÈÑÀË => public Category Category { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Category category)
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created succesfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
