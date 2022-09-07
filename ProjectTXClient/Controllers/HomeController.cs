using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectTXClient.Models;
using System.Diagnostics;

namespace ProjectTX.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string searchKey = "")
        {
            string a = searchKey;
            
            List<ProductModel> TestModeList = new List<ProductModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7064/api/Product/" + searchKey))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TestModeList = JsonConvert.DeserializeObject<List<ProductModel>>(apiResponse).ToList();

                }
            }
            return View(TestModeList);
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