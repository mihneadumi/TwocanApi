
namespace TwocanApi.Models;

public class User
{
    public int id { get; set; }
    public required string username { get; set; }
    public required string displayName { get; set; }
    public int posts { get; set; }
    public int followers { get; set; }
    public int following { get; set; }
    public required string bio { get; set; }

}