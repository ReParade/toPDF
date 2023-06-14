using DinkToPdf;
using DinkToPdf.Contracts;

namespace toPDF.Services
{
    public class PdfGenerator
    {
        private readonly IConverter _converter;

        public PdfGenerator(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratorPdf(string htmlContent)
        {

            var globalSettings = new GlobalSettings
            {
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.Letter
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                //Page = "",
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 12, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontSize = 12, Line = true, Right = "© " + DateTime.Now.Year }
            };

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return _converter.Convert(document);

        }

    }
}
