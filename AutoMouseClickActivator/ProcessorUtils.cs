using System.Management;

namespace AutoMouseClickActivator
{
    public static class ProcessorUtils
    {
        public static string GetProcessorId()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor"))
            {
                using(ManagementObjectCollection processors = searcher.Get())
                {
                    foreach (ManagementBaseObject processor in processors)
                    {
                        string processorId = processor["ProcessorId"].ToString();
                            
                        if(!string.IsNullOrEmpty(processorId))
                        {
                            return processorId;
                        }
                    }
                }
            }

            return null;
        }
    }
}