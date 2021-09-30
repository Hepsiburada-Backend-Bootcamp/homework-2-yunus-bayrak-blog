using HepsiBlog.Api.Helpers;
using HepsiBlog.Application.Command.Blog;
using HepsiBlog.Domain.Dtos;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBlog.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class BlogPostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BlogPostController> _logger;
        public BlogPostController(IMediator mediator, ILogger<BlogPostController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlogPostDto blogPostDto)
        {
            var createCommand = blogPostDto.Adapt<CreateBlogPostCommand>();
            var blogpost = await _mediator.Send(createCommand);
            if (blogpost == null)
            {
                var internalErrorResponse = ApiResponseGenerator.ErrorResponse((int)ApiErrorCode.ServerError);
                return StatusCode(500, internalErrorResponse);
            }
            var successResponse = ApiResponseGenerator.SuccessResponse(blogpost);
            return Ok(successResponse);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogposts = await _mediator.Send(new GetAllBlogPostsQuery());
            if (blogposts == null)
            {
                var internalErrorResponse = ApiResponseGenerator.ErrorResponse((int)ApiErrorCode.ServerError);
                return StatusCode(500, internalErrorResponse);
            }
            var successResponse = ApiResponseGenerator.SuccessResponse(blogposts);
            return Ok(successResponse);
        }
    }
}
