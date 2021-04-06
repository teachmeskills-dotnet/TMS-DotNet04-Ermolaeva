using Ermolaeva.Diploma.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Ermolaeva.Diploma.Web.Infrastructure
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        { }

        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
