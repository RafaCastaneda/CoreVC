using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace CoreVC.Serve.Controllers
{
    using Services;

    [Produces("application/json")]
    [Route("dir")]
    public class DirectoryController : Controller
    {
        private readonly DirectoryService directoryService;

        public DirectoryController(DirectoryService directoryService)
        {
            this.directoryService = directoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Get("");
        }

        [HttpGet("{*path}", Name = "Get")]
        public IActionResult Get(string path)
        {
            try {
                var filePaths = directoryService.Dir(path);
                return new ObjectResult(filePaths);
            }
            catch (DirectoryNotFoundException) {
                return NotFound();
            }
        }
    }
}
