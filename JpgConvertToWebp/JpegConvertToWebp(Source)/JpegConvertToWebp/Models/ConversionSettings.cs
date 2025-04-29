using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpegConvertToWebp.Services
{
    public class ConversionSettings
    {
        public string InputFolder { get; set; }
        public string OutputFolder { get; set; }
        public int Quality { get; set; } = 75;
    }
}
