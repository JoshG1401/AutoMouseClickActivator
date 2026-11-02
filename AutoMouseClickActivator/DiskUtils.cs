using System;
using System.IO;
using System.Management;

namespace AutoMouseClickActivator
{
    public static class DiskUtils
    {
        public static string GetWindowsDrive()
        {
            string systemDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.Windows));
            
             using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"ASSOCIATORS OF {{Win32_LogicalDisk.DeviceID='{systemDrive.TrimEnd('\\')}'}} WHERE AssocClass=Win32_LogicalDiskToPartition"))
             {
                 using (ManagementObjectCollection drivePartitions = searcher.Get())
                 {
                     foreach (ManagementBaseObject partition in drivePartitions)
                     {
                         string partitionId = partition["DeviceID"].ToString();

                         using (ManagementObjectSearcher diskSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
                         {
                             using (ManagementObjectCollection diskCollection = diskSearcher.Get())
                             {
                                 foreach (ManagementBaseObject disk in diskCollection)
                                 {
                                     string diskId = disk["DeviceID"].ToString();

                                     using (ManagementObjectSearcher assocSearcher = new ManagementObjectSearcher($"ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{diskId}'}} WHERE AssocClass=Win32_DiskDriveToDiskPartition"))
                                     {
                                         using (ManagementObjectCollection associtations = assocSearcher.Get())
                                         {
                                             foreach (ManagementBaseObject associtation in associtations)
                                             {
                                                 if (associtation["DeviceID"].ToString() == partitionId)
                                                 {
                                                     return diskId;
                                                 }
                                             }
                                         }
                                     }
                                 }
                             }
                         }
                     }
                 }
             }

             return null;
        }
    }
}