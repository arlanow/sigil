using System.ComponentModel.DataAnnotations;

namespace server.Model;
public class Question
{
    [Key]
    public Guid uid { get; set; }
    public Guid theme_uid { get; set; }
    public string question { get; set; }
    public string? additional_info { get; set; }
    public int cost { get; set; }
    public Guid? file_uid { get; set; }
    public List<string>? right_answers { get; set; }
    public List<string>? wrong_answers { get; set; }
}