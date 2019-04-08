using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Kwikemart_APP.Models;
using Kwikemart_APP.Repository;
using Newtonsoft.Json;
using Kwikemart_APP.Helpers;

namespace Kwikemart_APP.Controllers
{
    public class HomeController : Controller
    {

        private ApiKwikEMart _api { get; set; }
        private IConfiguration _configuration { get; set; }
        private string _json { get; set; }
        protected ViewRender _view { get; set; }

        public HomeController(IConfiguration configuration, ViewRender view)
        {
            try
            {
                _configuration = configuration;
                _api = new ApiKwikEMart(_configuration);
                _view = view;
            }
            catch(Exception ex)
            {

            }
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult GetAllProducts()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var datProductsDt = new List<Products>();
                    _json = _api.Get("Products");
                    datProductsDt = JsonConvert.DeserializeObject<List<Products>>(_json);
                    return Ok(new
                    {
                        success = true,
                        data = _view.Render("Home/ProductListDetail", datProductsDt)
                    });
                }
                else
                {
                    return Ok(new { success = false, responseText = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, responseText = ex.Message });
            }
        }

    }
}
