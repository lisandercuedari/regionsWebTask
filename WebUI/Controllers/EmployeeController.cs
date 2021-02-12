using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Employees.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class EmployeeController : BaseApiController
    {
        [HttpPost]
        [Route("employee")]
        public async Task<PostModelResult> Post(PostEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
