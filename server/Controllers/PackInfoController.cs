using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class PackInfoController : ControllerBase
{
   
    public PackInfoController()
    {
    }

    public class PacksContext : DbContext
    {
        public DbSet<server.Model.Pack> Packs { get; set; }
        public DbSet<server.Model.Round> Rounds { get; set; }

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
    [Route("Round")]
    [Route("Round/{packuid}")]
    [HttpGet(Name = "GetRound")]
    public IEnumerable<Model.Round> Get(Guid packuid)
    {
        using (PacksContext db = new PacksContext())
            {
                return db.Rounds.Where(x => x.pack_uid == packuid).ToList();
            }
    }
}
