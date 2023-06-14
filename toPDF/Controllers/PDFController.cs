using Microsoft.AspNetCore.Mvc;
using toPDF.Services;

namespace toPDF.Controllers
{
    [ApiController]
    [Route("pdf")]
    public class PDFController : Controller
    {

        private readonly PdfGenerator _pdfGenerator;

        public PDFController(PdfGenerator pdfGenerator)
        {
            _pdfGenerator = pdfGenerator;
        }

        [HttpGet]
        public IActionResult GereratePdf()
        {

            string htmlContent = "<html><body><h1>Hola, World!</h1>" +
                "<img src ='https://www.adslzone.net/app/uploads-adslzone.net/2022/09/frio-maximo-aguantar-cuerpo-humano.jpg' " +
                "alt='Ejemplo de imagen'></body></html> ";

            byte[] pdfBytes = _pdfGenerator.GeneratorPdf(htmlContent);

            return File(pdfBytes, "application/pdf", "ejemplo.pdf");

        }

    }
}