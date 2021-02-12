using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Post
{
    public class PostEmployeeCommand : IRequest<PostModelResult>
    {
        public int RegionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
