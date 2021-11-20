using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursProj5sem
{
    public static class CPUInfo
    {
        public static int TotalUsage= new int();
        public static List<Core> Cores = new List<Core>();  
        
    }
    public class Core
    {
        public string? CPUCoreName;
        public int CPUCoreUsage;
    }
}
