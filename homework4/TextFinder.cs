using Homework7;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Diagnostics;


namespace homework7
{
    public class TextFinder: LogProcessor
    {
        private Stream stream;
        private String s;

        public TextFinder(Stream inStream, String s) : base(inStream, s)
        {
            this.stream = inStream;
            this.s = s;
        }

        override
        public string NextMatch()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (stream == null)
                return null;
            StreamReader reader = new StreamReader(stream);
            String line;
            
            while ((line = reader.ReadLine()) != null)
            {
                this.rowsProcessed++;
                if (line.Contains(s))
                {
                    stopWatch.Stop();
                    this.totalTime.Add(new TimeSpan(stopWatch.ElapsedMilliseconds));
                    this.rowsRet++;
                    return line;
                }

            }
            stopWatch.Stop();
            this.totalTime.Add(new TimeSpan(stopWatch.ElapsedMilliseconds));

            return null;
        }
    }
}
