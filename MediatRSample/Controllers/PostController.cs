using MediatR;
using MediatRSample.Command;
using MediatRSample.Helper;
using MediatRSample.Notification;
using MediatRSample.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly IMediator _mediator;
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllPosts")]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var request = new GetAllPostsQuery
            {
                OrderBy = OrderByPostOptions.ByDate
            };
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpPut(Name = "UpdatePost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody]
        UpdatePostCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);

            return NoContent();
        }

        [HttpPost(Name = "WritePostNotification")]
        public async Task<ActionResult> WritePostNotification(string message)
        {
            var notification = new WritePostNotification()
            {
                WhatToWrite = message
            };
            await _mediator.Publish(notification);

            return NoContent();
        }
    }
}
