using Application.Common.Models;
using Application.Common.Validation;
using Domain;
using Domain.Region;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Regions.Post
{
    class PostRegionCommandHandler : IRequestHandler<PostRegionCommand, PostModelResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IContextualValidator<PostRegionCommand> _validator;

        public PostRegionCommandHandler(IApplicationDbContext context,
            IContextualValidator<PostRegionCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<PostModelResult> Handle(PostRegionCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(command, cancellationToken);
            if (!validationResult.Valid)
                return new PostModelResult()
                {
                    Valid = false,
                    Message = validationResult.Message
                };

            var newRegion = new Region();
            newRegion.Name = command.Name;
            newRegion.RegionId = command.RegionId;

            if (command.ParentRegionId != 0)
            {
                var parentRegion = await _context.GetRegionById(command.ParentRegionId, cancellationToken: cancellationToken);

                if (parentRegion == null)
                {
                    return new PostModelResult()
                    {
                        Valid = false,
                        Message = $"Please give a valid parent region. Region with id {command.ParentRegionId} does not exist!"
                    };
                }

                newRegion.ParentRegion = parentRegion;
            }

            await _context.Regions.AddAsync(newRegion, cancellationToken);
            
            var result = await _context.SaveChangesAsync(cancellationToken);
            return new PostModelResult()
            {
                Message = result != 1 ? "Please try again!" : "Region was created successfuly!",
                Valid = true
            };
        }
    }
}
