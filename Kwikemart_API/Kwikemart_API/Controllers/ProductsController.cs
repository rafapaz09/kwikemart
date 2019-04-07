using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kwikemart_API.Models;
using Kwikemart_API.Services;

namespace Kwikemart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductService _productService { get; }

        public ProductsController()
        {
            _productService = new ProductService();
        }

        //NO AUTHORIZE ALL PUBLIC
        /// <summary>
        /// Get a list of all active products on the store
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public async Task<ActionResult>Get()
        {
            try
            {
                return Ok(await _productService.GetProductsAsync());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult>Post([FromBody] ProductsDto products)
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
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="products"></param>
        /// <returns></returns>
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

        //AUTHORIZE ONLY ADMIN
        /// <summary>
        /// Set a new price for a product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="prices"></param>
        /// <returns></returns>
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
        /// <returns></returns>
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