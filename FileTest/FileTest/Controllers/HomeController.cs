using FileTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.DocumentEditor;
using System.Net;
using static System.Net.WebRequestMethods;

namespace FileTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileService _fileService;
        private const string MimeType = "image/png";
        private const string FileName = "CM-Logo.png";
        public HomeController(IFileService fileService)
        {
            _fileService = fileService;
                
        }
        //[HttpGet("{id}")]
        //[Route("Stream")]
        //public async Task<IActionResult> DownloadPdfFile(string id)
        //{

        //    Stream stream = _f.ReadAsStream(id);
        //    string mimeType = "application/pdf";
        //    return new FileStreamResult(stream, mimeType)
        //    {
        //        FileDownloadName = "FileasStream.pdf"
        //    };
        //}
        

        [HttpGet("images-byte")]
        public IActionResult ReturnByteArray()
        {
            var image = _fileService.GetImageAsByteArray();

            return File(image, MimeType, FileName);
        }

        [HttpGet("images-stream")]
        public IActionResult ReturnStream()
        {
            var image = _fileService.GetImageAsStream();

            return File(image, MimeType, FileName);
        }
        [HttpPost("sdft")]
        public string ImportFileURL()
        {
            try
            {
                string fileUrl = "http://writing.engr.psu.edu/workbooks/formal_report_template.doc";
                //string fileUrl = "https://calibre-ebook.com/downloads/demos/demo.docx";
                using (WebClient client = new WebClient())
                {
                    MemoryStream stream = new MemoryStream(client.DownloadData(fileUrl));
                    WordDocument document = WordDocument.Load(stream, FormatType.Docx);
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(document);
                    document.Dispose();
                    stream.Dispose();
                    return json;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
        public class FileUrlInfo
        {
            public string fileUrl { get; set; }
            public string Content { get; set; }
        }

        internal static FormatType GetFormatType(string format)
        {
            if (string.IsNullOrEmpty(format))
                throw new NotSupportedException("EJ2 DocumentEditor does not support this file format.");
            switch (format.ToLower())
            {
                case ".dotx":
                case ".docx":
                case ".docm":
                case ".dotm":
                    return FormatType.Docx;
                case ".dot":
                case ".doc":
                    return FormatType.Doc;
                case ".rtf":
                    return FormatType.Rtf;
                case ".txt":
                    return FormatType.Txt;
                case ".xml":
                    return FormatType.WordML;
                default:
                    throw new NotSupportedException("EJ2 DocumentEditor does not support this file format.");
            }
        }
    }
}
