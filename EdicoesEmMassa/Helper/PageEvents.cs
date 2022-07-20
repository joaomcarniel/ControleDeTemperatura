using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

namespace EdicoesEmMassa.Helper
{
    public class PageEvents : PdfPageEventHelper
    {
        private BaseFont fontBaseRodape { get; set; }
        private iTextSharp.text.Font fontRodape { get; set; }
        private int totalPages { get; set; }

        public PageEvents(int _totalPages)
        {
            fontBaseRodape = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            fontRodape = new iTextSharp.text.Font(fontBaseRodape, 8f, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            totalPages = _totalPages;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            AddRelatorioGenerationMoment(writer, document);
            AddPageNumbers(writer, document);
        }

        private void AddRelatorioGenerationMoment(PdfWriter writer, Document document)
        {
            var textGenerationMoment = $"Gerado em {DateTime.Now.ToShortDateString()} às " +
                            $"{DateTime.Now.ToShortTimeString()}";

            writer.DirectContent.BeginText();
            writer.DirectContent.SetFontAndSize(fontRodape.BaseFont, fontRodape.Size);
            writer.DirectContent.SetTextMatrix(document.LeftMargin, document.BottomMargin * 0.75f);
            writer.DirectContent.ShowText(textGenerationMoment);
            writer.DirectContent.EndText();
        }

        private void AddPageNumbers(PdfWriter writer, Document document)
        {
            int actualPage = writer.PageNumber;
            var pageText = $"Página {actualPage} de {totalPages}";
            float larguraTextoPaginacao = fontBaseRodape.GetWidthPoint(pageText, fontRodape.Size);

            var pageSize = document.PageSize;

            writer.DirectContent.BeginText();
            writer.DirectContent.SetFontAndSize(fontRodape.BaseFont, fontRodape.Size);
            writer.DirectContent.SetTextMatrix(pageSize.Width - document.RightMargin - larguraTextoPaginacao, document.BottomMargin * 0.75f);
            writer.DirectContent.ShowText(pageText);
            writer.DirectContent.EndText();
        }
    }
}
