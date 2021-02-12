using Application.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Regions.Post
{
    class PostProductContextualValidator : IContextualValidator<PostRegionCommand>
    {
        private readonly IApplicationDbContext _context;

        public PostProductContextualValidator(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(PostRegionCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
                var region = await _context.GetRegionById(command.Id, cancellationToken: cancellationToken);

                if (region != null)
                {
                    return ValidationResult.Failure($"Please give a valid region Id. Region with id {command.Id} already exist!");
                }

            return ValidationResult.Success();
        }
    }
}
