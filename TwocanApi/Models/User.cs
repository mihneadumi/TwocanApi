
namespace TwocanApi.Models;

public class User
{
    public int id { get; set; }
    public required string username { get; set; }
    public required string displayName { get; set; }
    public List<int> posts { get; set; } = new List<int>();
    public int followers { get; set; }
    public int following { get; set; }
    public required string bio { get; set; }

}