using Odev1.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Odev1.Models.DTO_s;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Odev1.Controllers
{
	public class EmployeesController : Controller
	{
		private readonly NorthwindContext dbContext;
        private readonly IMapper mapper;

        public EmployeesController(NorthwindContext dbContext, IMapper mapper)
        {
			this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
		{
			if(dbContext.Employees != null)
			{
				return View(await dbContext.Employees.ToListAsync());
			}
			else
			{
				return Problem("Entity set 'NorthwindContext.Employees' is null.");
			}
		}
        
        [HttpGet]
        public IActionResult Create()
        {
            EmployeeCreateDTO createDTO = new();
            return View(createDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(createDTO);
            }
            try
            {
                var employee = mapper.Map<Employee>(createDTO);
                dbContext.Add(employee);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createDTO);
            }
        }
    }
}
