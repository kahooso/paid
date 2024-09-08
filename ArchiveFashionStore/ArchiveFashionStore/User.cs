namespace ArchiveFashionStore
{
    public class User
    {
        public string login { get; set; }
        public bool isAdmin { get; }
        public string Status => isAdmin ? "admin" : "user";
        public User(string login, bool isAdmin) { this.login = login.Trim(); this.isAdmin = isAdmin; }
    }
}
