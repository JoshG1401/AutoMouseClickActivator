using System;
using System.IO;
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

        public static void ResetRunCounters()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\user32.dll"))
            {
                key?.SetValue(".ocx", 0);
            }
            
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\MurGee.com\\Auto Mouse Click by MurGee.com\\Settings"))
            {
                key?.SetValue("MurGee .com", 0);
            }
            
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft"))
            {
                key?.DeleteSubKey("Chrome", false);
            }

            string usbFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\Edge\\User Data\\input\\usb";

            if (File.Exists(usbFile))
            {
                File.Delete(usbFile);
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