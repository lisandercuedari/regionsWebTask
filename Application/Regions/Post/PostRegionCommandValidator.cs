using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Regions.Post
{
    public class PostRegionCommandValidator : AbstractValidator<PostRegionCommand>
    {
        public PostRegionCommandValidator()
        {
            RuleFor(model => model.Name).NotEmpty().WithMessage("Please give a valid Name!");
            RuleFor(model => model.RegionId).NotEmpty().WithMessage("Please give a valid Id for the region!");
        }
    }
}
