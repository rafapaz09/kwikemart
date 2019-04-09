using System;
using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kwikemart_API.Models;
using Kwikemart_API.Services;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Kwikemart_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public IProductService _productService { get; }

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get a list of all active products on the store
        /// </summary>
        /// <response code="200">Products Returned Correctly</response>
        /// <response code="400">Products Not Returned</response>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult>Get()
        {
            try
            {
                Dictionary<string, string> Filters = new Dictionary<string, string>();

                var nvc = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                Filters = nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);

                return Ok(await _productService.GetProductsAsync(Filters));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{name}")]
        public async Task<ActionResult> Get(string name)
        {
            try
            {
                return Ok(await _productService.GetProductAsync(name));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Creating new product data. Only by the admin
        /// </summary>
        /// <param name="products"></param>
        /// <response code="200">Products Inserted Correctly</response>
        /// <response code="400">Products Not Inserted</response>
        /// <response code="401">Unauthorized to perfom this action</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult>Post([FromBody] List<ProductsDto> products)
        {
            try
            {
                await _productService.SetProductAsync(products, "I");
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updating data from an existing product. Only by the admin
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="products"></param>
        /// <response code="200">Product Modified Correctly</response>
        /// <response code="400">Error, Product Not Modified</response>
        /// <response code="401">Unauthorized to perfom this action</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{ProductId}")]
        public async Task<ActionResult> Put(int ProductId, [FromBody] ProductsDto products)
        {
            try
            {
                await _productService.SetProductAsync(new Dictionary<string, object>()
                {
                    {"ProductId",ProductId },
                    {"ProductDescription",products.ProductDescription },
                    {"ProductStock",products.ProductStock },
                    {"ProductEnabled",products.ProductEnabled }
                },"U");
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set a new price for a product. Only by the admins
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="prices"></param>
        /// <response code="200">Price of the Product Inserted Correctly</response>
        /// <response code="400">Error, Price not Inserted</response>
        /// <response code="401">Unauthorized to perfom this action</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{ProductId}/Prices")]
        public async Task<ActionResult> Prices(int ProductId, [FromBody] PricesDto prices)
        {
            try
            {
                await _productService.SetProductPriceAsync(new Dictionary<string, object>()
                {
                    {"ProductId", ProductId },
                    {"ProductPrice",prices.ProductPrice },
                    {"PriceCreationUser",prices.PriceCreationUser }
                });
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Registering a new like from a user to a product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="user"></param>
        /// <response code="200">Like of the Product Inserted Correctly</response>
        /// <response code="400">Error, Product Like not inserted</response>
        /// <response code="401">Unauthorized to perfom this action</response>
        [Authorize(Roles = "User")]
        [HttpPut("{ProductId}/Likes/{user}")]
        public async Task<ActionResult> Likes(int ProductId,string user)
        {
            try
            {
                await _productService.SetProductLikeAsync(new Dictionary<string, object>()
                {
                    {"ProductId",ProductId },
                    {"User",user }
                });
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}