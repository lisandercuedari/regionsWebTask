using Application.Common.Models;
using Application.Common.Validation;
using Domain;
using Domain.Employee;
using Domain.Region;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Post
{
    class PostEmployeeCommandHandler : IRequestHandler<PostEmployeeCommand, PostModelResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IContextualValidator<PostEmployeeCommand> _validator;

        public PostEmployeeCommandHandler(IApplicationDbContext context,
            IContextualValidator<PostEmployeeCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<PostModelResult> Handle(PostEmployeeCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(command, cancellationToken);
            if (!validationResult.Valid)
                return new PostModelResult()
                {
                    Valid = false,
                    Message = validationResult.Message
                };

            //Do not check if Region exists beacuse it was already checked by the Validator
            var enmployee = new Employee()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                RegionId = command.RegionId
            };

            await _context.Employees.AddAsync(enmployee, cancellationToken);
            
            var result = await _context.SaveChangesAsync(cancellationToken);
            return new PostModelResult()
            {
                Message = result != 1 ? "Please try again!" : "Employee was created successfuly!",
                Valid = true
            };
        }
    }
}
