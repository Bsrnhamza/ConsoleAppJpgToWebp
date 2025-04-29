using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpegConvertToWebp.Interfaces
{
    public interface IImageConverter
    {
        void ConvertImages(string inputPath, string outputPath, string errorLogFolder);
    }
}
