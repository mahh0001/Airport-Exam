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

        public async Task<IActionResult> Index()
        {
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync($@"api/airport/AllFlights");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = await response.Content.ReadAsAsync<List<FlightProxy>>();

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult SearchFlights()
        {
            return View();
        }


        public async Task<IActionResult> EditFlights(int id)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync($@"api/airport/{id}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = await response.Content.ReadAsAsync<FlightProxy>();

                return View(model);
            }
            else
            {
                return BadRequest("An error occured.");
            }
        }

        public async Task<IActionResult> EditFlightsPut(FlightProxy flight)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync($@"api/airport/{flight.FlightId}", flight);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = await response.Content.ReadAsAsync<FlightProxy>();

                return RedirectToAction("Index");
                //return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> SearchFlightsAction(string FromLocation, string ToLocation)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync($@"api/airport/SpecificFlights/{FromLocation}/{ToLocation}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = await response.Content.ReadAsAsync<List<FlightProxy>>();

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> SeeAllLocations()
        {
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync($@"api/airport/AllDeparturesAndArrivals");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = await response.Content.ReadAsAsync<List<FlightProxy>>();

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

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
