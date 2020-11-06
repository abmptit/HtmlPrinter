using Nustache.Core;
using OpenHtmlToPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Htmlprinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var listAbonnements = new List<Abonnement>();
            listAbonnements.Add(new Abonnement() { Libelle = "Test 1", Adresse = "20 rue des orchidées" } );
            listAbonnements.Add(new Abonnement() { Libelle = "Test 2", Adresse = "10 rue des wechwech" } );

            var renderer = Render.FileToString(Path.Combine(".", "LeaderTemplate.html"), new
            {
                Abonnements = listAbonnements
            });

            //var htmlContent = File.ReadAllText(Path.Combine(".", "LeaderTemplate.html"));

            var reportPdfFileInfo = new FileInfo(Path.Combine(".", "LeaderTemplate.pdf"));
            var pdfContent = Pdf.From(renderer).Portrait().Content();
            File.WriteAllBytes(reportPdfFileInfo.FullName, pdfContent);

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(reportPdfFileInfo.FullName)
            {
                UseShellExecute = true
            };
            p.Start();
        }
    }

    public class Abonnement
    {
        public string Libelle { get; set; }
        public string Adresse { get; set; }
    }
}
