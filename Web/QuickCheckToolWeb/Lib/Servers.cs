using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickCheckToolWeb.Lib
{
    public class Servers
    {
        private Servers() { }
        private static Servers instance;
        public static Servers GetInstance()
        {
            if (instance == null)
            {
                instance = new Servers();
            }
            return instance;
        }


        private Dictionary<String, ServerStatus> servers = new Dictionary<String, ServerStatus>();

        public IEnumerable<ServerStatus> ReadServers()
        {
            return servers.Values;
        }

        public void UpdateServer(ServerStatus server)
        {
            if (servers.ContainsKey(server.Ip))
            {
                servers[server.Ip] = server;
            }
            else {
                servers.Add(server.Ip, server);
            }
        }
    }
}