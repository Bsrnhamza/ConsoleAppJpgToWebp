using JpegConvertToWebp.Interfaces;
using JpegConvertToWebp.Models;

class Program
{
    static void Main(string[] args)
    {
        IImageConverter converter = new WebpImageConverter();
        IConsoleUI ui = new ConsoleUI(converter);
        ui.Run();
    }
}