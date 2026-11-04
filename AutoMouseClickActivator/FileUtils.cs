using System.IO;

namespace AutoMouseClickActivator
{
    public static class FileUtils
    {
        private const string ExePath = @"C:\Program Files (x86)\Auto Mouse Click by MurGee.com\AutoMouseClick.exe";

        public static long? GetAppCreationTime()
        {
            FileInfo app = new FileInfo(ExePath);

            if (app.Exists)
            {
                return app.CreationTimeUtc.ToFileTimeUtc();
            }
            
            return null;
        }
    }
}