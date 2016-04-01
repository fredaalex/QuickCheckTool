using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Web;
using baileysoft.Wmi;

namespace QuickCheckToolWeb.Lib
{
    public class QuickCheckWorker
    {
        public static void StartWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(DoWork);
            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted +=
                   new RunWorkerCompletedEventHandler(WorkerCompleted);
            worker.RunWorkerAsync();
        }
    

        public static void DoWork(object sender, DoWorkEventArgs e)
        {

            Connection wmiConnection = new Connection();
            ServerStatus serverStatus = new ServerStatus("localhost");
            
            //List<Dictionary<String, String>> os = WMIReader.GetPropertyValues(wmiConnection, "Win32_OperatingSystem");
            Dictionary<String, String> os = WMIReader.GetPropertyValues(wmiConnection, "Win32_OperatingSystem")[0];
            serverStatus.FreePhysicalMemory = int.Parse(os["FreePhysicalMemory"]);
            serverStatus.TotalVisibleMemorySize = int.Parse(os["TotalVisibleMemorySize"]);

            Servers.GetInstance().UpdateServer(serverStatus);

        }

        public static void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Worker Finalizado");

            Thread.Sleep(5000);
            StartWorker();

        }
    }
}