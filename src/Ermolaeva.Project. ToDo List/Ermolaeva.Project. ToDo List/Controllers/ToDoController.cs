using Ermolaeva.Project._ToDo_List.Infrastructure;
using Ermolaeva.Project._ToDo_List.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ermolaeva.Project._ToDo_List.Controllers
{
    public class ToDoController : Controller
    {

        private readonly ToDoContext context;

        public ToDoController (ToDoContext context)
            {
            this.context = context;
            }

        // Get / 
        public async Task<ActionResult>Index()
        {
            IQueryable<ToDoList> items = from i in context.ToDoList orderby i.Id select i;

            List<ToDoList> toDoList = await items.ToListAsync();

            return View(toDoList);
        }

        // Get ToDo create

        public IActionResult Create() => View();

        // post/ todo/create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);

                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been added!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public async Task<ActionResult> Edit(int id)
        {
            ToDoList item = await context.ToDoList.FindAsync(id);

            if (item==null)
            {
                return NotFound();

            }
            return View(item);
        }

        // post/ todo/edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);

                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<ActionResult> Delete(int id)
        {
            ToDoList item = await context.ToDoList.FindAsync(id);

            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";

            }
            else
            {
                context.ToDoList.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }
            return RedirectToAction("Index");
        }

    }
}
