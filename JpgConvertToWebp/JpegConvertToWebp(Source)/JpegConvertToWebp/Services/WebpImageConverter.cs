using JpegConvertToWebp.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpegConvertToWebp.Models
{
    public class WebpImageConverter : IImageConverter
    {
        public void ConvertImages(string inputPath, string outputPath, string errorLogFolder)
        {
            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            if (!Directory.Exists(errorLogFolder))
                Directory.CreateDirectory(errorLogFolder);

            var files = Directory.GetFiles(inputPath, "*.*", SearchOption.TopDirectoryOnly)
                                 .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                             f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase));

            var errorLog = new StringBuilder();
            int success = 0, fail = 0;

            foreach (var file in files)
            {
                try
                {
                    using var image = Image.Load(file);
                    string outputFile = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(file) + ".webp");

                    image.Save(outputFile, new WebpEncoder { Quality = 75 });

                    Console.WriteLine($"✔ Dönüştürüldü: {Path.GetFileName(file)}");
                    success++;
                }
                catch (Exception ex)
                {
                    fail++;
                    string fileName = Path.GetFileName(file);
                    Console.WriteLine($"✘ Hata: {fileName}");
                    errorLog.AppendLine($"[{DateTime.Now}] {fileName} → {ex.Message}");
                }
            }

            // Hataları belirtilen klasöre yaz
            if (errorLog.Length > 0)
            {
                string errorPath = Path.Combine(errorLogFolder, "error.txt");
                File.WriteAllText(errorPath, errorLog.ToString());
                Console.WriteLine($"\n❗ {fail} hata oluştu. Detaylar: {errorPath}");
            }

            Console.WriteLine($"\nToplam: {success + fail} | Başarılı: {success} | Hatalı: {fail}");
        }

    }
}
