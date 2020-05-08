
namespace PeopleDatabase
{
    public class Man
    {
        public Man(int id, string username)
        {
            this.ID = id;
            this.Username = username;
        }
        public int ID { get; set; }
        public string Username { get; set; }
    }
}
