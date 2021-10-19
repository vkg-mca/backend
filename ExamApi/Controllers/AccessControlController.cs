using Exam.Grade.DomainObjects;
using Exam.Grade.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Exam.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("exam/grades")]
    public class AccessControlController : ControllerBase
    {

        private readonly ILogger<AccessControlController> _logger;
        private readonly IAccessControlService _accessControlService;

        public AccessControlController(ILogger<AccessControlController> logger, IAccessControlService accessControlService)
        {
            _logger = logger;
            _accessControlService = accessControlService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public IEnumerable<AccessControl> Get()
        { 
            return _accessControlService.GetPermissions();
        }

        [HttpGet("{userId:required}")]
        [ApiVersion("1.0")]
        public IEnumerable<AccessControl> Get(string userId)
        {
            return _accessControlService.GetPermissions();
        }


        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccessControl>> PostAccessControlPermissions([FromBody] AccessControl accessControl)
        {
            if (string.IsNullOrWhiteSpace(accessControl.RoleId) || string.IsNullOrWhiteSpace(accessControl.UserId) || !(accessControl.Permissions.Any()))
                return BadRequest();
            _accessControlService.SavePermission(accessControl);
            return CreatedAtAction(nameof(Get), new { identity = accessControl.UserId }, accessControl);
        }


        [HttpPut()]
        [Route("{userId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccessControl>> PutAccessControlPermissions([FromRoute] string userId, [FromBody] AccessControl accessControl)
        {
            if ( string.IsNullOrWhiteSpace(accessControl.UserId) )
                return BadRequest();
            _accessControlService.SavePermission(accessControl);
            return CreatedAtAction(nameof(Get), new { identity = accessControl.UserId }, accessControl);
        }
    }
}
