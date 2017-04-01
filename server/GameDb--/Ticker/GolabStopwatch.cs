using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GameLib.Ticker
{
    public class GolabStopwatch
    {
        static public Stopwatch _stopwatch;

        static public int init()
        {
            if (_stopwatch == null)
            {

                _stopwatch = new Stopwatch();
                _stopwatch.Start();
                    //Process.GetCurrentProcess();
            }

            return 0;
        }

        static public long ElapsedMilliseconds 
        {
            get { return _stopwatch.ElapsedMilliseconds; }
        }
    }
}
