using EdicoesEmMassa.Helper;
using EdicoesEmMassa.Model;
using EdicoesEmMassa.Model.Reports;
using EdicoesEmMassa.Repository;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EdicoesEmMassa.Service
{
    public class RelatorioService : IRelatorioService
    {
        static BaseFont fontBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        private readonly ITemperaturaRepository _temperaturaRepository;
        private readonly IIncubadoraRepository _incubadoraRepository;
        
        public RelatorioService(ITemperaturaRepository temperaturaRepository, IIncubadoraRepository incubadoraRepository)
        {
            _temperaturaRepository = temperaturaRepository;
            _incubadoraRepository = incubadoraRepository;
        }
        public void DeserializeTemperatura()
        {
            
            //var temperatures = _temperaturaRepository.GetAll();
            //var incubators = _incubadoraRepository.GetAll();
            var temperatureReport = _temperaturaRepository.GetTemperatureReport();

            CreatePDF(temperatureReport);
        }

        public void CreatePDF(List<TemperatureReportModel> temperatureReport)
        {
            var totalPages = 1;
            int totalLines = temperatureReport.Count;
            if (totalLines > 24)
                totalPages += (int)Math.Ceiling((totalLines - 24) / 29F);
            var pxPorMm = 72 / 25.2F;
            var pdf = new Document(PageSize.A4.Rotate(), 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);
            var fileName = $"temperaturas{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")}.pdf";
            var file = new FileStream(fileName, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf, file);
            writer.PageEvent = new PageEvents(totalPages);
            pdf.Open();
            
            var fontParagraph = new iTextSharp.text.Font(fontBase, 32, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var title = new Paragraph("Relatório de Temperaturas\n\n", fontParagraph);
            title.Alignment = Element.ALIGN_LEFT;
            title.SpacingAfter = 4;
            pdf.Add(title);
            var table = new PdfPTable(6);
            float[] columnsWidth = { 1f, 0.7f, 1.5f, 0.8f, 1f, 0.8f };
            table.SetWidths(columnsWidth);
            table.DefaultCell.BorderWidth = 0;
            table.WidthPercentage = 100;


            CreateTextCelula(table, "IdTemperatura", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "IdIncubadora", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "Horário", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "Temp Ideal", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "Cód Incubadora", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "Temperatura Atual", PdfPCell.ALIGN_CENTER, true);

            foreach(var t in temperatureReport)
            {
                CreateTextCelula(table, t.id_temperatura   .ToString("D6"), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.id_incubadora.ToString(), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.update_date.ToString(), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.temperatura_fixada.ToString(), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.cod_incubadora.ToString(), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.temperatura_atual.ToString(), PdfPCell.ALIGN_CENTER);
            }

            pdf.Add(table);

            pdf.Close();
            file.Close();

            var pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = $"/c start firefox {pdfPath}",
                    FileName = "cmd.exe",
                    CreateNoWindow = true
                });
            }

        }

        static void CreateTextCelula(PdfPTable table, string text, int alignmentHorz = PdfPCell.ALIGN_LEFT, bool negrito = false,
            bool italico = false, int tamanhoFonte = 12, int alturaCelula = 25)
        {
            int style = iTextSharp.text.Font.NORMAL;
            if(negrito && italico)
            {
                style = iTextSharp.text.Font.BOLDITALIC;
            }
            else if (negrito)
            {
                style = iTextSharp.text.Font.BOLD;
            }
            else if (italico)
            {
                style = iTextSharp.text.Font.ITALIC;
            }

            var fontCelula = new iTextSharp.text.Font(fontBase, tamanhoFonte, style, BaseColor.Black);

            var bgColor = iTextSharp.text.BaseColor.White;
            if(table.Rows.Count % 2 == 1)
            {
                bgColor = new BaseColor(0.95F, 0.95F, 0.95F);
            }

            var celula = new PdfPCell(new Phrase(text, fontCelula));

            celula.HorizontalAlignment = alignmentHorz;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.FixedHeight = alturaCelula;
            celula.PaddingBottom = 5;
            celula.BackgroundColor = bgColor;
            table.AddCell(celula);
        }

        public void GetDataTemperatureReport(List<Temperatura> temperatures, List<Incubadora> incubators)
        {

        }
    }
}
