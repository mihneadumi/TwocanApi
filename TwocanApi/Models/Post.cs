
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TwocanApi.Models;

public class Post
{
    public int id { get; set; } = 0;
    public int authorId { get; set; }
    [JsonIgnore]
    public User author { get; set; }
    public required string title { get; set; }
    public string? content { get; set; }
    public int score { get; set; } = 0;
    public string date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

}

public class PostDTO
{
    public int? id { get; set; } = 0;
    public required int authorId { get; set; }
    public required string title { get; set; }
    public string? content { get; set; }
    public int? score { get; set; } = 0;
    public string? date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
}
