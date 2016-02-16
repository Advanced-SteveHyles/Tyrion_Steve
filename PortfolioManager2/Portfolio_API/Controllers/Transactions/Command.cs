using System;
using Interfaces;

namespace Portfolio_API.Controllers.Transactions
{
    internal class Command
    {
        
        internal static bool ExecuteCommand(ICommandRunner command)
        {
            try
            {
                if (!command.CommandValid) return false;

                command.Execute();
                return command.ExecuteResult;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return false;
            }            
        }
    }   
}