using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Project4_Code6.Helpers
{
    public class FtpClass
    {
        public bool FtpModeUsePassive
        {
            get;
            set;

        }

        public string CurrentDirectory
        {
            get;
            set;


        }
        public string FtpServer
        {
            get;
            set;

        }
        public string FtpUserName
        {
            get;
            set;

        }
        public string FtpPassword
        {
            get;
            set;

        }
    }
}
