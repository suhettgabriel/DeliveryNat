using DeliveryNat.Areas.Admin.FastReportUtil;
using DeliveryNat.Areas.Admin.Services;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryNat.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProdutosReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly RelatorioProdutoServices _relatorioProdutosService;

        public AdminProdutosReportController(IWebHostEnvironment webHostEnv,
            RelatorioProdutoServices relatorioProdutosService)
        {
            _webHostEnv = webHostEnv;
            _relatorioProdutosService = relatorioProdutosService;
        }
        public async Task<ActionResult> ProdutosCategoriaReport()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports",
                                               "produtosCategoria.frx"));

            var produtos = HelperFastReport.GetTable(await _relatorioProdutosService.GetProdutosReport(), "ProdutosReport");
            var categorias = HelperFastReport.GetTable(await _relatorioProdutosService.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(produtos, "ProdutoReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");
            return View(webReport);
        }

        [Route("ProdutosCategoriaPDF")]
        public async Task<ActionResult> ProdutosCategoriaPDF()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports",
                                               "ProdutosCategoria.frx"));

            var produtos = HelperFastReport.GetTable(await _relatorioProdutosService.GetProdutosReport(), "ProdutosReport");
            var categorias = HelperFastReport.GetTable(await _relatorioProdutosService.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(produtos, "ProdutoReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");

            webReport.Report.Prepare();

            Stream stream = new MemoryStream();

            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", "LancheCategoria.pdf");
            //return new FileStreamResult(stream, "application/pdf");
        }

    }
}
