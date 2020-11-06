using OpenHtmlToPdf;
using System;
using System.IO;

namespace Htmlprinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var htmlContent = File.ReadAllText(Path.Combine(".", "LeaderTemplate.html"));

            var reportPdfFileInfo = new FileInfo(Path.Combine(".", "LeaderTemplate.pdf"));
            var pdfContent = Pdf.From(htmlContent).Portrait().Content();
            File.WriteAllBytes(reportPdfFileInfo.FullName, pdfContent);
        }
    }
}
