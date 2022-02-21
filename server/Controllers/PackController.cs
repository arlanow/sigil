using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class PackController : ControllerBase
{
   
    public PackController()
    {
    }

    public class PacksContext : DbContext
    {
        public DbSet<server.Model.Pack> Packs { get; set; }

       public PacksContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sigil;Username=sigil;Password=sigil");
        }
    }

    [HttpGet(Name = "GetPack")]
    public IEnumerable<Model.Pack> Get()
    {
        using (PacksContext db = new PacksContext())
            {
                return db.Packs.ToList();
            }
    }
}
