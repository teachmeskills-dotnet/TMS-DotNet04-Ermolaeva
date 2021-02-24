using Ermolaeva.Project._ToDo_List.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ermolaeva.Project._ToDo_List.Infrastructure
{
    public class ToDoContext : DbContext
    {
        public ToDoContext (DbContextOptions<ToDoContext> options)
            :base (options)
            {}
        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
