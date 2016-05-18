using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InvokingWebAPI.Models;

namespace InvokingWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Products");

            //ViewBag.Title = "Home Page";

            //return View();
        }

        public async Task<ActionResult> Products()
        {
            var products = await GetAllProducts();
            if (products == null)
            {
                return HttpNotFound();
            }

            return View(products);
        }

        //asynchronously accessing of web api method
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> products = null;
            using (var client = new HttpClient())
            {
                //define the base address of the MVC application hosting the Web API
                //As we're accessing the web api from the same solution so,
                var baseUrl = System.Web.HttpContext.Current.Request.Url.Scheme + "://" +
                          System.Web.HttpContext.Current.Request.Url.Authority;

                client.BaseAddress = new Uri(baseUrl);

                //define serialization (e.g. json or xml etc.)
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //call the web api method
                var response = client.GetAsync("api/products").Result;
                if (response.IsSuccessStatusCode)
                {
                    //convert result into product list
                    products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                }
            }

            return products;
        }
    }
}
