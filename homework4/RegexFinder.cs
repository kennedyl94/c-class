using Homework7;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace homework7
{
    public class RegexFinder: LogProcessor
    {
        private Stream stream;
        private String s;
       

        public RegexFinder(Stream inStream, String s) : base(inStream, s)
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
                Match myMatch = Regex.Match(line, s);

                if (myMatch.Success)
                {
                    stopWatch.Stop();
                    this.totalTime.Add(new TimeSpan(stopWatch.ElapsedMilliseconds));
                    this.rowsRet++;
                    return myMatch.Value;
                }

            }
            stopWatch.Stop();
            this.totalTime.Add(new TimeSpan(stopWatch.ElapsedMilliseconds));

            return null;
        }
    }
}
