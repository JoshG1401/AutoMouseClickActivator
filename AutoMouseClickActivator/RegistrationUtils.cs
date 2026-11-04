namespace AutoMouseClickActivator
{
    public static class RegistrationUtils
    {
        private const string Seed = "74426706456454411826978487914285447126202082839025043275962389026"; // Do not change this or registration will not work
        
        public static string GenerateRegistrationCode(string processorId, string driveSerial)
        {
            string machineCode = (Seed + processorId + driveSerial).ToLowerInvariant();
            uint codeSum = 0;
            
            foreach (char c in machineCode)
            {
                codeSum = unchecked(codeSum + c);
            }

            return codeSum.ToString();
        }

        public static uint ProcessRectData(string input)
        {
            uint result = 1;

            foreach (char c in input)
            {
                result = unchecked(result * c);
            }

            return result;
        }
    }
}