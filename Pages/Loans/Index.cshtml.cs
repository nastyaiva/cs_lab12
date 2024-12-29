﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using laboratory_12.Data;
using laboratory_12.Models;

namespace laboratory_12.Pages.Loans
{
    public class IndexModel : PageModel
    {
        private readonly laboratory_12.Data.AppDbContext _context;

        public IndexModel(laboratory_12.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Loan> Loan { get;set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                Loan = await _context.Loans.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении займов: {ex.Message}");
                Loan = new List<Loan>(); 
            }
        }

    }
}
