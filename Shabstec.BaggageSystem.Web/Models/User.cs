namespace BlazorApp.Web.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; } 
        public long ExpirationTimestamp { get; set; }
        public string Organisation { get; set; }
        public bool IsDeleting { get; set; }
    }
}