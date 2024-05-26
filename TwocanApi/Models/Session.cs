namespace TwocanApi.Models
{
    public class Session
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }

    public class SessionDTO
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
}
