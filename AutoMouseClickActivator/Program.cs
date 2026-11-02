using System;

namespace AutoMouseClickActivator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "AutoMouseClicker by Murgee Activator";
            
            string windowsDrive = DiskUtils.GetWindowsDrive();
            string windowsDriveSerial = DiskUtils.GetDiskSerial(windowsDrive);
            string processorId = ProcessorUtils.GetProcessorId();
            
            Console.WriteLine("Using below parameters for registration calculation:");
            Console.WriteLine($"Windows Drive: {windowsDrive}");
            Console.WriteLine($"Windows Drive Serial: {windowsDriveSerial}");
            Console.WriteLine($"Processor ID: {processorId}");
            
            Console.WriteLine("");
            string regisrationCode = RegistrationUtils.GenerateRegistrationCode(processorId, windowsDriveSerial);
            Console.WriteLine($"Regisration code: {regisrationCode}");
            
            RegistryUtils.WriteKeyToRegistry(regisrationCode);
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}