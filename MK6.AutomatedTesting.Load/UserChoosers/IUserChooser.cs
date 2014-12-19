using System.Collections.Generic;

namespace MK6.AutomatedTesting.Load.UserChoosers
{
    public interface IUserChooser
    {
        User Choose(IterationContext context);
    }
}
