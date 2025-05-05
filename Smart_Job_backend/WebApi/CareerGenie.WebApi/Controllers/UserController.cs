using CareerGenie.Services.DTOs;
using CareerGenie.Services.Features.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CareerGenie.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/user/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken
        )
        {
            if (string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Password is required.");

            await _mediator.Send(
                new CreateUser.Command(request.User, request.Password),
                cancellationToken
            );
            return Ok(new { message = "User Created SuccessFully" });
        }

        // Get: api/user/get-by-id/id
        [HttpGet("get-by-id/{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserById.Query(id), cancellationToken);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetAllUsers.Query(), cancellationToken);
            return Ok(users);
        }

        // PUT: api/user/update/{id}
        [HttpPut("update/{id:guid}")]
        public async Task<IActionResult> UpdateUser(
            Guid id,
            [FromBody] UserDto updatedUser,
            CancellationToken cancellationToken
        )
        {
            if (id != updatedUser.Id)
                return BadRequest("User ID mismatch");

            await _mediator.Send(new UpdateUser.Command(updatedUser), cancellationToken);
            return Ok(new { message = "User Updated Successfully" });
        }

        // DELETE: api/user/delete/{id}
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteUser.Command(id), cancellationToken);
            return Ok(new { message = "User Deleted Successfully" });
        }
    }

    public class CreateUserRequest
    {
        public UserDto User { get; set; } = new();
        public string Password { get; set; } = string.Empty;
    }
}
