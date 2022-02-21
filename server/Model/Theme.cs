using System.ComponentModel.DataAnnotations;

namespace server.Model;
public class Theme
{
    public Guid round_uid { get; set; }
    [Key]
    public Guid uid { get; set; }
    public string theme { get; set; }
}