namespace MK6.AutomatedTesting.Load
{
    public class User
    {
        public readonly string Username;
        public readonly string Password;
        public readonly string Persona;

        public User(string username, string password)
            : this(username, password, string.Empty)
        { }

        public User(string username, string password, string persona)
        {
            Username = username;
            Password = password;
            Persona = persona;
        }
    }
}
