using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class RoundInfoController : ControllerBase
{
   
    public RoundInfoController()
    {
    }

    public class PacksContext : DbContext
    {
        public DbSet<server.Model.Theme> Themes { get; set; }
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
    [Route("{rounduid}")]
    [HttpGet(Name = "GetRoundInfo")]
    public IEnumerable<Model.RoundInfo> Get(Guid rounduid)
    {
        using (PacksContext db = new PacksContext())
            {
                var roundInfos = new List<Model.RoundInfo>();
                var themes = db.Themes.Where(x => x.round_uid == rounduid).ToList();
                foreach (Model.Theme theme in themes)
                {
                    Model.RoundInfo info = new Model.RoundInfo();
                    info.theme = theme.theme;
                    info.questions = db.Questions.Where(x => x.theme_uid == theme.uid).ToList();
                    roundInfos.Add(info);
                }
                return roundInfos;
            }
    }
}
