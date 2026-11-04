using System;

namespace AutoMouseClickActivator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "AutoMouseClicker by Murgee Activator";

            if (RegistryUtils.HasExistingKey())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("An existing registry key was found for AutoMouseClick activation.");
                Console.Write("Do you wish to proceed with activation again? This will overwrite the current values (y/N): ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || input.ToLower() != "y")
                {
                    Exit();
                }
            }
            
            Console.Clear();
            Console.WriteLine("This application will modify registry values!");
            Console.WriteLine("None of these values are critical and will not affect your system.");
            Console.WriteLine("");
            Console.Write("Do you wish to continue? (y/N)");
            string continueChoice = Console.ReadLine();

            if (string.IsNullOrEmpty(continueChoice) || continueChoice.ToLower() != "y")
            {
                Exit();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Acquiring parameters needed for registration...");
            
            string windowsDrive = DiskUtils.GetWindowsDrive();
            string windowsDriveSerial = DiskUtils.GetDiskSerial(windowsDrive);
            string windowsVolumeSerial = DiskUtils.GetVolumeSerial();
            string processorId = ProcessorUtils.GetProcessorId();
            long? appCreationTime = FileUtils.GetAppCreationTime();
            
            if(string.IsNullOrEmpty(windowsDrive) || string.IsNullOrEmpty(windowsDriveSerial) || string.IsNullOrEmpty(processorId) || !appCreationTime.HasValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to get all needed info for registration");
                Console.ResetColor();
                
                Exit();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Parameters acquired successfully");
            
            Console.WriteLine("");
            
            string regisrationCode = RegistrationUtils.GenerateRegistrationCode(processorId, windowsDriveSerial);
            
            RegistryUtils.WriteKeyToRegistry(regisrationCode);
            RegistryUtils.WriteRectData(processorId, windowsVolumeSerial, unchecked((uint)appCreationTime));
            RegistryUtils.ResetRunCounters();
            Console.ResetColor();
            
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