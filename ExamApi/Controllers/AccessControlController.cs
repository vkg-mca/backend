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
        private readonly IAccessControlService _gradeService;

        public AccessControlController(ILogger<AccessControlController> logger, IAccessControlService gradeService)
        {
            _logger = logger;
            _gradeService = gradeService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public IEnumerable<AccessControl> Get()
        { 
            return _gradeService.GetPermissions();
        }


        //[HttpPost()]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<AccessControl>> PostGrades([FromBody] AccessControl grade)
        //{
        //    if (grade.Id.StudentId<=0 || grade.Id.SubjectId <= 0)
        //        return BadRequest();
        //    _gradeService.PostGrades (grade);
        //    return CreatedAtAction(nameof(Get), new { identity = grade.Id  }, grade);
        //}
    }
}
