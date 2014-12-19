using System.Collections.Generic;
using System.Linq;

namespace MK6.AutomatedTesting.Load.UserChoosers
{
    public class PersonaUserChooser : UserChooser
    {
        public PersonaUserChooser(IReadOnlyList<User> users, string persona)
            : base(users.Where(u => u.Persona == persona).ToList().AsReadOnly())
        {
        }
    }
}
