using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Post
{
    public class PostEmployeeCommandValidator : AbstractValidator<PostEmployeeCommand>
    {
        public PostEmployeeCommandValidator()
        {
            RuleFor(model => model.FirstName).NotEmpty().WithMessage("Please give a valid FirstName!");
            RuleFor(model => model.LastName).NotEmpty().WithMessage("Please give a valid LastName!");
            RuleFor(model => model.RegionId).NotEmpty().WithMessage("Please give a valid Id for the region!");
        }
    }
}
