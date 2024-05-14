
namespace TwocanApi.Models;

public class User
{
    public int id { get; set; }
    public required string username { get; set; }
    public required string password { get; set; }
    public required string displayName { get; set; }
    // Navigation property representing the posts authored by the user
    public List<Post> posts { get; set; } = new List<Post>();
    public int followers { get; set; }
    public int following { get; set; }
    public required string bio { get; set; }

}

public class UserDTO
{
    public required string username { get; set; }
    public required string password { get; set; }

}