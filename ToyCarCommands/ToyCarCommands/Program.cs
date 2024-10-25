using System;

namespace ToyCarCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a command for the toy car (e.g., Start Right). Type 'Exit' to quit.");

            while (true)
            {
                string input = Console.ReadLine();

                // Check for exit command
                if (input.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                {
                    break; // Exit the loop
                }

                string result = ParseCommand(input);
                Console.WriteLine(result);
            }
        }

        static string ParseCommand(string command)
        {
            // Split the command into parts
            string[] parts = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Check if the command has at least one part (for the command) and one part (for the action)
            if (parts.Length >= 1)
            {
                string cmd = parts[0];
                string action = parts.Length > 1 ? parts[1] : null; // Check if action is provided

                // Validate the command based on the CFG
                if (IsValidCommand(cmd, action))
                {
                    return "Command is valid!";
                }
            }

            return "Invalid command. Please use the correct syntax (e.g., Start Right).";
        }

        static bool IsValidCommand(string cmd, string action)
        {
            // Define valid commands and actions
            string[] validCommands = { "Start", "Stop", "Accelerate", "Brake" };
            string[] validActions = { "Right" }; // Note: 'Left' is not executed

            // Check if the command is valid
            bool isCmdValid = Array.Exists(validCommands, c => c.Equals(cmd, StringComparison.OrdinalIgnoreCase));
            bool isActionValid = action != null && Array.Exists(validActions, a => a.Equals(action, StringComparison.OrdinalIgnoreCase));

            // Return true if the command is valid, action is either valid or null
            return isCmdValid && (action == null || isActionValid);
        }
    }
}
