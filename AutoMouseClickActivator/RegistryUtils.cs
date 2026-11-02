using System;
using Microsoft.Win32;

namespace AutoMouseClickActivator
{
    public static class RegistryUtils
    {
        private const string RegKey = @"Classes\igfxcui "; // This trailing space is intentional. Needed for regisration to work
        private const string RegName = "EnableNTL";
        
        public static void WriteKeyToRegistry(string registrationCode)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegKey))
            {
                if (key != null)
                {
                    key.SetValue(RegName, registrationCode);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registration key has been saved to the registry");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Could not create registry key! Regisration key has not been saved to the registry");
                    Console.ResetColor();
                }
            }
        }

        public static bool HasExistingKey()
        {
            using(RegistryKey key = Registry.CurrentUser.OpenSubKey(RegKey))
            {
                return key != null;
            }
        }
    }
}