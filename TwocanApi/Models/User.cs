
namespace TwocanApi.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string DisplayName { get; set; }
    public int Posts { get; set; }
    public int Followers { get; set; }
    public int Following { get; set; }
    public required string Bio { get; set; }

}