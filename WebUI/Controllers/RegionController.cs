using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Regions.GetEmployees;
using Application.Regions.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class RegionController : BaseApiController
    {
        [HttpPost]
        [Route("region")]
        public async Task<PostModelResult> Post(PostRegionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        [Route("/region/{id}/employees")]
        public async Task<List<GetEmployeesVM>> Get(int id)
        {
            return await Mediator.Send(new GetEmployeesQuery()
            {
                RegionId = id
            });
        }
    }
}
