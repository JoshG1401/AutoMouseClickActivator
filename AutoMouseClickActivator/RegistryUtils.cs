using System;
using System.IO;
using Microsoft.Win32;

namespace AutoMouseClickActivator
{
    public static class RegistryUtils
    {
        private const string RegKey = @"Classes\igfxcui "; // This trailing space is intentional. Needed for regisration to work
        private const string RegName = "EnableNTL";
        private const string MurgeeKey = @"Software\MurGee.com\Auto Mouse Click by MurGee.com\Settings";
        
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

        public static void WriteRectData(string processorId, string volumeSerial, long creationTime)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(MurgeeKey))
            {
                if (key != null)
                {
                    key.SetValue("WindowRect", unchecked((int)RegistrationUtils.ProcessRectData(processorId)), RegistryValueKind.DWord);
                    key.SetValue("WindowRect:", unchecked((int)RegistrationUtils.ProcessRectData(volumeSerial)), RegistryValueKind.DWord);
                    key.SetValue(":WindowRect", unchecked((int)creationTime), RegistryValueKind.DWord);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Additional activation requirements written to the registry");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Could not write additional activation requirements to the registry. Activation may not work.");
                    Console.ResetColor();
                }
            }
        }

        public static void ResetRunCounters()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\user32.dll"))
            {
                key?.SetValue(".ocx", 0, RegistryValueKind.DWord);
            }
            
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\MurGee.com\\Auto Mouse Click by MurGee.com\\Settings"))
            {
                key?.SetValue("MurGee .com", 0, RegistryValueKind.DWord);
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
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Application run counters reset");
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