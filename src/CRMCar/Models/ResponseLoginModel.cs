namespace CRMCar.Models
{
    public class ResponseLoginModel
    {
        public string FullName { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
