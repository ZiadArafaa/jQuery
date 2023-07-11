using jQuery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Dynamic.Core;
using System.Linq;
using jQuery.Filters;
using jQuery.Data;

namespace jQuery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAll()
        {
            IQueryable<Author> Authors = _context.Authors;

            var start = int.Parse(Request.Form["start"]);
            var length = int.Parse(Request.Form["length"]);
            var columnOrderedIndex = int.Parse(Request.Form["order[0][column]"]);
            var columnOrderedName = Request.Form[$"columns[{columnOrderedIndex}][data]"];
            var orderDir = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];

            var Count = Authors.Count();
            Authors = Authors.OrderBy($"{columnOrderedName} {orderDir}");

            var Data = Authors.Where(a => a.Email.Contains(searchValue) || a.Name.Contains(searchValue)).Skip(start).Take(length).ToList();

            return Ok(new { recordsTotal = Count, recordsFiltered = Count, Data });
        }
        [AjaxOnly]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public IActionResult Create(Author model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            _context.Add(model);
            _context.SaveChanges();

            return Ok();
        }
        [AjaxOnly]
        public IActionResult Update(int id)
        {
            var model = _context.Authors.Find(id);
            if (model is null)
                return NotFound();

            return PartialView("_Update", model);
        }
        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            _context.Update(model);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = _context.Authors.Find(id);
            if (model is null)
                return NotFound();

            _context.Remove(model);
            _context.SaveChanges();

            return Ok();
        }
    }
}