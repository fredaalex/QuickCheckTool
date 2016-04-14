using QuickCheckToolWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickCheckToolWeb.Lib
{
    public class ServerStatus
    {
        public ServerStatus(String ip, String id, NewServerModel config)
        {
            this.Ip = ip;
            this.Id = id;
            this.Config = config;
        }
        public NewServerModel Config { get; set; }
        public String Ip { private set; get; }
        public String Id { private set; get; }
        

        // TOTAL RAM DISPONÍVEL
        public int FreePhysicalMemory { get; set; }
        //TOTAL RAM
        public int TotalVisibleMemorySize { get; set; }

        public int MemoryUsage
        {
            get
            {
                return (int)((TotalVisibleMemorySize - FreePhysicalMemory) / (double)TotalVisibleMemorySize * 100);
            }

        }
        // TOTAL HD DISPONÍVEL
        public long HDFreeSpace { get; set; }

        // TOTAL HD
        public long HDSize { get; set; }

        public int HDUsage
        {
            get
            {
                return (int)((HDSize - HDFreeSpace) / (double)HDSize * 100);
            }

        }

        public string OSName { get; set; }

        public string ProcessorName { get; set; }

        public int ProcessorUsage { get; set; }

        public string StatusColor {
            get
            {


                if(ProcessorUsage >= Config.ProcessPercentualThreshold)
                {
                    return "red";
                }
                if(HDUsage >= Config.HDPercentualThreshold)
                {
                    return "red";
                }

                if(MemoryUsage > Config.MemoryPercentualThreshold)
                {
                    return "red";
                }

                return "green";
                /*
                switch (new Random().Next(4))
                {
                    case 0:
                        return "green";
                    case 1:
                        return "yellow";
                    case 2:
                        return "red";
                    default:
                        return "blue";
                }
                */
            }
        }
    }
}