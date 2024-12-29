using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using laboratory_12.Data;
using laboratory_12.Models;
using Microsoft.EntityFrameworkCore;

namespace laboratory_12.Pages.Loans
{
    public class CreateModel : PageModel
    {
        private readonly laboratory_12.Data.AppDbContext _context;

        public CreateModel(laboratory_12.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Loan Loan { get; set; } = default!;

 

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Логируем ошибки валидации
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Или используйте любой другой способ логирования
                }
                return Page();
            }
            try
            {

                _context.Loans.Add(Loan);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(string.Empty, "Не удалось сохранить изменения. Попробуйте еще раз.");
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}




//try
//{
//    _context.Loans.Add(Loan);
//    await _context.SaveChangesAsync();
//}
//catch (DbUpdateException ex)
//{
//    // Логируем исключение или выводим сообщение об ошибке
//    ModelState.AddModelError(string.Empty, "Не удалось сохранить изменения. Попробуйте еще раз.");
//    return Page();
//}
