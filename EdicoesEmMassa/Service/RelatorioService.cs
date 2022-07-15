using EdicoesEmMassa.Repository;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace EdicoesEmMassa.Service
{
    public class RelatorioService : IRelatorioService
    {
        private readonly ITemperaturaRepository _temperaturaRepository;
        public RelatorioService(ITemperaturaRepository temperaturaRepository)
        {
            _temperaturaRepository = temperaturaRepository;
        }
        public void DeserializeTemperatura()
        {
            var temperaturas = _temperaturaRepository.GetAll();
            var jsonTemperaturas = JsonConvert.SerializeObject(temperaturas);
            CreatePDF(1);
        }

        public void CreatePDF(int qtdTemperatura)
        {
            var pxPorMm = 72 / 25.2F;
            var pdf = new Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);
            var fileName = $"temperaturas{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")}.pdf";
            var file = new FileStream(fileName, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf, file);
            pdf.Open();
            var fontBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            var fontParagraph = new iTextSharp.text.Font(fontBase, 32, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var title = new Paragraph("Relatório de Temperaturas\n\n", fontParagraph);
            title.Alignment = Element.ALIGN_LEFT;
            pdf.Add(title);

            pdf.Close();
            file.Close();

            var pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = $"/c start {pdfPath}",
                    FileName = "cmd.exe",
                    CreateNoWindow = true
                });
            }
        }
    }
}
