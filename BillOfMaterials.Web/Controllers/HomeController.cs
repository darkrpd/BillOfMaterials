using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BillOfMaterials.Web.Models;
using BillOfMaterials.Web.Helpers;
using Microsoft.Extensions.Configuration;
using BillOfMaterials.Core.Models;
using Newtonsoft.Json;
using System.Net.Mime;

namespace BillOfMaterials.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string path = _configuration["WebApiUrl"].ToString() + "api/Product";

            string json = RequestHelper.Get(path);

            var products = JsonConvert.DeserializeObject<List<BillOfMaterials.Web.Models.Product>>(json);

            List<ProductTree> productTreeList = new List<ProductTree>();

            foreach (var product in products)
            {
                List<CategoryTree> mainCategoryTreeList = new List<CategoryTree>();

                foreach (var category in product.categories)
                {
                    string path2 = _configuration["WebApiUrl"].ToString() + "api/Product/" + category.id.ToString();

                    string json2 = RequestHelper.Get(path2);

                    var subcategories = JsonConvert.DeserializeObject<List<SubCategory>>(json2);

                    List<CategoryTree> categoryTreeList = new List<CategoryTree>();
                    foreach (var subcategory in subcategories)
                    {
                        CategoryTree categoryTree = new CategoryTree()
                        {
                            id = subcategory.id,
                            name = subcategory.name,
                            categories = new List<CategoryTree>()
                        };

                        categoryTreeList.Add(categoryTree);
                    }

                    CategoryTree mainCategoryTree = new CategoryTree()
                    {
                        id = category.id,
                        name = category.name,
                        categories = categoryTreeList
                    };

                    mainCategoryTreeList.Add(mainCategoryTree);
                }

                ProductTree tree = new ProductTree()
                {
                    id = product.id,
                    name = product.name,
                    categories = mainCategoryTreeList
                };

                productTreeList.Add(tree);

            }

            return new JsonResult(productTreeList);
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
