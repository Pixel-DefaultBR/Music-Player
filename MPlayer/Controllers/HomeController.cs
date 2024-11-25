using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using MPlayer.Models;
using System.Diagnostics;

namespace MPlayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> files = GetAllSongFiles();
            
            return View(files);
        }
        public List<string> GetAllSongFiles()
        {
            string directory = Directory.GetCurrentDirectory();
            string path = Path.Combine(directory, "wwwroot", "Songs");

            List<string> files = Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories).ToList();

            return files;
        }
    }
}
