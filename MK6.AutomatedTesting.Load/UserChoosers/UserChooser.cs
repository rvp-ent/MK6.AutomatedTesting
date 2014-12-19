using System.Collections.Generic;

namespace MK6.AutomatedTesting.Load.UserChoosers
{
    public class UserChooser : IUserChooser
    {
        public readonly IReadOnlyList<User> Users;

        public UserChooser(IReadOnlyList<User> users)
        {
            this.Users = users;
        }

        public virtual User Choose(IterationContext context)
        {
            return this.Users[context.WorkerIndex % this.Users.Count];
        }
    }
}
