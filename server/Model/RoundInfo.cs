using System.ComponentModel.DataAnnotations;

namespace server.Model;
public class RoundInfo
{
    [Key]
    public string theme { get; set; }
    public List<Question> questions { get; set; }
}