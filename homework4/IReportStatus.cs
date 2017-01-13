using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework7
{
    interface IReportStatus
    {
        long RowsProcessed { get; }

        long RowsReturned { get; }
        TimeSpan TotalProcessingTime { get; }
        TimeSpan AverageProcessingTime { get; }
    }
}


