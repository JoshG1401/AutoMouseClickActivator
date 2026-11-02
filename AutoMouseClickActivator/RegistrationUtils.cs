using System;
using System.Linq;

namespace AutoMouseClickActivator
{
    public static class RegistrationUtils
    {
        private const string Seed = "a6THtunBhiLJ-hTyGbpjYuNhbaYGTHlihTaypLpnpnbp0Swdf-PTgfasctfgvcdfL"; // Do not change this or registration will not work
        
        public static string GenerateRegistrationCode(string processorId, string driveSerial)
        {
            string seedDigits = string.Concat(Seed.Select(c => (c % 10).ToString()));

            string machineCode = (seedDigits + processorId + driveSerial).ToLowerInvariant();
            ulong codeSum = 0;

            Console.WriteLine($"Machine code: {machineCode}");
            
            foreach (char c in machineCode)
            {
                codeSum = unchecked(codeSum + c);
            }

            return codeSum.ToString();
        }
    }
}