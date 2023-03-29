using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLyrics
{
    internal class Line
    {
        public string startTimeMs { get; set; }
        public string words { get; set; }
        public string[] syllables { get; set; }
        public string endTimeMs { get; set; }
    }
}
