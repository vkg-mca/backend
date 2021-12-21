using Points.Server.Models;
using Points.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Points.Entities.Models;
using System.Net;


namespace Exam.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessControlController : ControllerBase
    {

        private readonly ILogger<AccessControlController> _logger;
        private readonly IAccessControlService _accessControlService;

        public AccessControlController(ILogger<AccessControlController> logger,
            IAccessControlService accessControlService)
        {
            _logger = logger;
            _accessControlService = accessControlService;
        }

        /// <summary>
        /// Retrieves all permission sets defined in the system
        /// </summary>
        /// <returns>List of permissions</returns>
        //[Authorize]
        [HttpGet]
        //[HttpGet("accessControlDetail")]
        public async Task<IEnumerable<AccessControl>> GetAsync()
            => await _accessControlService.GetPermissionsAsync()
            .ConfigureAwait(false);

        /// <summary>
        /// Retrieves permissions for specific user
        /// </summary>
        /// <param name="userId">user for whom permission is requested</param>
        /// <returns>List of permissions</returns>
        [HttpGet("{userId:required}")]
        public async Task<ActionResult<AccessControl>> Get(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                    return CreateBadRequestResponse(userId, nameof(userId));
                return await _accessControlService.GetPermissionAsync(userId)
                 .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return CreateBadRequestResponse(userId, nameof(userId),ex);
            }
        }

        /// <summary>
        /// Creates a new permissions entry in the system
        /// </summary>
        /// <param name="accessControl">permission set to be cerated</param>
        /// <returns>status of the operation</returns>
        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccessControl>> PostAccessControlPermissionsAsync([FromBody] AccessControl accessControl)
        {
            if (accessControl.RoleId <= 0 || string.IsNullOrWhiteSpace(accessControl.UserId) || !(accessControl.Permissions.Any()))
                return BadRequest();
            await _accessControlService.SavePermissionAsync(accessControl)
                .ConfigureAwait(false);
            return CreatedAtAction(nameof(Get), new { identity = accessControl.UserId }, accessControl);
        }

        /// <summary>
        /// Updates permission of an exisiting user
        /// </summary>
        /// <param name="userId">user for whom permission is updated</param>
        /// <param name="accessControl">new permission set</param>
        /// <returns>status of the operation</returns>
        [HttpPut()]
        [Route("{userId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(AccessControl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccessControl>> PutAccessControlPermissionsAsync([FromRoute] string userId, [FromBody] AccessControl accessControl)
        {
            if (string.IsNullOrWhiteSpace(accessControl.UserId))
                return BadRequest();
            await _accessControlService.SavePermissionAsync(accessControl)
                .ConfigureAwait(false);
            return CreatedAtAction(nameof(Get), new { identity = accessControl.UserId }, accessControl);
        }

        /// <summary>
        /// Deletes permission of an existing user
        /// </summary>
        /// <param name="userId">user for whom permission is deleted</param>
        /// <returns>status of the operation</returns>
        [HttpDelete]
        [Route("{userId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest();
            return true;
        }

        private BadRequestResult CreateBadRequestResponse(string key, string value, Exception? ex)
        {
            var reason = ex==null? $"userId cannot be an empty/default":"Something went wrong, please try later";
            var logEntry = new LogEntry
            {
                Code = ex == null ? ArgumentCode.InvalidArgumet: ServerCode.InternalServerError,
                Message = reason,
                Context = new Dictionary<string, string> { { key, value } }
            };
            _logger.Log(LogLevel.Error, 0, logEntry, null, (state, exception) => ex.Message);
            return BadRequest();
        }
        private BadRequestResult CreateBadRequestResponse(string key, string value)
            => CreateBadRequestResponse(key,value,null);
    }
}
