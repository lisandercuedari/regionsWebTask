using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Regions.Post
{
    public class PostRegionCommand : IRequest<PostModelResult>
    {
        public int Id { get; set; }
        public int ParentRegionId { get; set; }
        public string Name { get; set; }
    }
}
