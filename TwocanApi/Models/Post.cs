
using System.Text.Json.Serialization;

namespace TwocanApi.Models;

public class Post
{
    public int Id { get; set; } = 0;
    public int AuthorId { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public int Score { get; set; } = 0;
    public string Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

}
