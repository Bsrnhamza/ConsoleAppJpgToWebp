using JpegConvertToWebp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpegConvertToWebp.Models
{
    public class ConsoleUI : IConsoleUI
    {
        private readonly IImageConverter _converter;

        public ConsoleUI(IImageConverter converter)
        {
            _converter = converter;
        }

        public void Run()
        {
            Console.WriteLine("=== JPEG to WEBP Dönüştürücü ===");

            string inputPath = PromptPath("Giriş klasörünü girin: ");
            string outputPath = PromptPath("Çıkış klasörünü girin: ", allowNonExisting: true);
            string errorPath = PromptPath("Hata log dosyasının kaydedileceği klasörü girin: ", allowNonExisting: true);

            _converter.ConvertImages(inputPath, outputPath, errorPath);

            Console.WriteLine("\nİşlem tamamlandı. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }


        private string PromptPath(string message, bool allowNonExisting = false)
        {
            string? path;
            do
            {
                Console.Write(message);
                path = Console.ReadLine();
                if (allowNonExisting || Directory.Exists(path))
                    break;

                Console.WriteLine("❌ Geçersiz klasör yolu.");
            } while (true);

            return path!;
        }
    }
}
