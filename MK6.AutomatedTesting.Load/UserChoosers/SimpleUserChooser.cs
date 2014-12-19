using System.Collections.Generic;

namespace LoadTest.Vcp.Requests.UserChoosers
{
    public class SimpleUserChooser : BaseUserChooser
    {
        public SimpleUserChooser(IReadOnlyList<User> users) : base(users)
        {
        }

        public override User Choose(int threadIndex)
        {
            var numberOfUsers = Users.Count;
            var toReturn = Users[threadIndex % numberOfUsers];

            return toReturn;
        }
    }
}
