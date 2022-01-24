namespace BarisTutakli.WebApi.Controllers
{
    using BarisTutakli.WebApi.Common;
    using BarisTutakli.WebApi.DbOperations;
    using BarisTutakli.WebApi.Models.Concrete;

    using BarisTutakli.WebApi.ProductOperations.ListProducts;
    using BarisTutakli.WebApi.ProductOperations.UpdateProduct;
    using FluentValidation;
    using global::WebApi.Common.Base.Concrete;
    using global::WebApi.ProductOperations.Commands.Request;
    using global::WebApi.ProductOperations.Handlers.CommandHandlers;
    using global::WebApi.ProductOperations.Handlers.QueryHandlers;
    using global::WebApi.ProductOperations.Handlers.Validators;
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

        private readonly ECommerceDbContext _context;

        public ProductController(ECommerceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all produtcs
        /// api/products.
        /// </summary>
        /// <returns>.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            GetProductsQueryHandler command = new GetProductsQueryHandler(
                new BaseReadAllRepository<Product, ECommerceDbContext>(_context));
            var result = command.Handle();
            return Ok(result);
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
            GetProductDetailQueryHandler queryHandler = new GetProductDetailQueryHandler(new BaseReadRepository<Product, ECommerceDbContext>(_context));
            queryHandler.ProductId = id;
           
            var result = queryHandler.Handle();
            if (result is not null)
            {
                return Ok(result);
            }
            return NoContent();// return 204 
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
            CreateProductCommandValidator validator = new CreateProductCommandValidator();
            CreateProductCommandHandler command = new CreateProductCommandHandler(
                new BaseCreateRepository<Product, ECommerceDbContext>(_context));

            command.Model = createProductCommandRequest;
            validator.ValidateAndThrow(command);
            command.Handle();

            // Return a message and the creation time of the product
            string message = JsonConvert.SerializeObject(new { message = Messages.Added, time = DateTime.Now });
            return Created("Index", message);//201
        }

        /// <summary>
        /// Update a specific product
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="updateProductModel">The updateProductModel<see cref="UpdateProductModel"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandHandler commandHandler = new UpdateProductCommandHandler(
                new BaseUpdateRepository<Product, ECommerceDbContext>(_context),
                new BaseReadRepository<Product, ECommerceDbContext>(_context));
            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
            commandHandler.ProductId = id;
            commandHandler.Model = updateProductCommandRequest;
            validator.ValidateAndThrow(commandHandler);

            commandHandler.Handle();

            return Ok();
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

            UpdateProductCommandHandler commandHandler = new UpdateProductCommandHandler(
                new BaseUpdateRepository<Product, ECommerceDbContext>(_context),
                new BaseReadRepository<Product, ECommerceDbContext>(_context));
            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();

            commandHandler.ProductId = id;
            commandHandler.Model = updateProductCommandRequest;
            validator.ValidateAndThrow(commandHandler);

            commandHandler.Handle();

            return Ok();
        }

        /// <summary>
        /// Delete a specific product 
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            DeleteProductCommandHandler command = new DeleteProductCommandHandler(
            new BaseDeleteRepository<Product, ECommerceDbContext>(_context),
            new BaseReadRepository<Product, ECommerceDbContext>(_context)
            );
            DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
            command.ProductId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();//200
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
