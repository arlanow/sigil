using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionController : ControllerBase
{
   
    public QuestionController()
    {
    }

    public class PacksContext : DbContext
    {
        public DbSet<server.Model.Question> Questions { get; set; }

       public PacksContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sigil;Username=sigil;Password=sigil");
        }
    }
    [Route("")]
    [Route("{uid}")]
    [HttpGet(Name = "GetQuestion")]
    public Model.Question Get(Guid uid)
    {
        using (PacksContext db = new PacksContext())
            {
                return db.Questions.Where(x => x.uid == uid).FirstOrDefault();
            }
    }
}
