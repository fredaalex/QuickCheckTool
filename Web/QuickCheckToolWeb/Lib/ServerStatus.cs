using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickCheckToolWeb.Lib
{
    public class ServerStatus
    {
        public ServerStatus(String ip)
        {
            this.Ip = ip;
        }
        public String Ip { private set; get; }

        // TOTAL RAM DISPONÍVEL
        public int FreePhysicalMemory { get; set; }
        //TOTAL RAM
        public int TotalVisibleMemorySize { get; set; }

        public double MemoryUsage
        {
            get
            {
                return (TotalVisibleMemorySize - FreePhysicalMemory) / (double)TotalVisibleMemorySize;
            }

        }
    }
}