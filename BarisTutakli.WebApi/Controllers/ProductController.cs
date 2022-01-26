namespace BarisTutakli.WebApi.Controllers
{
    using BarisTutakli.WebApi.DbOperations;
    using BarisTutakli.WebApi.Models.Concrete;

    using BarisTutakli.WebApi.ProductOperations.ListProducts;
    using global::WebApi.ProductOperations.Commands.Request;
    using global::WebApi.ProductOperations.Handlers.CommandHandlers;
    using global::WebApi.ProductOperations.Handlers.QueryHandlers;
    using global::WebApi.ProductOperations.Queries.Request;
    using global::WebApi.ProductOperations.Queries.Response;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="ProductController" />.
    /// </summary>
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //IMediator _mediator;
        private readonly ECommerceDbContext _context;
        GetProductsQueryHandler _getProductsQueryHandler;
        GetProductDetailQueryHandler _getProductDetailQueryHandler;
        CreateProductCommandHandler _createProductCommandHandler;
        DeleteProductCommandHandler _deleteProductCommandHandler;
        UpdateProductCommandHandler _updateProductCommandHandler;
        public ProductController(ECommerceDbContext context, 
            GetProductsQueryHandler getProductsQueryHandler,
            GetProductDetailQueryHandler getProductDetailQueryHandler,
            CreateProductCommandHandler createProductCommandHandler,
            DeleteProductCommandHandler deleteProductCommandHandler,
            UpdateProductCommandHandler updateProductCommandHandler
            )
        {
            _context = context;
            _getProductsQueryHandler = getProductsQueryHandler;
            _getProductDetailQueryHandler = getProductDetailQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }



        /// <summary>
        /// Get all produtcs
        /// api/products.
        /// </summary>
        /// <returns>.</returns>
        [HttpGet]
        public IActionResult Get()
        {

            GetAllProductQueryRequest query = new GetAllProductQueryRequest();        
            List<GetAllProductQueryResponse> mtlist = _getProductsQueryHandler.Handle(query);
            return Ok(mtlist);
        }

        /// <summary>
        /// Get one specific produtc by id
        /// api/products/id.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>.</returns>
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {

            GetByIdProductQueryRequest request = new GetByIdProductQueryRequest();
            _getProductDetailQueryHandler.ProductId = id;
            GetByIdProductQueryResponse productDetail = _getProductDetailQueryHandler.Handle(request);
            return Ok(productDetail);
            //return NoContent();// return 204 
        }

        /// <summary>
        /// Create a product
        /// api/products
        /// </summary>
        /// <param name="createProductModel">The createProductModel<see cref="CreateProductModel"/>.</param>
        /// <returns>.</returns>
        [HttpPost()]
        public IActionResult Create([FromBody] CreateProductCommandRequest createProductCommandRequest)
        {
            var result = _createProductCommandHandler.Handle(createProductCommandRequest);
            string message = JsonConvert.SerializeObject(new {message=result.IsSuccess,Id=result.ProductId, time = DateTime.Now });
            return Created("Index", message);//201
        }

        /// <summary>
        /// Update a specific product
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="updateProductModel">The updateProductModel<see cref="UpdateProductModel"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            _updateProductCommandHandler.ProductId = id;
            var result = _updateProductCommandHandler.Handle(updateProductCommandRequest);
            return Ok(result);
        }

        /// <summary>
        /// Update the category of a product
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="updateProductCategoryViewModel">The updateProductCategoryViewModel<see cref="UpdateProductCategoryViewModel"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPatch("{id}")]
        public IActionResult UpdateProductCategory(int id, [FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            _updateProductCommandHandler.ProductId = id;
            var result = _updateProductCommandHandler.Handle(updateProductCommandRequest);
            return Ok(result);
        }

        /// <summary>
        /// Delete a specific product 
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _deleteProductCommandHandler.ProductId = id;
            var result = _deleteProductCommandHandler.Handle();
            return Ok(result);//200
        }


        /////////////////////////  Alt kısım henüz güncellenmedi.////////////////////////////////////////
        /// <summary>
        /// The SortAscById.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("sortAscById")]
        public IActionResult SortAscById()
        {
            ListProductsByAscOrderQuery query = new ListProductsByAscOrderQuery(_context);
            List<Product> orderedList;
            try
            {
                orderedList = query.Handle();
            }
            catch (Exception)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            if (orderedList.Count == 0)
            {
                return NotFound();
            }
            return Ok(orderedList);
        }

        /// <summary>
        /// The SortDescById.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("sortDescById")]
        public IActionResult SortDescById()
        {
            ListProductsByDescOrderQuery query = new ListProductsByDescOrderQuery(_context);
            List<Product> descOrderedList;
            try
            {
                descOrderedList = query.Handle();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

            if (descOrderedList.Count == 0)
            {
                return NotFound();
            }
            return Ok(descOrderedList);
        }

        /// <summary>
        /// The PostHead.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [HttpHead("{id}")]
        public string PostHead(int id)
        {
            return "merhaba";
        }

        /// <summary>
        /// The HowToReturn401.
        /// </summary>
        /// <param name="authorization">The authorization<see cref="string"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("/panel/{authorization}")]
        public IActionResult HowToReturn401(string authorization)
        {
            if (authorization == "user")
            {
                return Unauthorized();//401
            }
            return Ok();
        }

        /// <summary>
        /// The HowToReturn403.
        /// </summary>
        /// <param name="authorization">The authorization<see cref="string"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("/panel/vip/{authorization}")]
        public IActionResult HowToReturn403(string authorization)
        {
            if (authorization == "user")
            {
                return StatusCode(403);// Forbidden
            }
            return Ok();
        }

        /// <summary>
        /// The HowToReturn503.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("/admin")]
        public IActionResult HowToReturn503()
        {

            return StatusCode(503);
        }


    }
}
