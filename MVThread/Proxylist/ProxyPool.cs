﻿using System;
using System.Collections.Generic;

namespace MVThread
{
    public class ProxyPool : IProxyPool
    {
        public List<Proxy> Proxies { get; private set; }
        public int Count { get { return Proxies.Count; } }
        public bool Less { get { return Proxies.Count == 0; } }


        public ProxyPool()
        {
            Proxies = new List<Proxy>();
        }

        public void SetProxylist(List<Proxy> proxies, bool join)
        {
            if (join)
                Proxies.AddRange(proxies);
            else
                Proxies = proxies;
        }

        public Proxy Get()
        {
            if (!Less)
            {
                int num = new Random(Environment.TickCount).Next(Count);
                return Proxies[num];
            }
            else
                return null;
        }
    }
}
