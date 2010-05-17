using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class Log 
    { 

        static NLog.Logger _wslogger = NLog.LogManager.GetLogger("WS");
        static NLog.Logger _weblogger = NLog.LogManager.GetLogger("WEB");
        static NLog.Logger _blllogger = NLog.LogManager.GetLogger("BLL");
        public static NLog.Logger BLLogger
        {
            get
            {
                return _blllogger;
            }
        }
        /// <summary>
        /// Default logger for quick usage
        /// </summary>
        public static NLog.Logger WSLogger
        {
            get
            {
                return _wslogger;
            }            
        }

        public static NLog.Logger WEBLogger
        {
            get
            {
                return _weblogger;
            }
        }
        

    }
}
