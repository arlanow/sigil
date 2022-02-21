using System.ComponentModel.DataAnnotations;

namespace server.Model;
public class Round
{
    [Key]
    public Guid uid { get; set; }
    public Guid pack_uid { get; set; }
    public string title { get; set; }
    public int number { get; set; }
}