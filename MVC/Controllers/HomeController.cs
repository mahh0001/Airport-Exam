using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public const string API = "https://localhost:44369";
        public const string Client = "https://localhost:44350/";

        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        ///////////List of items - HTTPGET/////////////////////////
        //public async Task<IActionResult> SeeAllItems()
        //{
        //    var client = GetClient();
        //    HttpResponseMessage response = await client.GetAsync($@"api/CONTROLLER/METHOD");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string content = await response.Content.ReadAsStringAsync();
        //        var model = await response.Content.ReadAsAsync<List<ProxyModel>>();

        //        return View(model);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        /////////////////SPECIFIC ITEM - HTTPGET////////////////
        //public async Task<IActionResult> SeeItem(int itemNumber)
        //{
        //    var client = GetClient();
        //    HttpResponseMessage response = await client.GetAsync($@"api/CONTROLLER/METHOD/{itemNumber}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string content = await response.Content.ReadAsStringAsync();
        //        var model = await response.Content.ReadAsAsync<ProxyModel>();

        //        return View(model);
        //    }
        //    else
        //    {
        //        return BadRequest("An error occured.");
        //    }
        //}

        ////////////ADD NEW ITEM////////////////
        //public IActionResult AddNewItem()
        //{
        //    return View();
        //}

        ///////REDIRECT TO THIS METHOD WHEN ADDING - HTTPPOST////////////
        //public async Task<IActionResult> CreateNewItem(string itemTitle, DateTime CreationDate)
        //{
        //    var client = GetClient();

        //    ModelProxy model = new ModelProxy();
        //    model.Title = itemTitle;
        //    model.CreationDate = CreationDate;

        //    HttpResponseMessage response = await client.PostAsJsonAsync($@"/api/CONTROLLER/METHOD", model);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("ACTION");
        //    }
        //    else
        //    {
        //        return BadRequest("An error occured");
        //    }
        //}

        //////////DELETE ITEM - HTTPDELETE////////////////////////
        //public async Task<IActionResult> DeleteItem(int itemId)
        //{
        //    var client = GetClient();
        //    HttpResponseMessage response = await client.DeleteAsync($@"/api/CONTROLLER/METHOD/{id}");
        //
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("ACTION");
        //    }
        //    else
        //    {
        //        return BadRequest("An error occured");
        //    }
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

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
