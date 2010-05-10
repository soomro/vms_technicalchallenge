using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class WSLogger : NLog.Logger
    { 

        static NLog.Logger _logger = NLog.LogManager.GetLogger("WS");

        /// <summary>
        /// Default logger for quick usage
        /// </summary>
        public static NLog.Logger Logger
        {
            get
            {
                return _logger;
            }            
        }
        
        

    }
}
