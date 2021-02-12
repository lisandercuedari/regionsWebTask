using Application.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Post
{
    class PostProductContextualValidator : IContextualValidator<PostEmployeeCommand>
    {
        private readonly IApplicationDbContext _context;

        public PostProductContextualValidator(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(PostEmployeeCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
                var region = await _context.GetRegionById(command.RegionId, cancellationToken: cancellationToken);

                if (region == null)
                {
                    return ValidationResult.Failure($"Please give a valid region Id. Region with id {command.RegionId} does not exist!");
                }

            return ValidationResult.Success();
        }
    }
}
