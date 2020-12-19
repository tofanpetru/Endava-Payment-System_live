using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp3.Server.Helpers
{
    public class CommandResult
    {
        public bool IsSuccessful { get; set; }

        public static CommandResult ReturnSuccess()
        {
            return new CommandResult { IsSuccessful = true };
        }

        public static CommandResult ReturnFailure()
        {
            return new CommandResult { IsSuccessful = false };
        }
    }
}
