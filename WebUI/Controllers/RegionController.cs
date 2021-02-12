using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Models;
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
    }
}
