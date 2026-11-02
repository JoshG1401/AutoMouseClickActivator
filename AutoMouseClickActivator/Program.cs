using System;

namespace AutoMouseClickActivator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "AutoMouseClicker by Murgee Activator";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Acquiring parameters needed for registration...");
            
            string windowsDrive = DiskUtils.GetWindowsDrive();
            string windowsDriveSerial = DiskUtils.GetDiskSerial(windowsDrive);
            string processorId = ProcessorUtils.GetProcessorId();
            
            if(string.IsNullOrEmpty(windowsDrive) || string.IsNullOrEmpty(windowsDriveSerial) || string.IsNullOrEmpty(processorId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to get all needed info for registration");
                Console.ResetColor();
                
                Exit();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Parameters acquired successfully");
            
            Console.ResetColor();
            Console.WriteLine("");
            string regisrationCode = RegistrationUtils.GenerateRegistrationCode(processorId, windowsDriveSerial);
            
            Console.WriteLine("");
            Console.WriteLine("Registration code has been generated");
            Console.Write("Would you like to save it to registry? (y/N): ");
            string choice = Console.ReadLine();
            
            if(string.IsNullOrEmpty(choice) || choice.ToLower() != "y")
            {
                Exit();
            }
            
            RegistryUtils.WriteKeyToRegistry(regisrationCode);
            Exit();
        }

        private static void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            
            Environment.Exit(0);
        }
    }
}