using DNetCore21AISite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace DNetCore21AISite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var req = WebRequest.Create("http://bing.com");
            var response = req.GetResponse();
            using (var s = response.GetResponseStream())
            {
                byte[] content = new byte[512];
                s.Read(content, 0, content.Length);
                var contentS = System.Text.Encoding.UTF8.GetString(content);
                Console.WriteLine(contentS);
                ViewBag.Content = contentS;
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page." + Assembly.GetExecutingAssembly().FullName;

            ViewBag.Assemblies = AppDomain.CurrentDomain.GetAssemblies();

            ViewBag.Modules = Process.GetCurrentProcess().Modules;

            ViewBag.EnvironmentVariables = Environment.GetEnvironmentVariables();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
