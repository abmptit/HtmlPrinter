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
            var abonnement = new Abonnement();
            
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());
            listAbonnements.Add(new Abonnement());

            var renderer = Render.FileToString(Path.Combine(".", "LeaderTemplate.html"), new
            {
                Abonnements = listAbonnements
            });

            File.WriteAllText(Path.Combine(".", "Etiquette.html"), renderer);

            var reportPdfFileInfo = new FileInfo(Path.Combine(".", "LeaderTemplate.pdf"));
            var pdfContent = Pdf.From(renderer).OfSize(PaperSize.A4Rotated).Content();
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
        public Abonnement()
        {
            Image = "leader-log.jpg";
            Nom = "Ben Azzouna";
            Prenom = "Zied";
            NomProduit = "Abonnement annuelle";
            DateExpiration = "06-11-2020";
            Prix = "360 DT";
        }

        public string Image { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomProduit { get; set; }
        public string DateExpiration { get; set; }
        public string Prix { get; set; }
    }
}
