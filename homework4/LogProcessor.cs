using System;
using System.IO;


namespace Homework7
{
    public class LogProcessor: IReportStatus
    {
        private Stream stream;
        private String s;

        protected int rowsProcessed;
        protected int rowsRet;
        protected TimeSpan totalTime;
        
        public long RowsProcessed
        {
            get
            {
                return rowsProcessed;
            }
        }

        
        public long RowsReturned
        {
            get
            {
                return rowsRet;
            }
        }

        
        public TimeSpan TotalProcessingTime
        {
            get
            {
                return totalTime;
            }
        }

        
        public TimeSpan AverageProcessingTime
        {
            get
            {
                return new TimeSpan(totalTime.Milliseconds/rowsProcessed);
            }
        }

        public LogProcessor(Stream inStream, String s)
        {
            this.totalTime = new TimeSpan();
            this.stream = inStream;
            this.s = s;

        }

        public virtual string NextMatch()
        {
            return null;
        }
    }
}
