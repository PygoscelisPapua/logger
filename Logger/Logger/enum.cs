using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nLogger
{
    public enum TimeMark
    {
        /// <summary>
        /// logName
        /// </summary>        
        none,
        /// <summary>
        /// yyyyMMdd_logName
        /// </summary>        
        pre,
        /// <summary>
        /// "logName_yyyyMMdd
        /// </summary>        
        suf,
    }
}
