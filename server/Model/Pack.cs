using System.ComponentModel.DataAnnotations;

namespace server.Model;
public class Pack
{
    [Key]
    public Guid uid { get; set; }
    public string author { get; set; }
    public string title { get; set; }
}