﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    var start = Request.Form["start"].ToString();
                    var length = Request.Form["length"].ToString();
                    var draw = HttpContext.Request.Form["draw"].ToString();
                    var searchValue = Request.Form["search[value]"].ToString();

                    int skip = start != null ? int.Parse(start) : 0;
                    int take = length != null ? int.Parse(length) : 10; //Default value = 10
                    
                    var datProductsDt = new Products();

                    //Searching by name
                    if (!(string.IsNullOrEmpty(searchValue)))
                    {
                        _json = _api.Get("Products", new Dictionary<string, string>()
                        {
                            {"search",searchValue.ToString()}
                        });
                    }
                    else
                    {
                        _json = _api.Get("Products", new Dictionary<string, string>()
                        {
                            {"skip",skip.ToString() },
                            {"take",take.ToString() }
                        });
                    }

                    datProductsDt = JsonConvert.DeserializeObject<Products>(_json);

                    int totalRows = datProductsDt.TotalRows;

                    List<object> list = new List<object>();

                    foreach(ProductsData p in datProductsDt.Data)
                    {
                        List<object> itemList = new List<object>();
                        itemList.Add(p.Name);
                        itemList.Add(p.ProductPrice);
                        itemList.Add(p.Popularity);
                        list.Add(itemList);
                    }

                    return Json(new { draw = draw, recordsFiltered = totalRows, recordsTotal = totalRows, data = list });
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
