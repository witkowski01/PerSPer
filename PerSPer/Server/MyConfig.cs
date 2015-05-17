using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSockets.Core.Configuration;

namespace Server
{
    class MyConfig : ConfigurationSetting
    {
        public MyConfig()
            : base("ws://localhost:8080")
        {

        }
    }
}
